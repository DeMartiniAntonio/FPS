using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int healthE = 100; // Initial health of the enemy
    private int currentHp;
    [SerializeField] private int damagePerHit = 20; // Damage taken per hit
    [SerializeField] private Image maxHealth;
    private float nextDamageTime = 0f;

    private void Start()
    {
        currentHp = healthE;
        maxHealth.fillAmount = 1f;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Bullet bullet))
        {
            Destroy(bullet);
            currentHp -= damagePerHit;
            maxHealth.fillAmount = (float)currentHp / healthE;
            if (currentHp <= 0)
            {
                GameManager gameManager = FindObjectOfType<GameManager>();
                gameManager.Score(); 
                Destroy(gameObject);
            }
        }
        EnemyMovment enemyMovment = gameObject.GetComponent<EnemyMovment>();
        if (other.gameObject.TryGetComponent(out FireDetect fire))
        {
            enemyMovment.speed -= 2f;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        EnemyMovment enemyMovment = gameObject.GetComponent<EnemyMovment>();
        if (other.gameObject.TryGetComponent(out FireDetect fire))
        {
            enemyMovment.speed += 2f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Fire fire = gameObject.GetComponent<Fire>();
        
        if (other.gameObject.TryGetComponent(out FireDetect fireDetect))
        {
            Debug.Log("Fire detected in EnemyHealth script");
            if (Time.time >= nextDamageTime)
            {
                currentHp -=10;
                nextDamageTime = Time.time + 1f;
                maxHealth.fillAmount = (float)currentHp / healthE;
                if (currentHp <= 0)
                {
                    GameManager gameManager = FindObjectOfType<GameManager>();
                    gameManager.Score();
                    Destroy(gameObject);
                }
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            health.TakeDamage(20);
            Destroy(gameObject);
        }
    }
}
