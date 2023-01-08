using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemy : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] float speed;
    [SerializeField] Detector detector;

    public GameObject currentTurret;
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (currentTurret == null)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, currentTurret.transform.position, speed * Time.deltaTime);
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Turret turret = collision.collider.GetComponent<Turret>();
        if (turret)
        {
            turret.TurretTakeHit(10);
        }
    }
}
