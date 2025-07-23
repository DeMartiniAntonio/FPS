using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject firePrefab;
    public int damage = 10;
    public float slow = 4f;

    private void Start()
    {
        CreateFirePoints();
    }
    private void CreateFirePoints()
    {
        for (int i = 0; i < 2; i++)
        {
            Vector3 position = new Vector3(UnityEngine.Random.Range(100f, 140f), 5f, UnityEngine.Random.Range(800f, 900f));
            Instantiate(firePrefab, position, Quaternion.Euler(0, 0, 0));
        }
    }
}
