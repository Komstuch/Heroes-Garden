using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = false;
    [SerializeField] float minTimeBetweenSpawn = 3f;
    [SerializeField] float maxTimeBetweenSpawn = 5f;
    [SerializeField] float timeToSpawn;
    [SerializeField] Attacker[] attackerPrefabs;

    IEnumerator Start()
    {
        timeToSpawn = Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
        yield return new WaitForSeconds(timeToSpawn);
        SpawnAttacker();
        spawn = true;
    }

    private void SpawnAttacker()
    {
        int attackerId = Random.Range(0, attackerPrefabs.Length);

        Attacker currentAttacker = Instantiate(attackerPrefabs[attackerId], transform.position, Quaternion.identity) as Attacker;
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
