using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hitpoints;
    public float maxHitpoints;
    // Start is called before the first frame update
    void Start()
    {
        hitpoints = maxHitpoints;   
    }

    // Update is called once per frame
    public void EnemyTakeHit(float damage)
    {
        hitpoints -= damage;
        if (hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
