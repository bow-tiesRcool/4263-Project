using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreMusic : MonoBehaviour
{

    public static StoreMusic storeMusicInstance;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (storeMusicInstance == null) {
            storeMusicInstance = this;

        }
        else { 
            Destroy(gameObject);
        }
    }

}

