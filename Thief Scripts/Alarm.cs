using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private ThiefChecker _thiefChecker;

    private Coroutine _volumeChange;
    private float _volumeChangeSpeed = 0.2f;

    private void Start()
    {
        _audio.volume = 0f;
    }

    public void LaunchAlarm(float targetVolume)
    {
        if (_volumeChange != null)
            StopCoroutine(_volumeChange);

        _volumeChange = StartCoroutine(ChangeVolume(targetVolume));
    }

    public void DecreaseVolume(float targetVolume)
    {
        if (_volumeChange != null)
            StopCoroutine(_volumeChange);

        _volumeChange = StartCoroutine(ChangeVolume(targetVolume));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        _audio.Play();

        while (_audio.volume != targetVolume)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, targetVolume, _volumeChangeSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
