using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 500f;
    [SerializeField] private float _explosionRadius = 5f;

    public void Boom(List<Rigidbody> rigidbodies)
    {
        foreach (Rigidbody rb in rigidbodies)
            rb.AddExplosionForce(_explosionForce, rb.transform.position, _explosionRadius);
    }
}
