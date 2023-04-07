using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterBase;
using UnityEngine.TextCore.Text;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class EnemyBattleController : EnemyBase
{
    public int currentHealth;
    public int currentAttack;
    public int currentSpeed;
    public int currentDefense;
    public int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        base.SetEnemyBase(enemyType);
    }

    public void SetLevel(int level)
    {
        base.SetLevel(level);
        GetStats();
    }

    public void GetStats()
    {
        currentHealth = base.GetHealthAmount();
        currentAttack = base.GetAttack();
        currentSpeed = base.GetSpeed();
        currentDefense = base.GetDefense();
        currentLevel = base.GetLevel();
    }

    public int Attack(int attackNum)
    {
        return 0;
    }
}
