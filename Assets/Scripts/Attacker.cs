using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float movementSpeed = 0f;

    [SerializeField] float health;

    GameObject currentTarget;

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * movementSpeed);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed (float speed)
    {
        movementSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) return;
        Health health = currentTarget.GetComponent<Health>();

        if (health)
        {
            bool targetDead = health.DealDamage(damage);
            if (targetDead) { currentTarget = null; }
        }
    }
}
