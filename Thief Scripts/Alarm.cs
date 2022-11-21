using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private ThiefChecker _thiefChecker;

    private Coroutine _volumeChange;

    private float _targetVolume;
    private float _currentVolume = 0f;
    private float _volumeChangeSpeed = 0.2f;

    private void Start()
    {
        _audio.volume = 0f;
    }

    private void Update()
    {
        LaunchAlarm();
    }

    private void LaunchAlarm()
    {
        if (_thiefChecker.HasEntered() == true)
        {
            if (_volumeChange != null)
                StopCoroutine(_volumeChange);

            _targetVolume = 1f;
            _volumeChange = StartCoroutine(ChangeVolume());
        }
        else if (_thiefChecker.HasLeft() == true)
        {
            if(_volumeChange != null)
            StopCoroutine(_volumeChange);

            _targetVolume = 0f;
            _volumeChange = StartCoroutine(ChangeVolume());
        }
    }

    private IEnumerator ChangeVolume()
    {
        _audio.Play();

        while (_audio.volume != _targetVolume)
        {
            _audio.volume = Mathf.MoveTowards(_currentVolume, _targetVolume, _volumeChangeSpeed * Time.deltaTime);

            _currentVolume = _audio.volume;

            yield return null;
        }
    }
}
