using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BattleObject
{
    public GameObject gameObject;
    public GirlBattleController girlBC;
    public EnemyBattleController enemyBC;
    public bool player;

    public BattleObject(GameObject g, GirlBattleController p, EnemyBattleController e, bool player)
    {
        this.gameObject = g;
        this.girlBC = p;
        this.enemyBC = e;
        this.player = player;
    }
}
