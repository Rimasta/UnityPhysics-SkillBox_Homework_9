using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    [SerializeField] private float timeToExplosion;
    [SerializeField] private float explosionPower;
    [SerializeField] private float explosionRadius;
    private void Start()
    {
        timeToExplosion = 5f;
        explosionPower = 10f;
        explosionRadius = 30f;
    }

    private void Update()
    {
        timeToExplosion -= Time.deltaTime;
        if (timeToExplosion <= 0) Explosion();
    }

    private void Explosion()
    {
        Rigidbody[] rbObjects = FindObjectsOfType<Rigidbody>();
        foreach (var obj in rbObjects)
        {
            float localDistance = Vector3.Distance(transform.position, obj.transform.position);
            if (localDistance < explosionRadius)
            {
                Vector3 direction = obj.transform.position - transform.position;
                obj.AddForce(direction.normalized * explosionPower * (explosionRadius - localDistance), ForceMode.Impulse);
            }
        }

        timeToExplosion = 5f;
    }
}
