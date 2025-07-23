using TMPro;
using UnityEngine;

public class HealPoint : MonoBehaviour
{

    [SerializeField] private GameObject healPrefab;
    private void Start()
    {
        CreateHealPoints();
    }
    private void CreateHealPoints()
    {
        for (int i = 0; i < 2; i++)
        {
            Vector3 position = new Vector3(UnityEngine.Random.Range(100f, 140f), 5f, UnityEngine.Random.Range(800f, 900f));
            Instantiate(healPrefab, position, Quaternion.Euler(0, 0, 0));
        }
    }
}
