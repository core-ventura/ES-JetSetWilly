using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    ILevelFactory factory = null;

    //Singleton implementation
    void Awake () {
        if(gameManager == null) {
            gameManager = this;
        DontDestroyOnLoad(gameObject);
        }
        else Destroy(this); 
    }

    public void LoadAtticScene()
    {
        factory = new TheAtticLevel();
        factory.GetSceneProperties().SceneName();
        SceneManager.LoadScene(1);
    }
    
    public void LoadMenuScene()
    {
        factory = new MainMenuLevel();
        factory.GetSceneProperties().SceneName();
        SceneManager.LoadScene(0);
    }
}
