using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public GameObject DeadUI;
    public GameObject PauseUI;
    public bool pause;
    //public GameObject camera;

    private void Awake()
    {
        //camera.SetActive(false);
        //DontDestroyOnLoad(this.gameObject);
        //if (GameObject.Find(gameObject.name)
        //         && GameObject.Find(gameObject.name) != this.gameObject)
        //{
        //    Destroy(GameObject.Find(gameObject.name));
        //}
    }
    // Start is called before the first frame update
    void Start()
    {
        DeadUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
            {
                PauseUI.SetActive(true);
                pause = true;
                Time.timeScale = 0;
            }
            else
            {
                PauseUI.SetActive(false);
                pause = false;
                Time.timeScale = 1;
            }
        }
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void restart()
    {
        SceneManager.LoadScene(1);
    }

    public void SavePlayer()
    {
        SaveController.SavePlayer(player);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveController.LoadPlayer();
        player.load(data);
    }
}
