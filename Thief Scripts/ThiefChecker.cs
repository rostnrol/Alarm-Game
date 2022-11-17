using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefChecker : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(_alarm.IncreaseVolume());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(_alarm.DecreaseVolume());
    }
}
