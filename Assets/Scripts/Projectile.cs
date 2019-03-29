using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range (0f,10f)]
    [SerializeField] float projectileSpeed;
    [SerializeField] float projectileDamage;

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
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!explosionVFX) return;
        GameObject deathVFXObject = Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(deathVFXObject, 1f);
    }

    public float GetDamage() { return projectileDamage; }
}
