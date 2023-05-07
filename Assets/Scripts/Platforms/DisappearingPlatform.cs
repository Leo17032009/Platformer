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
                foreach (Renderer renderer in gameObject.GetComponentsInChildren<Renderer>())
                {
                    renderer.enabled = false;
                }

                foreach (Collider collider in gameObject.GetComponentsInChildren<BoxCollider>())
                {
                    collider.enabled = false;
                }
            }
            else
            {
                foreach (Renderer renderer in gameObject.GetComponentsInChildren<Renderer>())
                {
                    renderer.enabled = true;
                }

                foreach (Collider collider in gameObject.GetComponentsInChildren<BoxCollider>())
                {
                    collider.enabled = true;
                }
            }
        }
    }
}
