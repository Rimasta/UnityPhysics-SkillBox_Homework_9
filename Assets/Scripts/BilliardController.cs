using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilliardController : MonoBehaviour
{
    private float _hitForce;
    private Rigidbody _rigidbody;
    
    public void HitForward()
    {
        _rigidbody.AddForce(Vector3.forward * _hitForce, ForceMode.Impulse);
    }

    public void HitRight()
    {
        _rigidbody.AddForce(Vector3.right * _hitForce, ForceMode.Impulse);
    }

    public void HitLeft()
    {
        _rigidbody.AddForce(Vector3.left * _hitForce, ForceMode.Impulse);
    }

    public void HitBack()
    {
        _rigidbody.AddForce(Vector3.back * _hitForce,ForceMode.Impulse);
    }
    
    private void Start()
    {
        _hitForce = 3f;
        _rigidbody = GetComponent<Rigidbody>();
    }

    
}
