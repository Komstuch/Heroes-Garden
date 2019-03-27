using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range (0f,10f)]
    [SerializeField] float projectileSpeed;
    [SerializeField] float projectileDamage;

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed);           
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<Health>();
        if (health) health.DealDamage(projectileDamage);

        if (collision.gameObject.GetComponent<Attacker>())
        {
            Debug.Log("collided with the attcker");
            Destroy(gameObject);
        }
    }

    public float GetDamage() { return projectileDamage; }
}
