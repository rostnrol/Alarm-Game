using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private float _targetVolume;
    private float _currentVolume = 0f;
    private float _volumeChangeSpeed = 0.1f;
    private float _volumeChangeStep = 0.0005f;

    private void Start()
    {
        _audio.volume = 0f;
    }

    public IEnumerator IncreaseVolume()
    {
        _audio.Play();
        _targetVolume = 1f;

        while (_audio.volume < _targetVolume)
        {
            _audio.volume = Mathf.MoveTowards(_currentVolume += _volumeChangeStep, _targetVolume, _volumeChangeSpeed * Time.deltaTime);
            _currentVolume = _audio.volume;

            yield return null;
        }
    }

    public IEnumerator DecreaseVolume()
    {
        _targetVolume = 0f;

        while (_audio.volume > _targetVolume)
        {
            _audio.volume = Mathf.MoveTowards(_currentVolume -= _volumeChangeStep, _targetVolume, _volumeChangeSpeed * Time.deltaTime);
            _currentVolume = _audio.volume;

            yield return null;
        }
    }
}
