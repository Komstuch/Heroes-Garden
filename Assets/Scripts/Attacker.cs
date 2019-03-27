using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float movementSpeed = 0f;

    [SerializeField] float health;

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * movementSpeed);  
    }

    public void SetMovementSpeed (float speed)
    {
        movementSpeed = speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with smth");
        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        if (projectile)
        {
            float damageRecieved = projectile.GetDamage();
            health -= damageRecieved;
            if(health <= 0)
            {
                Debug.Log("Attacker: " + gameObject.name + " is dead!");
                Destroy(gameObject);
            }
        }
    }
}
