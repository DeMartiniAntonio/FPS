using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Zadatak3 : MonoBehaviour
{
    [SerializeField] private int score = 0;
    [SerializeField] private int scoreIncrement = 1;
    [SerializeField] private GameObject collectiblePrefab;
    [SerializeField] private TMP_Text scoreText;


    private bool isGameOver = false;
    private void Start()
    {
        CreateColectables();

    }
    private void CreateColectables()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 position = new Vector3(UnityEngine.Random.Range(100f, 140f), 6.1f, UnityEngine.Random.Range(800f, 900f));
            Instantiate(collectiblePrefab, position, Quaternion.Euler(90, 0, 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out SphereCollider sphereCollider))
        {
            Debug.Log("uso");
            score += scoreIncrement;
            scoreText.text = $"Score: {score}";
            Destroy(other.gameObject);
        }
    }
}
