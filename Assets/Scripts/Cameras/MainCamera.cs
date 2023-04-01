using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField]
    private float _lerpDuration = 200;
    [SerializeField]
    private GameObject[] _CamPOVs;
    [SerializeField]
    private FirstPersonCam cam1;


    private float _timer = 0;
    private int _position=1;
    private bool _isLerping = false;
    private Vector3 _destinationPosition;
    private Quaternion _destinationRotation;
    //private bool _pressed = false;


    private void Start()
    {
        _destinationPosition = _CamPOVs[0].transform.position;
        _destinationRotation = _CamPOVs[0].transform.rotation;
    }


    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E) && !_pressed)
        if (Input.GetKeyDown(KeyCode.E)) 

                SwitchCamera();

        if (_timer > 0)
            Timer();

        //if(_isLerping)
        Lerp(_CamPOVs[_position].transform.position, _CamPOVs[_position].transform.rotation);
    }

    private void SwitchCamera()
    {
        _position++;
        if (_position > _CamPOVs.Length - 1)
            _position = 0;

        _isLerping = true;
        _timer = _lerpDuration;

        cam1.ResetRotation();
    }

    private void Timer()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
            _isLerping = false;
    }

    private void Lerp(Vector3 position, Quaternion rotation)
    {
        float ratio = (_lerpDuration - _timer) / _lerpDuration;
        transform.position = Vector3.Lerp(transform.position, position, ratio);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, ratio);
    }
}
