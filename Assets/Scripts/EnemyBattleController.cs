using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterBase;
using UnityEngine.TextCore.Text;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnemyBattleController : EnemyBase
{

    // Start is called before the first frame update
    void Start()
    {
     
    }

    public void SetLevel(int level)
    {
        base.SetEnemyBase(enemyType);
        base.SetLevel(level);
    }

    public int Attack(int attackNum)
    {
        return GetAttack();
    }
}
