using System;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    public float speed = 2f; 
    private Transform target; 
    public void FolowPlayer(Transform playerPostion)
    {
        this.target = playerPostion;
    }

    private void Update()
    {
       
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed* Time.deltaTime);
        transform.LookAt(target);
    }
}
