using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinToSpawn : MonoBehaviour
{
    private CoinSpawner _coinSpawner;

    private void Start()
    {
        _coinSpawner = FindObjectOfType<CoinSpawner>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _coinSpawner.Coins.RemoveAt(0);
        }
    }
}
