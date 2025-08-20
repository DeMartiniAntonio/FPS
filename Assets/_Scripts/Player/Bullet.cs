using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        GetComponent<SphereCollider>().isTrigger= true;
        
    }

    private void OnEnable()
    {
        StartCoroutine(DestroyBulletAfterDelay(3f));
    }

    private IEnumerator DestroyBulletAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Gun.Instance.ReturnBulletsToPool(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Gun.Instance.ReturnBulletsToPool(gameObject);

        //Destroy(gameObject);
    }
}