using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerprefsManager : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficult_key";
    const string LEVEL_KEY = "level_unlocked";

    public static void SetMasterVolume(float volume)
    {
        if(volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
    }
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }
    public static void UnlockLevel(int level)
    {
        if(level <= Application.levelCount-1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(),1);
        }
    }
    public static bool IsLevelUnlock(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);
        if(level<=Application.levelCount-1)
        {
            return isLevelUnlocked;
        }
        else
        {
            return false;
        }
    }
    public static void SetDifficulty(float difficulty)
    {
        if(difficulty>=0 && difficulty<=3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.Log("Difficulty out of range");
        }
    }
    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}
