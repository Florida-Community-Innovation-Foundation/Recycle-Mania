using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public void LoadLevel1()
    {
        SceneManager.LoadSceneAsync("level1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadSceneAsync("level2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadSceneAsync("level3");
    }
    
    public void LoadLevel4()
    {
        SceneManager.LoadSceneAsync("level4");
    }
}