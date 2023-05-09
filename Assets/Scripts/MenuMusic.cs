using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{

    public static MenuMusic menuMusicInstance;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (menuMusicInstance == null) {
            menuMusicInstance = this;

        }
        else { 
            Destroy(gameObject);
        }
    }
}
