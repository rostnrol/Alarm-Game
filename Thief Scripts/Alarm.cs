using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private float _targetVolume;
    private bool _isEntered;
    private bool _hasLeft;
    private float _stayingTime;
    private float _volumeScale;
    private float _volumeChangeDuration = 10f;
    private float _coroutineDuration = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isEntered = true;
        _audio.Play();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isEntered = false;
        _hasLeft = true;
    }

    private void Update()
    {
        if (_isEntered)
        {
            StartCoroutine(IncreaseVolume(_coroutineDuration));
        }
        else if (_hasLeft)
        {
            StartCoroutine(DecreaseVolume(_coroutineDuration));
        }
    }

    private IEnumerator IncreaseVolume(float duration)
    {
        _targetVolume = 1f;
        _audio.volume = Mathf.MoveTowards(0.1f, _targetVolume, VolumeChange());

        yield return null;
    }

    private IEnumerator DecreaseVolume(float duration)
    {
        _targetVolume = 0f;
        _stayingTime = 0f;
        _audio.volume = Mathf.MoveTowards(_audio.volume, _targetVolume, VolumeChange());

        yield return null; 
    }

    private float VolumeChange()
    {
        _stayingTime += Time.deltaTime;

        return _volumeScale = _stayingTime / _volumeChangeDuration;
    }
}
