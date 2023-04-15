using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text _coinsText;
    [SerializeField] private AudioSource _collectCoinSound;
    [SerializeField] private AudioSource _backgroundSound;
    [SerializeField] private AudioSource _damageSound;
    [SerializeField] private AudioSource _jumpSound;

    private int _currentGold;

    [HideInInspector] public Vector3 LastCheckpointPosition;

	// Use this for initialization
	private void Start ()
    {
        _backgroundSound.Play();
	}

    public void AddGold(int goldToAdd)
    {
        _currentGold += goldToAdd;
        _coinsText.text = "Coins: " + _currentGold;
    }

    public void PlayCollectCoinSound()
    {
        _collectCoinSound.Play();
    }

    public void PlayDamageSound()
    {
        _damageSound.Play();
    }

    public void PlayJumpSound()
    {
        _jumpSound.Play();
    }
}
