using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperMan : MonoBehaviour
{
    [SerializeField] private GameObject superman;
    [SerializeField] private Transform[] checkPoints;
    [SerializeField] private float hitPower;

    private float _supermanVelocity;
    private int _targetIndex;
    private Vector3 _supermanTarget;
    
    private void Start()
    {
        hitPower = 20f;
        _targetIndex = 0;
        _supermanVelocity = 5;
        _supermanTarget = checkPoints[_targetIndex].position;
    }

    private void Update()
    {
        superman.transform.position =
            Vector3.MoveTowards(superman.transform.position, _supermanTarget, Time.deltaTime * _supermanVelocity);

        if (superman.transform.position == _supermanTarget)
        {
            if (_targetIndex == checkPoints.Length - 1)
                _targetIndex = 0;
            else
                _targetIndex++;
            
            _supermanTarget = checkPoints[_targetIndex].position;
            superman.transform.LookAt(_supermanTarget);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("BadGuy"))
        {
            Vector3 direction = other.transform.position - superman.transform.position;
            other.rigidbody.AddForce(direction.normalized * hitPower, ForceMode.Impulse);
        }
    }
}
