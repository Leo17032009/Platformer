﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material _checkpointOn;
    [SerializeField] private Material _checkpointOff;

    private HealthManager _healthManager;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _healthManager = FindObjectOfType<HealthManager>();
    }

    private void CheckpointOn()
    {
        Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();

        foreach(Checkpoint checkpoint in checkpoints)
        {
            checkpoint.CheckpointOff();
        }

        _renderer.material = _checkpointOn;
    }

    private void CheckpointOff()
    {
        _renderer.material = _checkpointOff;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _healthManager.SetSpawnPoint(transform.position);
            CheckpointOn();
        }
    }
}
