using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic1 : MonoBehaviour
{

    public static BGMusic1 bgMusic1Instance;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (bgMusic1Instance == null) {
            bgMusic1Instance = this;

        }
        else { 
            Destroy(gameObject);
        }
    }

}
