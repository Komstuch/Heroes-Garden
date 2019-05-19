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

    private void Start()
    {
        levelCompleteCanvas.SetActive(false);
        levelLostCanvas.SetActive(false);
        currentLives = FindObjectOfType<Lives>().GetLives();
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
        levelCompleteCanvas.SetActive(true);
        AudioSource.PlayClipAtPoint(winLevelSFX, transform.position);
        yield return new WaitForSeconds(nextLevelTimeDelay);
        FindObjectOfType<LevelLoader>().LoadNextLevel();
    }
    
    public void HandleLoseCondition()
    {
        levelLostCanvas.SetActive(true);
        AudioSource.PlayClipAtPoint(loseLevelSFX, transform.position);
        Time.timeScale = 0;
    }
}
