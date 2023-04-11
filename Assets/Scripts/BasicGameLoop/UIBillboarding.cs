using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBillboarding : MonoBehaviour
{
    private Camera _mainCam;
    private Transform _transform;

    private void Awake()
    {
        _mainCam = Camera.main;
        _transform = this.transform;
    }

    private void Update()
    {
        _transform.rotation = _mainCam.transform.rotation;
    }
}
