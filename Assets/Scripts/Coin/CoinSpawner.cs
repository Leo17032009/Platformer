using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [HideInInspector] public int[] CountOfCoins;
    private Platform[] _platforms;
    private float _currentTime;
    private float _spawnTime = 10;

    private void Start()
    {
        _platforms = FindObjectsOfType<Platform>();

        CountOfCoins = new int[3];
        for (int i = 0; i < _platforms.Length; i++)
        {

            for (int j = 0; j < 3; j++)
            {
                Vector3 coinPosition = _platforms[i].transform.position + new Vector3(Random.Range(-_platforms[i].transform.localScale.x, _platforms[i].transform.localScale.x), 1.5f, Random.Range(-_platforms[i].transform.localScale.z, _platforms[i].transform.localScale.z));
                Instantiate(_coin, coinPosition, Quaternion.identity);
                CountOfCoins[i] += 2;
            }
        }
    }

    private void Update()
    {
        for (int i = 0; i < _platforms.Length; i++)
        {
            for (int j = CountOfCoins[i]; j < 3; j++)
            {
                _currentTime += Time.deltaTime;

                if (_currentTime >= _spawnTime)
                {
                    _currentTime = 0;
                    Vector3 coinPosition = _platforms[i].transform.position + new Vector3(Random.Range(-_platforms[i].transform.localScale.x, _platforms[i].transform.localScale.x), 1.5f, Random.Range(-_platforms[i].transform.localScale.z, _platforms[i].transform.localScale.z));
                    Instantiate(_coin, coinPosition, Quaternion.identity);
                    CountOfCoins[i] += 2;
                }
            }
        }
    }
}
