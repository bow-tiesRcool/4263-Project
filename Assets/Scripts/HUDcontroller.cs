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
        Player.isChangePos = false;
        Player.PositionChangeUI.SetActive(false);
    }

    public void HSB()
    {
        Player.ClearOrder();
        Player.order.Add(Player.hammer);
        Player.order.Add(Player.sword);
        Player.order.Add(Player.bat);
        Player.ChangePosition();
        Player.isChangePos = false;
        Player.PositionChangeUI.SetActive(false);
    }
}
