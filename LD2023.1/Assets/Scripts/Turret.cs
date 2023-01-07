using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float range;
    public GameObject bullet;
    public float fireRate;
    public float force;

    private float nextShot = 0f; 
    private Transform target;
    private Transform shootPoint;
    private bool detected = false;
    private Vector2 direction;


    // Start is called before the first frame update
    void Start()
    {
        shootPoint = gameObject.transform;
        InvokeRepeating("Target", 0f, 1f);
    }

    // Update is called once per frame
    private void Target()
    {
        float smallest = Mathf.Infinity;
        int smallestIndex = 0;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemies.Length; i++)
        {
            if(enemies[i] == null)
            {
                continue;
            }
            float next = Vector3.Distance(gameObject.transform.position, enemies[i].transform.position);
            if (next < smallest)
            {
                smallest = next;
                smallestIndex = i;
            }
        }
        if(enemies.Length > 0)
        {
            target = enemies[smallestIndex].transform;
            Debug.Log("Target Switched");
        }
    }
    void Update()
    {
        TurretAI();
    }

    private void TurretAI()
    {
        if(target == null)
        {
            Target();
            return;
        }
        Vector2 targetPos = target.position;
        direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, direction, range);
        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Enemy")
            {
                detected = true;
            }
            else
            {
                detected = false;
            }
        }
        if (detected)
        {
            if (Time.time > nextShot)
            {
                nextShot = Time.time + 1 / fireRate;
                shoot();
            }
        }
  
       
    }
     
    void shoot()
    {
        GameObject BulletIns = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(direction * force);
        Destroy(BulletIns, 1);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
        
    }
}
