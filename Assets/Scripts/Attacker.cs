using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float movementSpeed = 0f;
    GameObject currentTarget;

    [SerializeField] float damage;

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

    public void StrikeCurrentTarget()
    {
        if (!currentTarget) return;
        Health health = currentTarget.GetComponent<Health>();

        if (health.GetHealth() > 0)
        {
            bool targetDead = health.DealDamage(damage);
            if (targetDead) { currentTarget = null; }
        }
        else { currentTarget = null; }
    }

    IEnumerator Pause(float time)
    {
        GetComponent<Animator>().speed = 0;
        yield return new WaitForSeconds(time);
        GetComponent<Animator>().speed = 1;
    }
}
