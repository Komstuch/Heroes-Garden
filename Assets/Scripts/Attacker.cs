using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f,2f)]
    [SerializeField] float movementSpeed = .7f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * movementSpeed);
        
    }
}
