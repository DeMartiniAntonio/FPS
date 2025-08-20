using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackObjectPoolManager : MonoBehaviour
{
    Stack<int> numberPool = new();
    private void Start()
    {
        for (int i = 1; i < 10; i++)
        {
            numberPool.Push(i);
        }
        StartCoroutine(PrintNumbers());

    }
    IEnumerator PrintNumbers() {
        yield return new WaitForSeconds(1);
        Debug.Log($"All numbers printed! {0} {numberPool.Pop()}");
    }
}
