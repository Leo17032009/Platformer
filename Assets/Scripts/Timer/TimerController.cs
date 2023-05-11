using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    private Text _timerText;
    private float _timeLeft = 120;
    private bool _isTimerOff = false;

    private void Start()
    {
        _timerText = GetComponent<Text>();
    }

    private void Update()
    {
        if (_isTimerOff == false)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;

                int minute = Mathf.FloorToInt(_timeLeft / 60);
                int seconds = Mathf.FloorToInt(_timeLeft % 60);

                _timerText.text = minute + ":" + seconds;
            }
            else
            {
                _isTimerOff = true;
            }
        }
    }
}
