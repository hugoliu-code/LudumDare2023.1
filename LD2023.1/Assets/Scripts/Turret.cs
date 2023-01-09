using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float range;
    public GameObject bullet;
    public float fireRate;
    public float force;
    public GameObject gun;
    public Transform shootPoint;

    private bool invincible;
    private float nextShot = 0f; 
    private Transform target;
    private bool detected = false;
    private Vector2 direction;

    [SerializeField] LayerMask enemyLayer;

    public float hitpoints;
    public float maxHitpoints;
    public TurretHealthBar healthBar;
    [SerializeField] float naturalLifespan;
    [SerializeField] AudioSource gunshot;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Target", 0f, 1f);
        hitpoints = maxHitpoints;
        healthBar.SetHealth(hitpoints, maxHitpoints);
    }
    private void Update()
    {
        if (hitpoints <= 0)
        {
            Destroy(gameObject);
        }
        healthBar.SetHealth(hitpoints, maxHitpoints);
        hitpoints -= (Time.deltaTime/naturalLifespan)*maxHitpoints;
        TurretAI();
    }
    public void TurretTakeHit(float damage)
    {
        if(invincible == false)
        {
            StartCoroutine(Invincible());
            hitpoints -= damage;

        }
    }

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
        target = enemies[smallestIndex].transform;
        }
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
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, direction, range, enemyLayer);
        detected = false;
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
            gun.transform.right = direction;
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
        gunshot.PlayOneShot(gunshot.clip);
        Destroy(BulletIns, 0.5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
        
    }
    private IEnumerator Invincible()
    {
        invincible = true;
        yield return new WaitForSeconds(0.75f);
        invincible = false;
    }
}
