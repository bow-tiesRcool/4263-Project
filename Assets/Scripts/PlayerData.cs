using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    public int level;
    public int[] currentHealth;
    public int[] itemsCount;
    public int exp;
    public int money;
    public int location;

    public PlayerData(PlayerController Player)
    {
        level = Player.currentLevel;
        currentHealth = new int[3];
        itemsCount = new int[4];

        currentHealth[0] = Player.batBC.GetHealthAmount();
        currentHealth[1] = Player.swordBC.GetHealthAmount();
        currentHealth[2] = Player.hammerBC.GetHealthAmount();

        itemsCount[0] = Player.inventoryController.cigs;
        itemsCount[1] = Player.inventoryController.makeup;
        itemsCount[2] = Player.inventoryController.brush;
        itemsCount[3] = Player.inventoryController.mask;

        exp = Player.experiencePts;
        money = Player.money;

        location = Player.location;
    }
}
