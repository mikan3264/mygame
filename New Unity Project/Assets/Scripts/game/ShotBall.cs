using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBall : MonoBehaviour {

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        var p = transform.position;
        p.x += 0.5f;
        transform.position = p;

        // hit_judgeのオブジェクトを取得
        var box = GameObject.FindGameObjectWithTag("hit_judge");

        if (box == null)
        {
            print("boxに値が入っていません");
        }

        else
        {
            // hit_judgeのコンポーネント取得（これはスプライトレンダラーのサイズを取得）
            var _sprite = box.GetComponent<SpriteRenderer>();

            if (_sprite != null)
            {

                // スプライトレンダラーの高さと幅を取得
                var boxSize = new Vector2(_sprite.bounds.size.x, _sprite.bounds.size.y);

                // スプライトレンダラーの座標を取得
                var boxPos = new Vector2(box.transform.position.x, box.transform.position.y);

                // sphereのコンポーネント取得
                var _sphere = GetComponent<SpriteRenderer>();

                if (_sphere != null)
                {
                    // sphereの高さと幅を取得
                    var sphereSize = new Vector2(_sphere.bounds.size.x, _sphere.bounds.size.y);

                    // sphereの座標を取得
                    var spherePos = new Vector2(_sphere.transform.position.x, _sphere.transform.position.y);

                    if (!isHit(boxPos, boxSize, spherePos, sphereSize))
                    {
                        print("玉をデストロイします");
                        Destroy(this.gameObject);
                    }
                        
                }

            }

        }

    }

    bool isHit(Vector2 pos0, Vector2 size0, Vector2 pos1, Vector2 size1)
    {

        // boxの左上の座標を計算
        var boxLeft = pos0 - size0 / 2;

        // boxの右上の座標を計算
        var boxRight = new Vector2(boxLeft.x + size0.x, boxLeft.y);

        // sphereの左上の座標を計算
        var sphereLeft = pos1 - size1 / 2;

        // sphereの右上を座標を計算
        var sphereRight = new Vector2(sphereLeft.x + size1.x, sphereLeft.y);


        // 当たり判定処理をする
        if (
            boxLeft.x < sphereRight.x && sphereLeft.x < boxRight.x
            //&&
            //boxLeft.y < sphereRight.y && sphereLeft.y < boxRight.y
            )
        {
            //print("枠内に球がある");
            return true;
        }

        //print("枠外に球が出た");
        return false;
    }
}





