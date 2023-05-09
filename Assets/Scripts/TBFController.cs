using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static EnemyBase;
using static UnityEngine.EventSystems.EventTrigger;

public enum BattleState {Start, Choosing, PlayerTurn, EnemyTurn, Busy, Done, Lose}

public class TBFController : MonoBehaviour
{
    public GameManager GameManager;
    public BattleState state;
    public GameObject turnIndicator;
    public EventTrigger trigger;
    public EventTriggerType eventType;
    public int enemies;
    public int totalObjects;
    public int turns;
    public List<BattleObject> orderList;
    public int currentIndex;
    public BattleObject currentTurn;

    public PlayerController Player;
    public StatsUI playerUI;
    public BattleObject mainGirl;
    public BattleObject currentGirl;
    public BattleObject selectedPlayer;
    public int playerTeamSpeed;
    private EnemySetController Enemy;
    public StatsUI enemyUI;
    public BattleObject selectedEnemy;
    public int enemyTeamSpeed;
    public int reward;
    public int exp;
    
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Enemy = GameObject.FindGameObjectWithTag("EnemySet").GetComponent<EnemySetController>();
        orderList = new List<BattleObject>();
        playerUI.statsUI.SetActive(false);
        enemyUI.statsUI.SetActive(false);
        turnIndicator.SetActive(false);
    }

    private void Update()
    {
        if (Player.state == PlayerController.State.Fighting)
        {
            if(state == BattleState.Choosing)
            {
                if (state != BattleState.Done)
                {
                    WhosTurn();
                    UpdatePlayerStats();
                }
            }
        }
    }

    public void NewTBFC()
    {
        reward = 0;
        exp = 0;
        //Debug.Log(Enemy.currentEnemyList.Count);
        enemies = Enemy.currentEnemyList.Count;
        orderList.Clear();
        currentIndex = -1;
        playerTeamSpeed = GetTeamSpeed(Player.order, true);
        enemyTeamSpeed = GetTeamSpeed(Enemy.currentEnemyList, false);
        totalObjects = 3 + Enemy.currentEnemyList.Count;
        turns = totalObjects;
        CreateOrder();
        Debug.Log("Setting Triggers");
        SetTrigger();
        Debug.Log("Setting Triggers is done");
        GetMainGirl();
        playerUI.statsUI.SetActive(true);
        enemyUI.statsUI.SetActive(true);
        turnIndicator.SetActive(true);
        //turnIndicator.transform.parent = currentTurn.gameObject.transform;
        //turnIndicator.transform.localPosition = new Vector2(0, -7);
    }

    private void WhosTurn()
    {
        currentIndex++;
        if (currentIndex >= totalObjects)
        {
            currentIndex = 0;
        }
        //Debug.Log("Current Index: " + currentIndex);
        //Debug.Log("Turns: " + turns);
        //if (currentIndex == turns) {
        //    foreach (GameObject obj in Enemy.currentEnemyList) {
        //        Destroy(obj);
        //    }
        //    currentGirl.girlBC.FightMenu.SetActive(false);
        //    Player.state= PlayerController.State.Idle;
        //}
        currentTurn = orderList[currentIndex];
        turnIndicator.transform.parent = currentTurn.gameObject.transform;
        turnIndicator.transform.localPosition = new Vector2(0, -7);
        //Debug.Log("CurrentTurn" + currentTurn);
        //Debug.Log("Current Turn: " + currentTurn.gameObject);
        if (currentTurn.player)
        {
            state = BattleState.PlayerTurn;
            currentGirl = currentTurn;
        }
        else if (!currentTurn.player)
        {
            state = BattleState.EnemyTurn;
            //Debug.Log(currentTurn.enemyBC.Attack((Random.Range(0, 1))));
            //Move(currentTurn.gameObject, currentGirl.gameObject);
            StartCoroutine(Move(currentTurn, mainGirl));
            mainGirl.girlBC.TakeDamage(currentTurn.enemyBC.Attack((Random.Range(0, 1))));
            //Dead();
        }
        //Debug.Log("Current State: " + state);
    }

    private void Lost()
    {
        enemyUI.statsUI.SetActive(false);
        playerUI.statsUI.SetActive(false);
        turnIndicator.SetActive(false);
        state = BattleState.Lose;
        GameManager.DeadUI.SetActive(true);
    }

    void GetMainGirl()
    {
        if (orderList[0].player)
        {
            mainGirl = orderList[0];
            selectedEnemy = orderList[1];
        }
        else
        {
            selectedEnemy = orderList[0];
            mainGirl = orderList[1];
        }
        UpdateEnemyStats();
        selectedPlayer = currentGirl = mainGirl;
        state = BattleState.Choosing;
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
        enemyUI.statsUI.SetActive(false);
        playerUI.statsUI.SetActive(false);
        turnIndicator.SetActive(false);
        state = BattleState.Start;
        foreach (GameObject obj in Enemy.currentEnemyList)
        {
            Destroy(obj);
        }
        Player.money += reward;
        Player.experiencePts += exp;
        Player.state = PlayerController.State.Idle;

        if(Player.inRoom)
        {
            Player.RoomReturn();
        }
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
        //Debug.Log("Attack1");
        //Debug.Log("Current State in Attack1: " + state);
        //state = BattleState.PlayerTurn;
        //Debug.Log(currentGirl.girlBC.GetAttack());
        if (Check())
        {
            currentGirl.gameObject.GetComponent<SpriteRenderer>().sprite = currentGirl.girlBC.AttackSprite;
            StartCoroutine(Move(currentGirl, selectedEnemy));
            selectedEnemy.enemyBC.takeDamage(currentGirl.girlBC.GetAttack());
            //currentGirl.gameObject.GetComponent<SpriteRenderer>().sprite = currentGirl.girlBC.idle;
        }
        //Move(currentGirl.gameObject, selectedEnemy.gameObject);
        //Debug.Log("Done Attack1");
        return;
    }

    public void Attack2()
    {
        //Debug.Log("Attack2");
        //Debug.Log("Current State in Attack2: " + state);
        //state = BattleState.PlayerTurn;
        //Debug.Log(currentGirl.girlBC.GetAttack());
        if (Check())
        {
            currentGirl.gameObject.GetComponent<SpriteRenderer>().sprite = currentGirl.girlBC.AttackSprite;
            StartCoroutine(Move(currentGirl, selectedEnemy));
            selectedEnemy.enemyBC.takeDamage(currentGirl.girlBC.GetAttack());
            //currentGirl.gameObject.GetComponent<SpriteRenderer>().sprite = currentGirl.girlBC.idle;
        }
        //Debug.Log("Done Attack2");
        return;
    }

    public bool Check()
    {
        if (currentGirl != selectedPlayer)
        {
            return false;
        }
        if (state != BattleState.PlayerTurn)
        {
            return false;
        }
        return true;
    }

    public void Select(BattleObject battleObject)
    {
        Debug.Log("Selected" + battleObject);
        if (battleObject.player)
        {
            //Debug.Log("Clicked on " + battleObject.gameObject.name);
            selectedPlayer = battleObject;
            UpdatePlayerStats();
        }
        else
        {
            selectedEnemy = battleObject;
            UpdateEnemyStats();
        }
        //Debug.Log(enemy);
    }

    public void UpdateEnemyStats()
    {
        //Debug.Log(selectedEnemy.enemyBC.GetLevel());
        enemyUI.nameText.text = selectedEnemy.enemyBC.enemyType.ToString();
        enemyUI.levelText.text = "Level: " + selectedEnemy.enemyBC.GetLevel().ToString();
        enemyUI.healthText.text = "Health: " + selectedEnemy.enemyBC.GetHealthAmount().ToString() + "/" + selectedEnemy.enemyBC.GetMaxHealthAmount().ToString();
        enemyUI.attackText.text = "Attack: " + selectedEnemy.enemyBC.GetAttack().ToString();
        enemyUI.defenseText.text = "Defense: " + selectedEnemy.enemyBC.GetDefense().ToString();
        enemyUI.speedText.text = "Speed: " + selectedEnemy.enemyBC.GetSpeed().ToString();
    }

    public void UpdatePlayerStats()
    {
        playerUI.nameText.text = selectedPlayer.girlBC.playerType.ToString();
        playerUI.levelText.text = "Level: " + selectedPlayer.girlBC.GetLevel().ToString();
        playerUI.healthText.text = "Health: " + selectedPlayer.girlBC.GetHealthAmount().ToString() + "/" + currentGirl.girlBC.GetMaxHealthAmount().ToString();
        playerUI.attackText.text = "Attack: " + selectedPlayer.girlBC.GetAttack().ToString();
        playerUI.defenseText.text = "Defense: " + selectedPlayer.girlBC.GetDefense().ToString();
        playerUI.speedText.text = "Speed: " + selectedPlayer.girlBC.GetSpeed().ToString();
    }

    public void SetTrigger()
    {
        //Debug.Log("Setting Trigger");
        EventTrigger trigger;
        EventTrigger.Entry entry;
        foreach (BattleObject e in orderList) {
            //Debug.Log(e);
            trigger = e.gameObject.GetComponent<EventTrigger>();
            entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick; ;
            entry.callback.AddListener((data) => { Select(e); });
            //Debug.Log(entry);
            trigger.triggers.Add(entry);
            //Debug.Log(trigger);
            Debug.Log(e.player);
        }
    }

    public void Rewards()
    {
        foreach (BattleObject e in orderList)
        {
            if (!e.player)
            {
                reward += e.enemyBC.GetMoney();
                exp += e.enemyBC.GetExp();
            }
        }
    }

    public void Dead()
    {
        if (selectedEnemy.enemyBC.IsDead())
        {
            enemies--;
            if(enemies== 0)
            {
                Win();
            }
            totalObjects--;
            turns--;
            orderList.Remove(selectedEnemy);
            selectedEnemy.gameObject.SetActive(false);
            foreach (BattleObject e in orderList)
            {
                if (!e.player)
                {
                    selectedEnemy = e;
                    break;
                }
            }
            UpdateEnemyStats();
        }
        if(currentGirl.girlBC.IsDead())
        {
            Lost();
        }
        state = BattleState.Done;
    }

    IEnumerator Move(BattleObject moving, BattleObject target)
    {
        SpriteRenderer sprite = target.gameObject.GetComponent<SpriteRenderer>();
        if (!moving.player)
        {
            yield return new WaitForSeconds(1);
        }
        state = BattleState.Busy;
        Vector2 start = moving.gameObject.transform.position;
        Vector2 targetPos = target.gameObject.transform.position + (moving.gameObject.transform.position - target.gameObject.transform.position).normalized * 2f;
        moving.gameObject.transform.position = targetPos;
        for (int i = 0; i < 5; i++)
        {
            sprite.color = new Color(255, 0, 0, 255);
            yield return new WaitForSeconds(.1f);
            sprite.color = new Color(255, 255, 255, 255);
            yield return new WaitForSeconds(.1f);
        }
        moving.gameObject.transform.position = start;
        currentGirl.gameObject.GetComponent<SpriteRenderer>().sprite = currentGirl.girlBC.idle;
        UpdateEnemyStats();
        Dead();
        yield return new WaitForSeconds(1);
        state = BattleState.Choosing;
    }

    IEnumerable Damage(BattleObject target)
    {
        SpriteRenderer sprite = target.gameObject.GetComponent<SpriteRenderer>();
        for (int i = 0; i < 5; i++)
        {
            sprite.color = new Color(255, 0, 0, 255);
            yield return new WaitForSeconds(.5f);
            sprite.color = new Color(255, 255, 255, 255);
        }
        yield return new WaitForSeconds(1f);
    }
}
