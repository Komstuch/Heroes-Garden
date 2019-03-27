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
}
