using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody;

    private Vector2 _horizontal;
    
    void Update()
    {
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _horizontal * _speed;

        Flip();
    }

    private void Flip()
    {
        if (!Mathf.Approximately(0, _horizontal.x))
        {
            transform.rotation = _horizontal.x < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }
    }

    public void SetMovement(InputAction.CallbackContext value)
    {
        _horizontal = value.ReadValue<Vector2>().normalized;

        if (_horizontal.y != 0)
        {
            _horizontal.x += Mathf.Sign(_horizontal.y) * 0.001f;
        }
    }
}
