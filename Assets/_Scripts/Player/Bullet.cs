using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        GetComponent<SphereCollider>().isTrigger= true;
        Destroy(gameObject, 3f);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}