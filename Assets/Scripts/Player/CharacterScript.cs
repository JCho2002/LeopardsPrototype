using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    [SerializeField]
    private CharacterController _char;
    [SerializeField]
    private float _speed = 10;
    [SerializeField]
    private float _rotationSpeed = 10;
    [SerializeField]
    private float _jumpHeight = 2.0f;

    [SerializeField]
    private bool _stopOnEPress = true;
    [SerializeField]
    private float _gravityMultiplier;


    private bool _canWalk = true;
    private float _rotation = 0;
    private float _gravity = -9.81f;
    private float _velocity;
    private Vector3 _direction;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && _stopOnEPress )
            _canWalk = !_canWalk;

        ApplyGravity();
        if (_canWalk)
            ApplyMovement();


    }

    private void ApplyMovement()
    {
        _rotation += Input.GetAxis("Horizontal") * _rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, _rotation, 0f);

        float movement = Input.GetAxis("Vertical") * _speed * Time.deltaTime;

        _char.Move((transform.forward * movement)+_direction);
    }

    private void ApplyGravity()
    {
        if(_char.isGrounded && _velocity < 0.0f)
        {
            _velocity = -1;
        }
        else
        {
            _velocity += _gravity * _gravityMultiplier * Time.deltaTime;
        }
        _direction.y = _velocity;
        Debug.Log(_velocity);
    }
}
