using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMovePlatform : MonoBehaviour
{
    [SerializeField] private int _amplitude;
    [SerializeField] private float _frequecy;
    private GameManager _gameManager;

	// Use this for initialization
	private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	private void Update()
    {
        float x = Mathf.Cos(Time.time * _frequecy) * _amplitude;
        float y = transform.position.y;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);
    }
}
