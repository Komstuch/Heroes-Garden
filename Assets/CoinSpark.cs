using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpark : MonoBehaviour
{
    [SerializeField] GameObject coinVFX;

    public void Spark()
    {
        GameObject VFX = Instantiate(coinVFX, transform.position, Quaternion.identity) as GameObject;
        Destroy(VFX, 1f);
    }
}
