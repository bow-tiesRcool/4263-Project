using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnemySetController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemyList;
    public int spawnAmountMin;
    public int spawnAmountMax;

    public GameObject EnemySet;
    public List<GameObject> currentEnemyList;
    private int spawnCount;


    void Start()
    {
        EnemySet = GameObject.FindGameObjectWithTag("EnemySet");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void newSpawn(Vector2 pos, int currentLevel, bool nearDoor)
    {
        EnemySet.transform.position = pos;
        if (nearDoor)
        {
            spawnCount = Random.Range(spawnAmountMin, spawnAmountMax - 1);
        }
        else
        {
            spawnCount = Random.Range(spawnAmountMin, spawnAmountMax + 1);
        }
        currentEnemyList.Clear();
        for (int i = 0; i < spawnCount; i++)
        {
            currentEnemyList.Add(Instantiate(enemyList[Random.Range(0, enemyList.Length)]));
            currentEnemyList[i].transform.parent = EnemySet.transform;
            currentEnemyList[i].transform.localPosition = new Vector2(i * 8f, 0);
            currentEnemyList[i].GetComponent<EnemyBattleController>().SetLevel(currentLevel + Random.Range(0, 2));
            //Debug.Log(currentLevel + Random.Range(0, 2));
        }
    }

    public void newBossSpawn(Vector2 pos, int currentLevel)
    {
        currentEnemyList.Add(Instantiate(enemyList[0]));
        currentEnemyList[0].transform.parent = EnemySet.transform;
        currentEnemyList[0].transform.localPosition = new Vector2(0, 0);
        currentEnemyList[0].GetComponent<EnemyBattleController>().SetLevel(currentLevel);
    }
}
