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
    private int level;
    public EnemyType enemyType;
    public State state;

    public enum EnemyType
    {
        Regular,
        Armor,
        Ice
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
        }
        state = State.WaitingForPlayer;
        level = 1;
    }

    public void SetLevel (int currentLevel)
    {
        if (currentLevel > level) { level = currentLevel; }
        healthMax += (10 * level);
        health = healthMax;
        baseAttack += (5 * level);
        baseSpeed += (3 * level);
        baseDefense += (5 * level);
    }

    public float GetHealthPercent()
    {
        return (float)health / healthMax;
    }

    public int GetHealthAmount()
    {
        return health;
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
}
