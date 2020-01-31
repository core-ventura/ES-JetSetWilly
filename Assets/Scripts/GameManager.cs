using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    //Singleton implementation
    void Awake () {
        if(gameManager == null) {
            gameManager = this;
        DontDestroyOnLoad(gameObject);
        }
        else Destroy(this); 
    }

    public void LoadGameplayScene()
    {
        SceneManager.LoadScene(1);
    }
    
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }
}
