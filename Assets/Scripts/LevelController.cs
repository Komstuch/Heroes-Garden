using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField]int numberOfAttackers = 0;
    int currentLives;
    bool levelTimerFinished = false;
    [SerializeField] GameObject levelCompleteCanvas;
    [SerializeField] GameObject levelLostCanvas;
    [SerializeField] float nextLevelTimeDelay = 4.2f;
    [SerializeField] AudioClip winLevelSFX;
    [SerializeField] AudioClip loseLevelSFX;
    float masterVolume;

    private void Start()
    {
        levelCompleteCanvas.SetActive(false);
        levelLostCanvas.SetActive(false);
        currentLives = FindObjectOfType<Lives>().GetLives();
        masterVolume = PlayerPrefsManager.GetMasterVolume();
    }

    public void AttackerSpawned() { numberOfAttackers++; }
    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished && currentLives > 0)
        {
            StartCoroutine(HandleLevelCompletion());
        }
    }
    public void LevelTimerHasFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }

    IEnumerator HandleLevelCompletion()
    {
        MuteSound();
        levelCompleteCanvas.SetActive(true);
        AudioSource.PlayClipAtPoint(winLevelSFX, transform.position, masterVolume);
        yield return new WaitForSeconds(nextLevelTimeDelay);
        FindObjectOfType<LevelLoader>().LoadNextLevel();
    }
    
    public void HandleLoseCondition()
    {
        MuteSound();
        levelLostCanvas.SetActive(true);
        AudioSource.PlayClipAtPoint(loseLevelSFX, transform.position, masterVolume);
        Time.timeScale = 0;
    }

    private void MuteSound()
    {
        AudioSource audioSource = FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>();
        audioSource.Pause();
    }
}
