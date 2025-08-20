using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering;

public class ObjectPoolControler : MonoBehaviour
{
    public static ObjectPoolControler Instance { get; private set; }
    [SerializeField] private int pullSize = 10;
    [SerializeField] private GameObject prefab;
    List<GameObject> pulledObjects = new();
    List<GameObject> allPulledObjects = new();

    private void Awake()
    {
        Instance= this;

    }
    private void Start()
    {
        InitializePool();
    }
    private void InitializePool() {
        for (int i = 0; i < pullSize; i++) {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            pulledObjects.Add(obj);
            allPulledObjects.Add(obj);
        } 
    }

    public void RemoveFromPool() {
        if (pulledObjects.Count == 0) return;
        pulledObjects[0].SetActive(false);
        pulledObjects.RemoveAt(0);
    }


    public void ReturnToPool(GameObject obj) {
        obj.SetActive(true);
        pulledObjects.Add(obj);
    }


}
