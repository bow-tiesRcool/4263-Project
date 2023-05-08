using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterBase;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyBase : MonoBehaviour
{
    private int healthMax;
    private int health;
    private int baseAttack;
    private int baseSpeed;
    private int baseDefense;
    public int level;
    public int money;
    public int exp;
    public EnemyType enemyType;
    public State state;

    public enum EnemyType
    {
        Regular,
        Armor,
        Ice,
        Boss
    }

    public enum State
    {
        WaitingForPlayer,
        Busy,
    }

    public void SetEnemyBase(EnemyType enemyType)
    {
        switch(enemyType)
        {
            case EnemyType.Regular:
                this.enemyType = EnemyType.Regular;
                healthMax = 10;
                health = healthMax;
                baseAttack = 5;
                baseSpeed = (3);
                baseDefense = 5;
                break;
            case EnemyType.Armor:
                this.enemyType = EnemyType.Armor;
                healthMax = 10;
                health = healthMax;
                baseAttack = 5;
                baseSpeed = (3);
                baseDefense = 5;
                break;
            case EnemyType.Ice:
                this.enemyType = EnemyType.Ice;
                healthMax = 10;
                health = healthMax;
                baseAttack = 5;
                baseSpeed = (3);
                baseDefense = 5;
                break;
            case EnemyType.Boss:
                this.enemyType = EnemyType.Boss;
                healthMax = 20;
                health = healthMax;
                baseAttack = 10;
                baseSpeed = (20);
                baseDefense = 25;
                break;
        }
        state = State.WaitingForPlayer;
        level = 1;
        money = 5;
        exp = 5;
    }

    public void SetLevel (int currentLevel)
    {
        Debug.Log("Current Level passed: "+currentLevel);
        if (currentLevel > 0) { level = currentLevel; }
        Debug.Log("Level change: " + level);
        healthMax += (10 * level);
        health = healthMax;
        baseAttack += (5 * level);
        baseSpeed += (3 * level);
        baseDefense += (5 * level);
        money += (5 * level);
        exp += (5 * level);
    }

    public float GetHealthPercent()
    {
        return (float)health / healthMax;
    }

    public int GetHealthAmount()
    {
        return health;
    }

    public int GetMaxHealthAmount()
    {
        return healthMax;
    }

    public void takeDamage(int amount)
    {
        health -= amount;
    }

    public int GetAttack() { return baseAttack; }
    public int GetDefense() { return baseDefense; }
    public int GetSpeed() { return baseSpeed; }
    public int GetLevel() { return level; }

    public bool IsDead()
    {
        return health <= 0;
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > healthMax)
        {
            health = healthMax;
        }
    }

    public int GetMoney() { return money; }
    public int GetExp() { return money; }
}
