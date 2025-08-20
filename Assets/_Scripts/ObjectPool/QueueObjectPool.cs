using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueObjectPool : MonoBehaviour
{
    Queue<int> queue = new();
    private void Start()
    {
        for (int i = 1; i < 10; i++)
        {
            queue.Enqueue(i);
        }
        StartCoroutine(PrintNumbers());
    }

    IEnumerator PrintNumbers()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 9; i++)
        {
            Debug.Log($"Number {i + 1}: {queue.Dequeue()}");
        }
        Debug.Log($"Queue {queue.Dequeue()}");

    }
}
