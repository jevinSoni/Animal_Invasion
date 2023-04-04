using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionController : MonoBehaviour
{
    public Slider volumeSlider,difficultySlider;
    public GameManager gameManager;
    private MusicManager musicManager;
    float volume;
    // Start is called before the first frame update
    void Start()
    {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerprefsManager.GetMasterVolume();
        difficultySlider.value = PlayerprefsManager.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        volume = volumeSlider.value;
        //musicManager.SetVolume(volumeSlider.value);
    }
    public void SaveAndExit()
    {
        PlayerprefsManager.SetDifficulty(difficultySlider.value);
        PlayerprefsManager.SetMasterVolume(volumeSlider.value);
        gameManager.LoadLevel("Start");
    }
    public void SetDefault()
    {
        volumeSlider.value = 0.8f;
        difficultySlider.value = 2f;
    }
}
