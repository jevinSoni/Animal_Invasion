using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    private Slider slider;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    public float levelSeconds;
    private GameManager gm;
    private GameObject winLabel;

    void Start()
    {
        winLabel = GameObject.Find("YouWin");
        gm = GameObject.FindObjectOfType<GameManager>();
        slider = gameObject.GetComponent<Slider>();
        audioSource = gameObject.GetComponent<AudioSource>();
        winLabel.SetActive(false);
    }

    void Update()
    {

        slider.value = Time.timeSinceLevelLoad / levelSeconds;
        if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel)
        {
            DestroyAllTaggedObject();
            HandleWinCondition();
        }
    }
    //destroy all object if you win
    void DestroyAllTaggedObject()
    {
        GameObject[] allTaggedObjectArray=GameObject.FindGameObjectsWithTag("DestroyOnWin");
        for (int i = 0; i < allTaggedObjectArray.Length; i++)
        {
            Destroy(allTaggedObjectArray[i]);
        }
    }
    private void HandleWinCondition()
    {
        audioSource.Play();
        winLabel.SetActive(true);
        Invoke("LoadNextLevel", audioSource.clip.length);
        isEndOfLevel = true;
    }

    void LoadNextLevel()
    {
        gm.LoadNextLevel();
    }
}
