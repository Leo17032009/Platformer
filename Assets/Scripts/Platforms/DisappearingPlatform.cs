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

            if (gameObject.GetComponent<Renderer>().enabled)
            {
                gameObject.GetComponent<Renderer>().enabled = false;

                foreach (Collider collider in gameObject.GetComponent<BoxCollider>().GetComponents<Collider>())
                {
                    collider.enabled = false;
                }
            }
            else
            {
                gameObject.GetComponent<Renderer>().enabled = true;

                foreach (Collider collider in gameObject.GetComponent<BoxCollider>().GetComponents<Collider>())
                {
                    collider.enabled = true;
                }
            }
        }
    }
}
