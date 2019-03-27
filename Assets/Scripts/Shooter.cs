using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;

    [SerializeField] AudioClip shootingSound;

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
