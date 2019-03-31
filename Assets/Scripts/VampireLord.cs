using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireLord : MonoBehaviour
{
    [SerializeField] AudioClip transformSound;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        Defender defender = otherObject.GetComponent<Defender>();

        if (defender)
        {
            if (defender.GetStatic() == true)
            {
                GetComponent<Animator>().SetTrigger("flyOver");
                AudioSource.PlayClipAtPoint(transformSound, transform.position, 0.5f);
            }
            else
            {
                GetComponent<Attacker>().Attack(otherObject);
            }
        }
    }
}
