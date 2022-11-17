using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Animator _walking;

    private void Update()
    {
        _walking.enabled = false;

        if (Input.GetKey(KeyCode.D))
        {
            _walking.enabled = true;
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _walking.enabled = true;
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
        }
    }
}
