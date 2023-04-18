using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _pivot;
    [SerializeField] private Transform _playerModel;
    [SerializeField] private float _rotateSpeed;
    private Vector3 _offset;

	// Use this for initialization
	private void Start ()
    {
        _offset = _target.position - transform.position;

        _pivot.transform.position = _target.transform.position;
        _pivot.transform.parent = null;

        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	private void LateUpdate ()
    {
        _pivot.transform.position = _target.transform.position;

        float horizontal = Input.GetAxis("Mouse X") * _rotateSpeed;
        //float vertical = Input.GetAxis("Mouse Y") * _rotateSpeed;

        /*if (_pivot.eulerAngles.x < 60)
        {
            _pivot.Rotate(vertical, horizontal, 0);
        }*/
        //else
        //{
            _pivot.Rotate(0, horizontal, 0);
        //}

        float desiredYAngle = _pivot.eulerAngles.y;
        //float desiredXYangle = _pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(0, desiredYAngle, 0);
        transform.position = _target.position - (rotation * _offset);

        transform.LookAt(_target);
	}
}
