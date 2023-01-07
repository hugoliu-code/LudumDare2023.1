using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemy : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] float speed;
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed*Time.deltaTime);
    }
}
