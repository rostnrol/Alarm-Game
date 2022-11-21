using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefChecker : MonoBehaviour
{
    private bool _hasEntered = false;
    private bool _hasLeft = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _hasEntered = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _hasEntered = false;
        _hasLeft = true;
    }

    public bool HasEntered() => _hasEntered;

    public bool HasLeft() => _hasLeft;
}
