using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minTimeBetweenSpawn = 3f;
    [SerializeField] float maxTimeBetweenSpawn = 5f;
    [SerializeField] float timeToSpawn;
    [SerializeField] Attacker[] attackerPrefabs;

    IEnumerator Start()
    {
        while (spawn)
        {
            timeToSpawn = Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
            yield return new WaitForSeconds(timeToSpawn);
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        int attackerId = Random.Range(0, attackerPrefabs.Length);

        Attacker currentAttacker = Instantiate(attackerPrefabs[attackerId], transform.position, Quaternion.identity) as Attacker;
        currentAttacker.transform.parent = transform;
    }

    public void StopSpawning()
    {
        spawn = false;
        StopAllCoroutines();
    }
}
