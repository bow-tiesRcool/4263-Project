using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public void newSpawn(Vector2 pos, int currentLevel)
    {
        EnemySet.transform.position = pos;
        spawnCount = Random.Range(spawnAmountMin, spawnAmountMax + 1);
        currentEnemyList.Clear();
        for (int i = 0; i < spawnCount; i++)
        {
            currentEnemyList.Add(Instantiate(enemyList[Random.Range(0, enemyList.Length)]));
            currentEnemyList[i].transform.parent = EnemySet.transform;
            currentEnemyList[i].transform.localPosition = new Vector2(i * 1.5f, 0);
            currentEnemyList[i].GetComponent<EnemyBattleController>().SetLevel(currentLevel);
        }
    }
}
