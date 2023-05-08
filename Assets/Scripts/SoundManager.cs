using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager soundManagerInstance;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (soundManagerInstance == null) {
            soundManagerInstance = this;

        }
        else { 
            Destroy(gameObject);
        }
    }

}
