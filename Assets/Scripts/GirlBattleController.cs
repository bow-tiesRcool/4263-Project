using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GirlBattleController : CharacterBase
{
    public int currentLevel;
    public int currentHealth;
    public int currentEnergy;
    public int currentAttack;
    public int currentSpeed;
    public int currentDefense;
    public Button attackOne;
    public Button attackTwo;
    public GameObject FightMenu;

    private void Awake()
    {
        base.Start();
    }

    // Start is called before the first frame update
    void Start()
    {
        base.SetType(playerType, currentLevel);
        currentHealth = base.GetHealthAmount();
        currentEnergy = base.GetEnergyAmount();
        currentAttack = base.GetAttack();
        currentSpeed = base.GetSpeed();
        currentDefense = base.GetDefense();
        currentLevel = base.GetLevel();
        FightMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Myturn()
    {
        FightMenu.gameObject.SetActive(true);
    }

    public void NotMyTurn()
    {
        FightMenu.gameObject.SetActive(false);
    }

    public int Attack1()
    {
        return 5;
    }

    public int Attack2()
    {
        return 5;
    }
}
