using UnityEngine;

public class Explosin : MonoBehaviour
{
    public float radius = 5f;
    public float power = 10f;
    [SerializeField] private float health = 30f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            Explode();
        }
    }
    private void Explode()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPos, radius, 3.0f);
            }
        }
    }
}
