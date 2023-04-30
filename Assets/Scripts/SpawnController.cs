using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private PlayerController Player;
    [Range(1, 100)]
    public int spawnChancePercent;
    private float spawnTime;
    private float spawnInterval = 1.0f;

    private EnemySetController Enemy;
    private float spawnDistance = 15f;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Enemy = GameObject.FindGameObjectWithTag("EnemySet").GetComponent<EnemySetController>();
        spawnTime = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.state == PlayerController.State.Moving)
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
        //Debug.Log(Player.currentLevel);
        if(Random.Range(1,100) <= spawnChancePercent)
        {
            Player.state = PlayerController.State.ChangePos;
            Player.PositionChangeUI.SetActive(true);
            if (Player.transform.position.x <= 65)
            {
                Enemy.newSpawn(new Vector2(pos.x + spawnDistance, pos.y - 2f), Player.currentLevel, false);
            }
            else
            {
                Enemy.newSpawn(new Vector2(pos.x + spawnDistance, pos.y - 2f), Player.currentLevel, true);
            }
        }
    }
}
