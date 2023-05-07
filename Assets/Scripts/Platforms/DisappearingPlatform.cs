using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    [SerializeField] private float _disappearingTime;
    private float _currentTime;

    private void Start()
    {
        _currentTime = 0;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _disappearingTime)
        {
            _currentTime = 0;

            if (gameObject.GetComponentInChildren<Renderer>().enabled)
            {
                gameObject.GetComponentInChildren<Renderer>().enabled = false;

                foreach (Collider collider in gameObject.GetComponentInChildren<BoxCollider>().GetComponentsInChildren<Collider>())
                {
                    collider.enabled = false;
                }
            }
            else
            {
                gameObject.GetComponentInChildren<Renderer>().enabled = true;

                foreach (Collider collider in gameObject.GetComponentInChildren<BoxCollider>().GetComponentsInChildren<Collider>())
                {
                    collider.enabled = true;
                }
            }
        }
    }
}
