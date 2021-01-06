using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTable : SingletonMonoBehaviour<DataTable> {

    //---------------------------------------------------------------------
    // 敵のデータ
    //---------------------------------------------------------------------
    public class DataEnemy
    {
        public int id { get; set; }
        public int hp { get; set; }
        public int action_start { get; set; }
    }

    // 敵の初期値
    private List<DataEnemy> listEnemy = new List<DataEnemy>
    {
        new DataEnemy{ id=0, hp=500, action_start=1 }
    };

    /// <summary>
    /// 外部からlistEnemyを取得するためのやつ
    /// </summary>
    public List<DataEnemy> ListEnemy() { return listEnemy; }
    //public List<DataEnemy> ListEnemy => listEnemy;
    //---------------------------------------------------------------------


    //---------------------------------------------------------------------
    // 敵の行動データ
    //---------------------------------------------------------------------
    public class DataEnemyAction
    {
        public int id { get; set; }
        public EnemyActionNumber action { get; set; }
        public string actionInfo { get; set; }
        public int nextId { get; set; }
    }

    private List<DataEnemyAction> listAction = new List<DataEnemyAction>
    {
        new DataEnemyAction{ id=0, action=EnemyActionNumber.MOVE, actionInfo="1,2", nextId=1},
        new DataEnemyAction{ id=1, action=EnemyActionNumber.MOVE, actionInfo="-1,-2", nextId=2},
        new DataEnemyAction{ id=2, action=EnemyActionNumber.SHOT, actionInfo="10,20", nextId=1},
        new DataEnemyAction{ id=3, action=EnemyActionNumber.MOVE, actionInfo="10,20", nextId=1},
        new DataEnemyAction{ id=4, action=EnemyActionNumber.MOVE, actionInfo="10,20", nextId=1},
    };

    public List<DataEnemyAction> ListAction()
    {
        return listAction;
    }

    public enum EnemyActionNumber
    {
        MOVE = 0,
        SHOT,
        STOP
    }
    //---------------------------------------------------------------------


    //---------------------------------------------------------------------
    // 玉のデータ
    //---------------------------------------------------------------------
    public class DataShot
    {
        public int id { get; set; }
        public int power { get; set; }
        public int target { get; set; }
        public string visual { get; set; }
        public double speed { get; set; }
    }

    private List<DataShot> listShot = new List<DataShot>
    {
        new DataShot{id=0, power=20, target=0, visual=null, speed=3.15}
    };

    public List<DataShot> ListShot()
    {
        return listShot;
    }

    public enum DataShotNumber
    {
        OWN = 0,
        Enemy
    }

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
