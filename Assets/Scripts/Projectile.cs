using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range (0f,10f)]
    [SerializeField] float projectileSpeed;
    [SerializeField] float projectileDamage;

    [SerializeField] AudioClip explosionSound;
    [SerializeField] GameObject explosionVFX;

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed);           
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<Health>();
        var attacker = collision.GetComponent<Attacker>();

        if (attacker && health)
        {
            health.DealDamage(projectileDamage);
            TriggerExplosionVFX();
            Destroy(gameObject,0.05f);
        }
    }

    private void TriggerExplosionVFX()
    {
        if (GetComponent<Fireball>())
        {           
            GetComponent<CircleCollider2D>().radius = 1.3f;
        }

        if (explosionVFX)
        {
            GameObject deathVFXObject = Instantiate(explosionVFX, transform.position, Quaternion.identity);
            Destroy(deathVFXObject, 2f);
        }

        if (explosionSound) { AudioSource.PlayClipAtPoint(explosionSound, transform.position); }      
    }

    public float GetDamage() { return projectileDamage; }
}
