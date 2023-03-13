using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private PlayerController Player;
    [Range(1, 100)]
    public int spawnChancePercent;
    private float spawnTime;
    private float spawnInterval = 1.0f;

    private EnemySetController Enemy;
    private float spawnDistance = 3.5f;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Enemy = GameObject.FindGameObjectWithTag("EnemySet").GetComponent<EnemySetController>();
        spawnTime = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.isMoving)
        {
            spawnTime -= Time.deltaTime;
            
            if(spawnTime <= 0.0f )
            {
                spawnEnemy(Player.GetPosition());
                spawnTime = 1.0f;
            }
        }
    }

    void spawnEnemy(Vector2 pos)
    {
        if(Random.Range(1,100) <= spawnChancePercent)
        {
            Player.isMoving = false;
            Player.isFighting= true;
            Player.isChangePos = true;
            Player.PositionChangeUI.SetActive(true);
            Enemy.newSpawn( new Vector2(pos.x + spawnDistance, pos.y));
            Instantiate(Player.TBFC);
        }
    }
}
