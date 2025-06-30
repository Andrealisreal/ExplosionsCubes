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

    public void Boom(Vector3 explosionCenter, float explosionForce, float explosionRadius, float upwardsModifier)
    {
        Collider[] colliders = Physics.OverlapSphere(explosionCenter, explosionRadius);

        foreach (Collider collider in colliders)
            if (collider.TryGetComponent<Rigidbody>(out Rigidbody rigitbody))
                rigitbody.AddExplosionForce(explosionForce, explosionCenter, explosionRadius, upwardsModifier);
    }
}
