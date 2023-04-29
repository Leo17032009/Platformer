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
    [SerializeField] private AudioClip _clipOfJumping;
    [SerializeField] private AudioClip _clipOfCollectingCoin;
    [SerializeField] private AudioClip _clipOfDamage;

    private int _currentGold;

    [HideInInspector] public Vector3 LastCheckpointPosition;

    // Use this for initialization
    private void Start()
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
        _collectCoinSound.PlayOneShot(_clipOfCollectingCoin, 1.5f);
    }

    public void PlayDamageSound()
    {
        _backgroundSound.Pause();
        _damageSound.PlayOneShot(_clipOfDamage, 2f);
        _backgroundSound.Play();
    }

    public void PlayJumpSound()
    {
        _jumpSound.PlayOneShot(_clipOfJumping, 1.5f);
    }
}
