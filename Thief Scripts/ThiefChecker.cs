using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThiefChecker : MonoBehaviour
{
    [SerializeField] private UnityEvent _thiefEntered;
    [SerializeField] private UnityEvent _thiefLeft;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Thief thief))
        {
            _thiefEntered?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Thief thief))
        {
            _thiefLeft?.Invoke();
        }
    }
}
