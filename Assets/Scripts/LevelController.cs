using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    [SerializeField] GameObject levelCompleteCanvas;
    [SerializeField] float nextLevelTimeDelay = 4.2f;
    [SerializeField] AudioClip winLevelSFX;

    private void Start()
    {
        levelCompleteCanvas.SetActive(false);
    }

    public void AttackerSpawned() { numberOfAttackers++; }
    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished)
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
}
