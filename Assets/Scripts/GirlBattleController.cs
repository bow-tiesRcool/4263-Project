using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class GirlBattleController : CharacterBase
{
    public int currentLevel;
    public int addAttack;
    public int addSpeed;
    public int addDefense;
    public Button attackOne;
    public Button attackTwo;

    private void Awake()
    {
        base.Start();
    }

    // Start is called before the first frame update
    void Start()
    {
        addAttack = 0;
        addSpeed = 0;
        addDefense = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void load(int level)
    {
        //Debug.Log(level);
        currentLevel = level;
        base.SetType(playerType, currentLevel);
    }

    public int Attack1()
    {
        return GetAttack() + addAttack;
    }

    public int Attack2()
    {
        return GetAttack() + addAttack;
    }

    public void UpdateStats()
    {

    }

    public void PositionBuff(PosBuff posBuff)
    {
        switch (posBuff)
        {
            case PosBuff.BHS:
                addAttack = 5;
                addDefense = 5;
                addSpeed = 5;
                break;
            case PosBuff.BSH:
                addAttack = 5;
                addDefense = 5;
                addSpeed = 5;
                break;
            case PosBuff.HBS:
                addAttack = -10;
                addDefense = -5;
                addSpeed = 10;
                break;
            case PosBuff.HSB:
                addAttack = -10;
                addDefense = 10;
                addSpeed = -5;
                break;
            case PosBuff.SBH:
                addAttack = 10;
                addDefense = -5;
                addSpeed = -10;
                break;
            case PosBuff.SHB:
                addAttack = 5;
                addDefense = 5;
                addSpeed = 5;
                break;
        }
    }
}
