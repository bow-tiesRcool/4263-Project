using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class CharacterBase : MonoBehaviour
{
    private int healthMax;
    private int health;
    private int baseAttack;
    private int baseSpeed;
    private int baseDefense;
    private int energy;
    private int energyMax;
    private int level;
    public PlayerType playerType;

    public enum PlayerType
    {
        Sword,
        Hammer,
        Bat
    }

    public void Start()
    {
        level = 1;
        healthMax = 100;
        energyMax = 50;
        baseAttack = 20;
        baseSpeed = 25;
        baseDefense = 25;
    }


    public void SetType(PlayerType playerType, int currentLevel)
    {
        if (currentLevel > 1) { level = currentLevel; }
        switch (playerType)
        {
            case PlayerType.Sword:
                this.playerType = PlayerType.Sword;
                healthMax += 5 * level;
                health = healthMax;
                energyMax = 50;
                energy = energyMax;
                baseAttack += 5 * level;
                baseSpeed += 5 * level;
                baseDefense += 5 * level;
                break;
            case PlayerType.Hammer:
                this.playerType = PlayerType.Hammer;
                healthMax += 5 * level;
                health = healthMax;
                energyMax = 50;
                energy = energyMax;
                baseAttack += 5 * level;
                baseSpeed += 5 * level;
                baseDefense += 5 * level;
                break;
            case PlayerType.Bat:
                this.playerType = PlayerType.Bat;
                healthMax += 5 * level;
                health = healthMax;
                energyMax = 50;
                energy = energyMax;
                baseAttack += 5 * level;
                baseSpeed += 5 * level;
                baseDefense += 5 * level;
                break;
        }
    }

    public void LevelUp()
    {
        level++;
        healthMax += 100;
        health = healthMax;
        energyMax += 50;
        energy = energyMax;
        baseAttack += 20;
        baseSpeed += 25;
        baseDefense += 25;

        //switch (playerType)
        //{
        //    case PlayerType.Sword:
        //        healthMax = 100;
        //        health = healthMax;
        //        energyMax = 50;
        //        energy = energyMax;
        //        speed = 25;
        //        defense = 25;
        //        break;
        //    case PlayerType.Hammer:
        //        healthMax = 100;
        //        health = healthMax;
        //        energyMax = 50;
        //        energy = energyMax;
        //        speed = 25;
        //        defense = 25;
        //        break;
        //    case PlayerType.Bat:
        //        healthMax = 100;
        //        health = healthMax;
        //        energyMax = 50;
        //        energy = energyMax;
        //        speed = 25;
        //        defense = 25;
        //        break;
        //}
    }

    public float GetHealthPercent()
    {
        return (float)health / healthMax;
    }

    public int GetHealthAmount()
    {
        return health;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
    }

    public float GetEnergyPercent()
    {
        return (float)energy / energyMax;
    }

    public int GetEnergyAmount()
    {
        return energy;
    }

    public bool UseEnergy(int amount)
    {
        if(energy>= amount) {
            energy -= amount;
            return true;
        }
        return false;
    }

    public int GetAttack() { return baseAttack;}
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
