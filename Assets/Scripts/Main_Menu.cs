using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    //public GameManager GameManager;
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //GameManager.camera.SetActive(true);
        //GameManager.player.state = PlayerController.State.Idle;
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has ended Semester");
    }


}
