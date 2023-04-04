using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float autoLoadNextLevel;
    void Awake()
    {
        if(autoLoadNextLevel<=0)
        {
            Debug.Log("AutoLoadNextlevel=0");
        }
        else
        {
            Invoke("LoadNextLevel", autoLoadNextLevel);
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(Application.loadedLevel + 1);
    }
    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void QuitBtnClicked()
    {
        Application.Quit();
    }
    public void PlayAgainBtnClicked(string name)
    {
        SceneManager.LoadScene(name);
    }

}

