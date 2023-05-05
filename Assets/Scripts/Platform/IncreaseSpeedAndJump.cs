using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSpeedAndJump : MonoBehaviour
{
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }


	private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _playerController.MoveSpeed = 21;
            _playerController.JumpForce = 60;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _playerController.MoveSpeed = 7;
            _playerController.JumpForce = 20;
        }
    }
}
