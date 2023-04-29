using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private PlayerController _player;
    private bool _isRespawning;
    private Coroutine _respawningCoroutine;
    [SerializeField] private float _respawnLength;
    private Vector3 _respawnPoint;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
    }

    public void HurtPlayer()
    {
        Respawn();
    }

    public void Respawn()
    {
        if (_isRespawning == false)
        {
            _respawningCoroutine = StartCoroutine(RespawnCoroutine());
        }

        _respawningCoroutine = null;
    }

    public IEnumerator RespawnCoroutine()
    {
        _isRespawning = true;
        _player.gameObject.SetActive(false);

        yield return new WaitForSeconds(_respawnLength);

        _isRespawning = false;
        _player.transform.position = _respawnPoint;
        _player.gameObject.SetActive(true);
    }

    public void SetSpawnPoint(Vector3 newPosition)
    {
        _respawnPoint = newPosition;
    }
}
