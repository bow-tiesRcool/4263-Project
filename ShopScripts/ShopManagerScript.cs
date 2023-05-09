using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{
    
    public int[,] shopItems = new int [6,6];
    public float dollars;
    public Text DollarsTXT;

    void Start()
    {
        DollarsTXT.text = "Dollars:" + dollars.ToString();

        //ID's
        shopItems[1,1] = 1;
        shopItems[1,2] = 2;
        shopItems[1,3] = 3;
        shopItems[1,4] = 4;
        shopItems[1,5] = 5;

        //Price
        shopItems[2,1] = 5;
        shopItems[2,2] = 5;
        shopItems[2,3] = 15;
        shopItems[2,4] = 20;
        shopItems[2,5] = 30;

        //Quantity
        shopItems[3,1] = 0;
        shopItems[3,2] = 0;
        shopItems[3,3] = 0;
        shopItems[3,4] = 0;
        shopItems[3,5] = 0;

    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("ShopEvent").GetComponent<EventSystem>().currentSelectedGameObject;

        if (dollars >=shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            dollars -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            DollarsTXT.text = "dollars:" + dollars.ToString();
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
        }
    }
}
