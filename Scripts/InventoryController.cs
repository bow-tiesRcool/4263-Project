using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public int cigs;
    public int makeup;
    public int brush;
    public int mask;
    public PlayerController player;

    public void UseCig(GirlBattleController girl)
    {
        if (cigs > 0)
        {
            girl.Heal(50);
            cigs--;
        }
    }

    public void UseMakeup(GirlBattleController girl)
    {
        if (makeup > 0)
        {
            girl.Heal(50);
            makeup--;
        }
    }

    public void UseBrush(GirlBattleController girl)
    {
        if (brush > 0)
        {
            girl.Heal(50);
            brush--;
        }
    }

    public void UseMask(GirlBattleController girl)
    {
        if (mask > 0)
        {
            girl.Heal(50);
            mask--;
        }
    }



}
