using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    Lives lives;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lives = FindObjectOfType<Lives>();
        lives.TakeLife();
        Destroy(collision.gameObject);
    }
}
