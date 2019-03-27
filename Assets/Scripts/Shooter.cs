using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;

    public void Fire(float damage)
    {
        Instantiate(projectile, gun.transform.position, Quaternion.identity);
        return;
    }

    IEnumerator Pause(float time)
    {
        GetComponent<Animator>().speed = 0;
        yield return new WaitForSeconds(time);
        GetComponent<Animator>().speed = 1;
    }
}
