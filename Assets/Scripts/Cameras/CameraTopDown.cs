using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTopDown : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;

    private Vector3 _offSet;
    void Start()
    {
        _offSet = _target.transform.position - transform.position;
    }

    void Update()
    {
        transform.position = _target.transform.position + _offSet;
    }
}
