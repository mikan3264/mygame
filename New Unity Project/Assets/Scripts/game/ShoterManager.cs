using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 打つ用の玉を生成するだけのクラス

public class ShoterManager
{
    GameObject bulletObject;
    GameObject enemyObject;

    // objはsphere
    public ShoterManager(GameObject obj, GameObject obj1)
    {
        bulletObject = obj;
        enemyObject = obj1;
    }

	// Update is called once per frame
	public void Update () {
        GameObject.Instantiate(bulletObject, enemyObject.transform.position, Quaternion.identity);
    }
}
