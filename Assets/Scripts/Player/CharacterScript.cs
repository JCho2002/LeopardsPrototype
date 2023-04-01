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

    private bool _canWalk = true;
    private float _rotation = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            _canWalk = !_canWalk;


        if(_canWalk)
        {
            _rotation += Input.GetAxis("Horizontal") * _rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, _rotation, 0f);

            float movement = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
            _char.Move(transform.forward * movement);


            //if (Input.GetKeyDown(KeyCode.Space) && _char.isGrounded) // Only jump if grounded
            //{
            //    float jumpVelocity = Mathf.Sqrt(_jumpHeight * -2f * Physics.gravity.y); // Calculate the jump velocity required to reach the maximum height
            //    _char.Move(Vector3.up * jumpVelocity * Time.deltaTime); // Apply the jump velocity to the player
            //}


            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    float jumpHeight = _char.velocity.y + Mathf.Sqrt(2f * Physics.gravity.magnitude * _jumpHeight);

            //    if (_char.isGrounded)
            //    {
            //        Vector3 jumpVelocity = new Vector3(0, jumpHeight, 0);
            //        _char.Move(jumpVelocity * Time.deltaTime);
            //    }
            //}


        }

        
    }


}
