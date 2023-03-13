using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBFController : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerController Player;
    private EnemySetController Enemy;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Enemy = GameObject.FindGameObjectWithTag("EnemySet").GetComponent<EnemySetController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player.isChangePos)
        {
            StartCoroutine("sample");
        }
    }

    IEnumerator sample()
    {
        yield return new WaitForSeconds(3);
        foreach (GameObject e in Enemy.currentEnemyList)
        {
            Destroy(e);
        }
        Player.isFighting= false;
        Destroy(gameObject);
    }

}
