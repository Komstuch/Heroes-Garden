using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] float health = 100f;

    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip deathSound;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void DealDamage(float damage)
    {
        AudioSource.PlayClipAtPoint(hitSound, transform.position, 0.5f);

        if(!GetComponent<Shooter>() && GetComponent<Defender>() ) // play animation if defender is passive
        {
            animator.SetTrigger("hit");
        }

        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position, 0.5f);
        animator.SetBool("isDead", true); // Play Death Animation
        GetComponent<BoxCollider2D>().enabled = false; // Disable collider co projectiles can pass through
        Destroy(gameObject, 1.5f);
    }
}
