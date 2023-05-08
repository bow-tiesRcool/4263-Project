using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public enum PosBuff
{
    SBH,
    SHB,
    HSB,
    HBS,
    BHS,
    BSH
}

[System.Serializable]
public struct StatsUI
{
    public GameObject statsUI;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI speedText;
}

public class HUDcontroller : MonoBehaviour
{
    private PlayerController Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void SBH()
    {
        Player.changePosBuff(PosBuff.SBH);
        Player.ClearOrder();
        Player.order.Add(Player.hammer);
        Player.order.Add(Player.bat);
        Player.order.Add(Player.sword);
        Player.orderlocation = new Vector2[] { new Vector2(4, Player.hammeryPos.y), new Vector2(-3.75f, Player.batyPos.y), new Vector2(-12, Player.swordyPos.y) };
        Player.ChangePosition();
        Player.state = PlayerController.State.Fighting;
        Player.PositionChangeUI.SetActive(false);
        Player.TBFC.NewTBFC();
    }

    public void SHB()
    {
        Player.changePosBuff(PosBuff.SHB);
        Player.ClearOrder();
        Player.order.Add(Player.bat);
        Player.order.Add(Player.hammer);
        Player.order.Add(Player.sword);
        Player.orderlocation = new Vector2[] { new Vector2(4, Player.batyPos.y), new Vector2(-3.75f, Player.hammeryPos.y), new Vector2(-12, Player.swordyPos.y) };
        Player.ChangePosition();
        Player.state = PlayerController.State.Fighting;
        Player.PositionChangeUI.SetActive(false);
        Player.TBFC.NewTBFC();
    }

    public void HSB()
    {
        Player.changePosBuff(PosBuff.HSB);
        Player.ClearOrder();
        Player.order.Add(Player.bat);
        Player.order.Add(Player.sword);
        Player.order.Add(Player.hammer);
        Player.orderlocation = new Vector2[] { new Vector2(4, Player.batyPos.y), new Vector2(-3.75f, Player.swordyPos.y), new Vector2(-12, Player.hammeryPos.y) };
        Player.ChangePosition();
        Player.state = PlayerController.State.Fighting;
        Player.PositionChangeUI.SetActive(false);
        Player.TBFC.NewTBFC();
    }

    public void HBS()
    {
        Player.changePosBuff(PosBuff.HBS);
        Player.ClearOrder();
        Player.order.Add(Player.sword);
        Player.order.Add(Player.bat);
        Player.order.Add(Player.hammer);
        Player.orderlocation = new Vector2[] { new Vector2(4, Player.swordyPos.y), new Vector2(-3.75f, Player.batyPos.y), new Vector2(-12, Player.hammeryPos.y) };
        Player.ChangePosition();
        Player.state = PlayerController.State.Fighting;
        Player.PositionChangeUI.SetActive(false);
        Player.TBFC.NewTBFC();
    }

    public void BHS()
    {
        Player.changePosBuff(PosBuff.BHS);
        Player.ClearOrder();
        Player.order.Add(Player.sword);
        Player.order.Add(Player.hammer);
        Player.order.Add(Player.bat);
        Player.orderlocation = new Vector2[] { new Vector2(4, Player.swordyPos.y), new Vector2(-3.75f, Player.hammeryPos.y), new Vector2(-12, Player.batyPos.y) };
        Player.ChangePosition();
        Player.state = PlayerController.State.Fighting;
        Player.PositionChangeUI.SetActive(false);
        Player.TBFC.NewTBFC();
    }

    public void BSH()
    {
        Player.changePosBuff(PosBuff.BSH);
        Player.ClearOrder();
        Player.order.Add(Player.hammer);
        Player.order.Add(Player.sword);
        Player.order.Add(Player.bat);
        Player.orderlocation = new Vector2[] { new Vector2(4, Player.hammeryPos.y), new Vector2(-3.75f, Player.swordyPos.y), new Vector2(-12, Player.batyPos.y) };
        Player.ChangePosition();
        Player.state = PlayerController.State.Fighting;
        Player.PositionChangeUI.SetActive(false);
        Player.TBFC.NewTBFC();
    }
}
