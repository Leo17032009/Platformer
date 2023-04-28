using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, _lifeTime);
	}
}
