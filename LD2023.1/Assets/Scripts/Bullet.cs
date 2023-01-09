using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int maxPierce;
    private int hitEnemyCount;
    CanvasController canvasCon;
    // Start is called before the first frame update
    void Start()
    {
        canvasCon = FindObjectOfType<CanvasController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canvasCon.pierceUpgrade == 0)
        {
            maxPierce = 1;
        }
        if(canvasCon.pierceUpgrade == 1)
        {
            maxPierce = 2;
        }
        if(canvasCon.pierceUpgrade == 2)
        {
            maxPierce = 3;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.EnemyTakeHit(5);
            hitEnemyCount++;
            if (hitEnemyCount >= maxPierce)
            {
                Destroy(gameObject);
            }
        }
    }
}
