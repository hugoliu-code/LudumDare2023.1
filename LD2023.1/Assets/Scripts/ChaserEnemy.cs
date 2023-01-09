using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemy : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] float speed;
    [SerializeField] Detector detector;
    private Rigidbody2D rb;
    public GameObject currentTurret;
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (currentTurret != null)
        {
            if (currentTurret.transform.position.x < gameObject.transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);

            }
            else
            {

                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            if(playerTransform.position.x<gameObject.transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);

            }
            else
            {

                transform.localScale = new Vector3(1, 1, 1);
            }
        }

        if (currentTurret == null)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            rb.velocity = direction * speed * Time.deltaTime;
            
        }
        else
        {
            Vector2 direction = (currentTurret.transform.position - transform.position).normalized;
            rb.velocity = direction * speed * Time.deltaTime;
        }

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
        if (collision.gameObject.tag == "Cannon")
        {
            Turret turret = collision.collider.GetComponent<Turret>();
            if (turret)
            {
                turret.TurretTakeHit(10);
            }
        }
        if (collision.gameObject.tag == "Lure")
        {
            Lure lure = collision.collider.GetComponent<Lure>();
            if (lure)
            {
                lure.LureTakeHit(10);
            }
        }
        if (collision.gameObject.tag == "Bomb")
        {
            Bomb bomb = collision.collider.GetComponent<Bomb>();
            if (bomb)
            {
                bomb.BombTakeHit(10);
            }
        }
    }
}
