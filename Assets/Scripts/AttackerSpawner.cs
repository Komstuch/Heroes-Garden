using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = false;
    [SerializeField] float minTimeBetweenSpawn = 3f;
    [SerializeField] float maxTimeBetweenSpawn = 5f;
    [SerializeField] float timeToSpawn;
    [SerializeField] Attacker attacker;

    IEnumerator Start()
    {
        timeToSpawn = UnityEngine.Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
        yield return new WaitForSeconds(timeToSpawn);
        SpawnAttacker();
        spawn = true;
    }

    private void SpawnAttacker()
    {
        Attacker currentAttacker = Instantiate(attacker, transform.position, Quaternion.identity) as Attacker;
        currentAttacker.transform.parent = transform;
    }

    void Update()
    {
        if (spawn)
        {
            spawn = false;
            StartCoroutine(Start());
        }
    }
}
