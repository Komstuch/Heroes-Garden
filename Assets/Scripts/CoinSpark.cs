using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpark : MonoBehaviour
{
    [SerializeField] GameObject coinVFX;
    [SerializeField] AudioClip coinSound;

    public void Spark()
    {
        GameObject VFX = Instantiate(coinVFX, transform.position, Quaternion.identity) as GameObject;
        Destroy(VFX, 2f);

        if (!coinSound) { return; }
        else { AudioSource.PlayClipAtPoint(coinSound, transform.position, PlayerPrefsManager.GetMasterVolume());  }
    }
}
