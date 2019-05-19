using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume() * 0.1f;
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume * 0.1f;
    }

    private void OnLevelWasLoaded(int level)
    {
        Debug.Log("Level ID: " + level);
    }
}
