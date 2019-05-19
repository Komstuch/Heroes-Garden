using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip[] clips;

    private void Start()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume * 0.2f;
    }

    private void OnLevelWasLoaded(int level)
    {
        audioSource.volume = PlayerPrefsManager.GetMasterVolume() * 0.2f;
        Debug.Log("Level ID: " + level);
        if (audioSource.clip != clips[level])
        {
            audioSource.clip = clips[level];
            audioSource.Play();
        }
        else
        {
            audioSource.UnPause();
        }
    }
}
