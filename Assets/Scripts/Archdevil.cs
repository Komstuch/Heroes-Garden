using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archdevil : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetTrigger(string trigger)
    {
        animator.SetTrigger(trigger);
    }

    public void MoveLeft()
    {
        int newYPosition = UnityEngine.Random.Range(1, 6);
        float newXPosition = transform.position.x-1f;
 
        transform.position = new Vector2(newXPosition, newYPosition);
        animator.SetTrigger("AD_Reappear");
        SwitchLanes(newYPosition);
    }

    private void SwitchLanes(int yPos)
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawners)
        {
            if(yPos == spawner.transform.position.y)
            {
                transform.parent = spawner.transform;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;

        if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
