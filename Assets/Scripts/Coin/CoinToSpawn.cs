using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinToSpawn : MonoBehaviour
{
    private CoinSpawner _coinSpawner;
    private string _platform;

    private void Start()
    {
        _coinSpawner = FindObjectOfType<CoinSpawner>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {

            if (_platform == "Platform")
            {
                _coinSpawner.CountOfCoins[0]--;
            }
            else if (_platform == "Platform1")
            {
                _coinSpawner.CountOfCoins[1]--;
            }
            else if (_platform == "Platform2")
            {
                _coinSpawner.CountOfCoins[2]--;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_platform == null)
        {
            if (other.gameObject.tag == "Platform")
            {
                _platform = "Platform";

            }
            else if (other.gameObject.tag == "Platform1")
            {
                _platform = "Platform1";
            }
            else if (other.gameObject.tag == "Platform2")
            {
                _platform = "Platform2";
            }
        }
    }
}
