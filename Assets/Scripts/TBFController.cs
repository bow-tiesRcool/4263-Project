using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum BattleState {Start, Choosing, PlayerTurn, EnemyTurn, Won, Lost }

public class TBFController : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController Player;
    private EnemySetController Enemy;
    public BattleObject mainGirl;
    private BattleObject currentGirl;
    public EnemyBattleController selectedEnemy;

    public int totalObjects;
    public int turns;
    public int playerTeamSpeed;
    public int enemyTeamSpeed;
    
    public List<BattleObject> orderList;
    public int currentIndex;
    public BattleObject currentTurn;
    
    private Button attackOne;
    private Button attackTwo;
    
    public BattleState state;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Enemy = GameObject.FindGameObjectWithTag("EnemySet").GetComponent<EnemySetController>();
        orderList = new List<BattleObject>();
    }

    private void Update()
    {
        if (Player.state == PlayerController.State.Fighting)
        {
            if(state == BattleState.Choosing || state == BattleState.Start || state == BattleState.EnemyTurn)
            {
                WhosTurn();
            }
        }
    }

    public void NewTBFC()
    {
        Debug.Log(Player.order.Count);
        Debug.Log(Enemy.currentEnemyList.Count);
        orderList.Clear();
        currentIndex = 0;
        playerTeamSpeed = GetTeamSpeed(Player.order, true);
        enemyTeamSpeed = GetTeamSpeed(Enemy.currentEnemyList, false);
        totalObjects = 3 + Enemy.currentEnemyList.Count;
        turns = totalObjects;
        CreateOrder();
        GetMainGirl();
    }

    private void WhosTurn()
    {
        Debug.Log("Current Index: " + currentIndex);
        Debug.Log("Turns: " + turns);
        if (currentIndex == turns) {
            foreach (GameObject obj in Enemy.currentEnemyList) {
                Destroy(obj);
            }
            currentGirl.girlBC.FightMenu.SetActive(false);
            Player.state= PlayerController.State.Idle;
        }
        currentTurn = orderList[currentIndex];
        Debug.Log("Current Turn: " + currentTurn.gameObject);
        if (currentTurn.player)
        {
            state = BattleState.PlayerTurn;
            currentGirl.girlBC.FightMenu.SetActive(false);
            currentGirl = currentTurn;
            currentGirl.girlBC.FightMenu.SetActive(true);
        }
        else if (!currentTurn.player)
        {
            state = BattleState.EnemyTurn;
            mainGirl.girlBC.TakeDamage(currentTurn.enemyBC.Attack((Random.Range(0, 1))));
        }
            currentIndex++;
        Debug.Log("Current State: " + state);
    }

    private void Lost()
    {
        
    }

    void GetMainGirl()
    {
        if (orderList[0].player)
        {
            mainGirl = orderList[0];
            selectedEnemy = orderList[1].enemyBC;
        }
        else
        {
            selectedEnemy = orderList[0].enemyBC;
            mainGirl = orderList[1];
        }
        currentGirl = mainGirl;
        state = BattleState.Start;
    }

    void CreateOrder()
    {
        if (playerTeamSpeed >= enemyTeamSpeed)
        {
            if (Enemy.currentEnemyList.Count <= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    orderList.Add(new BattleObject(Player.order[i], Player.order[i].GetComponent<GirlBattleController>(), null, true));
                    if (i < Enemy.currentEnemyList.Count)
                    {
                        orderList.Add(new BattleObject(Enemy.currentEnemyList[i], null, Enemy.currentEnemyList[i].GetComponent<EnemyBattleController>(), false));
                    }
                }
            }
            else
            {
                for (int i = 0; i < Enemy.currentEnemyList.Count; i++)
                {
                    if (i < 3)
                    {
                        orderList.Add(new BattleObject(Player.order[i], Player.order[i].GetComponent<GirlBattleController>(), null, true));
                    }
                    orderList.Add(new BattleObject(Enemy.currentEnemyList[i], null, Enemy.currentEnemyList[i].GetComponent<EnemyBattleController>(), false));
                }
            }
        }

        else
        {
            if (Enemy.currentEnemyList.Count <= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i < Enemy.currentEnemyList.Count)
                    {
                        orderList.Add(new BattleObject(Enemy.currentEnemyList[i], null, Enemy.currentEnemyList[i].GetComponent<EnemyBattleController>(), false));
                    }
                    orderList.Add(new BattleObject(Player.order[i], Player.order[i].GetComponent<GirlBattleController>(), null, true));
                }
            }
            else
            {
                for (int i = 0; i < Enemy.currentEnemyList.Count; i++)
                {
                    orderList.Add(new BattleObject(Enemy.currentEnemyList[i], null, Enemy.currentEnemyList[i].GetComponent<EnemyBattleController>(), false));
                    if (i < 3)
                    {
                        orderList.Add(new BattleObject(Player.order[i], Player.order[i].GetComponent<GirlBattleController>(), null, true));
                    }
                }
            }
        }
    }


    int GetTeamSpeed(List<GameObject> gameObjects, bool player)
    {
        int speed = 0;
        if (player) {
            foreach (GameObject g in gameObjects) {
                speed += g.GetComponent<GirlBattleController>().GetSpeed();
            }
        }
        else
        {
            foreach (GameObject g in gameObjects)
            {
                speed += g.GetComponent<EnemyBattleController>().GetSpeed();
            }
        }
        return speed;
    }

    void Win()
    {
        Player.state = PlayerController.State.Idle;
    }

    IEnumerator sample()
    {
        yield return new WaitForSeconds(3);
        foreach (GameObject e in Enemy.currentEnemyList)
        {
            Destroy(e);
        }
        Player.state = PlayerController.State.Idle;
    }

    public void Attack1()
    {
        Debug.Log("Attack1");
        Debug.Log("Current State in Attack1: " + state);
        //state = BattleState.PlayerTurn;
        if (state != BattleState.PlayerTurn) {
            return;
        }
        WhosTurn();
        Debug.Log("Done Attack1");
        return;
    }

    public void Attack2()
    {
        Debug.Log("Attack2");
        Debug.Log("Current State in Attack2: " + state);
        //state = BattleState.PlayerTurn;
        if (state != BattleState.PlayerTurn)
        {
            return;
        }
        WhosTurn();
        Debug.Log("Done Attack2");
        return;
    }

    public void SelectEnemy(GameObject enemy)
    {
        selectedEnemy = enemy.GetComponent<EnemyBattleController>();
    }
}
