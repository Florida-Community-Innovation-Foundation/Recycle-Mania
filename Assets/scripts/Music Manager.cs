using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;

    void Awake()
    {
       
        if (instance == null)
        {
           
            instance = this;

           
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            
            Destroy(gameObject);
        }

      
        audioSource = GetComponent<AudioSource>();
        
        
        audioSource.loop = true;
    }

    void Start()
    {
       
        audioSource.Play();
    }

    void OnEnable()
    {
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        if (scene.name == "level1" || scene.name == "level2" || scene.name == "level3" || scene.name == "level4")
        {
            audioSource.Stop(); 
        }
    }
}