using UnityEngine;

public class EnemySpown : MonoBehaviour
{
    [SerializeField] private EnemyMovment enemyPrefab;
    [SerializeField] private Transform spawnPoints;
    [SerializeField] private float spownRate = 3f;
    private float nextSpownTime = 0f;
    private Transform playerPostion;

    private void Start()
    {
        playerPostion = FindAnyObjectByType<PlayerMovement>().transform;

    }

    private void Update()
    {
        if (Time.time >= nextSpownTime)
        {
            EnemyMovment enemyMovment = Instantiate(enemyPrefab, spawnPoints.position, spawnPoints.rotation);
            nextSpownTime = Time.time + spownRate;
            enemyMovment.FolowPlayer(playerPostion);
        }
    }
}
