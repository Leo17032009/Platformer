using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] private GameObject _pickupEffect;
    private GameManager _gameManager;
    [SerializeField] private int _coinCost;

	// Use this for initialization
	private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _gameManager.PlayCollectCoinSound();
            _gameManager.AddGold(_coinCost);
            Instantiate(_pickupEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        } 
    }
}
