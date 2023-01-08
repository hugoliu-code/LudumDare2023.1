using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemy : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] float speed;
    [SerializeField] Detector detector;
    Rigidbody2D rb;
    public GameObject currentTurret;
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        rb.velocity = direction*speed*Time.deltaTime;
        //if (currentTurret == null)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        //}
        //else
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, currentTurret.transform.position, speed * Time.deltaTime);
        //}

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Turret")
        {
            Turret turret = collision.collider.GetComponent<Turret>();
            if (turret)
            {
                turret.TurretTakeHit(10);
            }
        }
        if(collision.gameObject.tag == "Lure")
        {
            Lure lure = collision.collider.GetComponent<Lure>();
            if (lure)
            {
                lure.LureTakeHit(10);
            }
        }
    }
}
