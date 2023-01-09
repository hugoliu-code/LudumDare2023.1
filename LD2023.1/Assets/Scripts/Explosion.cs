using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int explosionDamage;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayedDestroy());
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy)
            {
                enemy.EnemyTakeHit(explosionDamage);
            }
        }
        
    }

    private IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
