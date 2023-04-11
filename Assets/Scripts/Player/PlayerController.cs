using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravityScale;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _pivot;
    [SerializeField] private GameObject _playerModel;

    private CharacterController _characterController;
    private Vector3 _moveDirection;
    private GameManager _gameManager;

	// Use this for initialization
	private void Start ()
    {
        _characterController = GetComponent<CharacterController>();
        _gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	private void Update ()
    {
        //_moveDirection = new Vector3(Input.GetAxis("Horizontal") * _moveSpeed, _moveDirection.y, Input.GetAxis("Vertical") * _moveSpeed);
        float yStore = _moveDirection.y;
		_moveDirection = (transform.forward * Input.GetAxis("Vertical") * _moveSpeed) + (transform.right * Input.GetAxis("Horizontal"));
		_moveDirection = _moveDirection.normalized * _moveSpeed;
		_moveDirection.y = yStore;

		if (_characterController.isGrounded)
		{
			_moveDirection.y = 0f;

			if (Input.GetButtonDown("Jump") && _characterController.isGrounded)
			{
				//_gameManager.PlayJumpSound();
				_moveDirection.y = _jumpForce;
			}
		}

		_moveDirection.y = _moveDirection.y + (Physics.gravity.y * _gravityScale * Time.deltaTime);
		_characterController.Move(_moveDirection * Time.deltaTime);

		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) 
		{
			transform.rotation = Quaternion.Euler(0f, _pivot.rotation.eulerAngles.y, 0f);
			Quaternion newRotation = Quaternion.LookRotation(new Vector3(_moveDirection.x, 0f, _moveDirection.z));
			_playerModel.transform.rotation = Quaternion.Slerp(_playerModel.transform.rotation, newRotation, _rotateSpeed * Time.deltaTime);
		}

		_animator.SetBool("isGrounded", _characterController.isGrounded);
		_animator.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
	}
}
