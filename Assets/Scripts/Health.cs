using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] float health = 100f;

    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip deathSound;

    public void DealDamage(float damage)
    {
        AudioSource.PlayClipAtPoint(hitSound, transform.position, 0.5f);
        health -= damage;
        if (health <= 0)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position, 0.5f);
            Destroy(gameObject);
        }
    }
}
