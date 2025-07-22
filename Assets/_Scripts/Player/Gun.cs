using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform muzzle;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 1f;
    private float nextFireTime = 0f;

    private void Update()
    {

        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        GameObject createBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRb = createBullet.GetComponent<Rigidbody>();
        bulletRb.linearVelocity = firePoint.forward * 100f;
        nextFireTime = Time.time + fireRate;
    }
}
