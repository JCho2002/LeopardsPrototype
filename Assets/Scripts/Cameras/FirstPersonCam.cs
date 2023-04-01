using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCam : MonoBehaviour
{
    

    [SerializeField]
    private float _yLimit;
    [SerializeField]
    private float _rotationSpeed = 10;

    private float _xRotation = 0;
    private float _yRotation = 0;
    

    void Update()
    {
        _yRotation += Input.GetAxis("Horizontal")* _rotationSpeed*Time.deltaTime;
        _xRotation += -Input.GetAxis("Vertical") * _rotationSpeed * Time.deltaTime;

        _xRotation = Mathf.Clamp(_xRotation, -_yLimit, _yLimit);

        if (_yRotation > 359f)
            _yRotation = 0f;
        if (_yRotation < 0f)
            _yRotation = 359f;

        Debug.Log((_xRotation, " - ", _yRotation));
        transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0f);

        
    }

    public void ResetRotation() 
    {
        _xRotation = 0;
        _yRotation = 0;
    }
}
