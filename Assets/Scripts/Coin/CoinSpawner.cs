using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [HideInInspector] public List<GameObject> Coins = new List<GameObject>();

    private void Start()
    {
        for (int i = Coins.Count; i < 3; Coins.Add(_coin))
        {
            Vector3 coinPosition = new Vector3(Random.Range(0, gameObject.transform.localScale.x), gameObject.transform.localScale.y + 0.5f, Random.Range(0, gameObject.transform.localScale.z));
            Instantiate(_coin, coinPosition, Quaternion.identity);
        }
    }

    private void Update()
    {

        //for (int i = Coins.Count; i < 3; i++)
        //{
            //Vector3 coinPosition = new Vector3(Random.Range(0, gameObject.transform.localScale.x), 1.5f, Random.Range(0, gameObject.transform.localScale.z));
            StartCoroutine(TimeForSpawn());
            //Instantiate(_coin, coinPosition, Quaternion.identity);
            //Coins.Add(_coin);
        //}
    }

    private IEnumerator TimeForSpawn()
    {
        for (int i = Coins.Count; i < 3; Coins.Add(_coin))
        {
            Vector3 coinPosition = new Vector3(Random.Range(0, gameObject.transform.localScale.x), gameObject.transform.localScale.y + 0.5f, Random.Range(0, gameObject.transform.localScale.z));

            yield return new WaitForSeconds(10f);

            Instantiate(_coin, coinPosition, Quaternion.identity);
        }
    }
}
