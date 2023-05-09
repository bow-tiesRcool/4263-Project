using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;

    private void Awake()
    {
        
        DontDestroyOnLoad(gameObject);

     
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
      
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
     
        audioSource.Stop();

        
        int sceneIndex = scene.buildIndex;
        if (sceneIndex >= 0 && sceneIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[sceneIndex];
            audioSource.Play();
        }
    }
}
