using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    const float MIN_DIFFICULTY = 0;
    const float MAX_DIFFICULTY = 2;

    public static void SetMasterVolume(float volume)
    {
        if (volume <= MAX_VOLUME && volume >= MIN_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Volume out of range!");
        }  
    }

    public static float GetMasterVolume()
    {
        if (PlayerPrefs.HasKey(MASTER_VOLUME_KEY)) { return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY); }
        else { return 1f; }
        
    }

    public static void SetDifficulty(int difficulty)
    {
        if(difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
        {
            PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty out of range");
        }
        
    }

    public static int GetDifficulty()
    {
        if (PlayerPrefs.HasKey(DIFFICULTY_KEY)) { return PlayerPrefs.GetInt(DIFFICULTY_KEY); }
        else { return 1; }
         }
}
