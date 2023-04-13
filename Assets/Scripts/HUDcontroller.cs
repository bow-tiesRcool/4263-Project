using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDcontroller : MonoBehaviour
{
    private PlayerController Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SBH()
    {
        Player.ClearOrder();
        Player.order.Add(Player.sword);
        Player.order.Add(Player.bat);
        Player.order.Add(Player.hammer);
        Player.ChangePosition();
        Player.state = PlayerController.State.Fighting;
        Player.PositionChangeUI.SetActive(false);
        Player.TBFC.NewTBFC();
    }

    public void SHB()
    {
        Player.ClearOrder();
        Player.order.Add(Player.sword);
        Player.order.Add(Player.hammer);
        Player.order.Add(Player.bat);
        Player.ChangePosition();
        Player.state = PlayerController.State.Fighting;
        Player.PositionChangeUI.SetActive(false);
        Player.TBFC.NewTBFC();
    }

    public void HSB()
    {
        Player.ClearOrder();
        Player.order.Add(Player.hammer);
        Player.order.Add(Player.sword);
        Player.order.Add(Player.bat);
        Player.ChangePosition();
        Player.state = PlayerController.State.Fighting;
        Player.PositionChangeUI.SetActive(false);
        Player.TBFC.NewTBFC();
    }

    public void HBS()
    {
        Player.ClearOrder();
        Player.order.Add(Player.hammer);
        Player.order.Add(Player.bat);
        Player.order.Add(Player.sword);
        Player.ChangePosition();
        Player.state = PlayerController.State.Fighting;
        Player.PositionChangeUI.SetActive(false);
        Player.TBFC.NewTBFC();
    }

    public void BHS()
    {
        Player.ClearOrder();
        Player.order.Add(Player.bat);
        Player.order.Add(Player.hammer);
        Player.order.Add(Player.sword);
        Player.ChangePosition();
        Player.state = PlayerController.State.Fighting;
        Player.PositionChangeUI.SetActive(false);
        Player.TBFC.NewTBFC();
    }

    public void BSH()
    {
        Player.ClearOrder();
        Player.order.Add(Player.bat);
        Player.order.Add(Player.sword);
        Player.order.Add(Player.hammer);
        Player.ChangePosition();
        Player.state = PlayerController.State.Fighting;
        Player.PositionChangeUI.SetActive(false);
        Player.TBFC.NewTBFC();
    }
}
