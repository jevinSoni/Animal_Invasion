using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    static MusicManager instance= null;
    public AudioClip[] levelMusicChangeArray;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = PlayerprefsManager.GetMasterVolume();
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            audioSource.clip = levelMusicChangeArray[1];
            audioSource.loop = true;
            audioSource.Play();
        }
    }
    private void OnEnable()
    {
        int y = SceneManager.GetActiveScene().buildIndex;

    }
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
