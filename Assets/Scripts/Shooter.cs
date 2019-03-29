using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;

    [SerializeField] AudioClip shootingSound;

    AttackerSpawner[] spawners;
    AttackerSpawner myLaneSpawner;

    Animator animator;

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        } else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if(myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Fire(float damage)
    {
        Instantiate(projectile, gun.transform.position, Quaternion.identity);
    }

    IEnumerator Pause(float time)
    {
        GetComponent<Animator>().speed = 0;
        yield return new WaitForSeconds(time);
        GetComponent<Animator>().speed = 1;
    }

    public void PlaySound()
    {
        AudioSource.PlayClipAtPoint(shootingSound, transform.position, 0.5f);
    }
}
