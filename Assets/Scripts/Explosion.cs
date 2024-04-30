using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Explosion : MonoBehaviour
{
    public float ExplosionRadius { get; private set; } = 20f;
    public float ExplosionForce { get; private set; } = 200f;

    public void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObgect())
            explodableObject.AddExplosionForce(ExplosionForce, transform.position, ExplosionRadius);
    }

    public void MultiplierExplosionEffects(float multiplier)
    {
        ExplosionRadius *= multiplier;
        ExplosionForce *= multiplier;
    }

    private List<Rigidbody> GetExplodableObgect()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, ExplosionRadius);

        List<Rigidbody> units = new();

        units.AddRange(hits.Where(hit => hit.attachedRigidbody != null).Select(hit => hit.attachedRigidbody));

        return units;
    }
}