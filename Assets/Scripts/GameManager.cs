using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject DeadUI;
    // Start is called before the first frame update
    void Start()
    {
        DeadUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void returnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void restart()
    {
        SceneManager.LoadScene(1);
    }
}
