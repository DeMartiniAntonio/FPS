using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Collectableanimation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f;
    [SerializeField] private float bobbingSpeed = 2f;
    [SerializeField] private float bobbingHeight = 0.5f;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float timer = 0f;
    [SerializeField] private int maxHealPoints = 20;
    private int currentHealPoints;
    private int healAmount = 1;
    [SerializeField] private float healRate = 1f;
    private float nextHealTime = 0f;
    [SerializeField] private TMP_Text healText;
    private bool isHealing = false;

    private void Start()
    {
        currentHealPoints = maxHealPoints;
        startPosition = transform.position;
        endPosition = startPosition + Vector3.up * bobbingHeight;
        healText.text = $"Heal amount: {currentHealPoints}";

    }
    private void Update()
    {

        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        timer += Time.deltaTime * bobbingSpeed;
        float t = Mathf.PingPong(timer, 1f);
        transform.position = Vector3.Lerp(startPosition, endPosition, t);

    }

    private void OnTriggerStay(Collider other)
    {
        isHealing = true;
        if (other.gameObject.TryGetComponent(out Health health))
        {
            if (Time.time >= nextHealTime)
            {

                if (currentHealPoints > 0)
                {
                    health.Heal(healAmount);
                    currentHealPoints--;
                    nextHealTime = Time.time + healRate;
                    healText.text = $"Heal amount: {currentHealPoints}";
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.TryGetComponent(out Health health))
        {
            StartCoroutine(HealhealPoint());
        }
    }

    private IEnumerator HealhealPoint()
    {
        for (int i = currentHealPoints; i < maxHealPoints; i++)
        {
            currentHealPoints++;
            nextHealTime = Time.time + healRate;
            healText.text = $"Heal amount: {currentHealPoints}";
            yield return new WaitForSeconds(healRate);

        }
    }
}


