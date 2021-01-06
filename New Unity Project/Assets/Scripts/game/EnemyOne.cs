using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class EnemyOne : MonoBehaviour {
    Sequence seq;
    bool seqFlag;
    public GameObject bulletObject;
    public GameObject enemyObject;

    // 自分のマスターデータ
    DataTable.DataEnemy MyDataEnemy { get; set; } 

    // 敵の初期位置
    RectTransform EnemyStartPosition;

    ShoterManager EnemyShoterManager;

    // 敵の行動データ
    DataTable.DataEnemyAction ListEnemyAction;

    // Use this for initialization
    void Start () {
        // テストデータ
        MyDataEnemy = new DataTable.DataEnemy { id = 1, hp = 100, action_start = 1 };

        // ShoterManagerの生成
        // originObjectはSphere
        EnemyShoterManager = new ShoterManager(bulletObject, gameObject);

        // 次に動作するフラグ
        seqFlag = false;

        // 初期位置
        //EnemyStartPosition = GetComponent<>

        // ListActionのactionを取得
        ListEnemyAction = DataTable.Instance.ListAction().Where(l => l.id == MyDataEnemy.action_start).FirstOrDefault();

        // 敵の初期値データ
        List<DataTable.DataEnemy> ListEnemyPosition = DataTable.Instance.ListEnemy();
	}
	
	// Update is called once per frame
	void Update () {
        // アニメーション中はreturnする
        if(seqFlag){
            print("アニメーション中なのでreturn");
            return;
        }

        if (ListEnemyAction.action == DataTable.EnemyActionNumber.MOVE)
        {
            // ゲーム開始して、とる行動
            // 移動
            // enemyObjectのx, yを取得
            // ListEnemyPositionから、xを取得して足す
            var ListPosition = ListEnemyAction.actionInfo.Split(',');

            int[] intArray = ListPosition.Select(li => 
            {
                int r = 0;
                int.TryParse(li, out r);
                return r;
            }).ToArray();

            // DOTweenで動かす
            seq = DOTween.Sequence();

            seq.Append(
                transform.DOMove(
                    new Vector3(intArray[0], intArray[1], 0),
                    1.0f
                )
                .OnStart(() =>
                {
                    seqFlag = true;
                })
            )
            //.InsertCallback(2.0f, () => {
            //        print("InsertCallback内");
            //        seqFlag = false;
            //    });
                .OnStepComplete(() => {
                    seqFlag = false;
                    // 動かした後に打つidを入れる
                    ListEnemyAction = DataTable.Instance.ListAction().Where(l => l.id == ListEnemyAction.nextId).FirstOrDefault();
                });
        }

        // 打つ
        if (ListEnemyAction.action == DataTable.EnemyActionNumber.SHOT)
        {
            print("打つ処理内に入った");
            EnemyShoterManager.Update();
        }

        // 打つ

        // 停まる

        // 移動


    }
}
