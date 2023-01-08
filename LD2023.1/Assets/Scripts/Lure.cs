using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lure : MonoBehaviour
{
    private bool invincible;

    [SerializeField] float hitpoints;
    [SerializeField] float maxHitpoints;
    [SerializeField] TurretHealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {        
        hitpoints = maxHitpoints;
        healthBar.SetHealth(hitpoints, maxHitpoints);
    }
    public void LureTakeHit(float damage)
    {
        if (invincible == false)
        {
            StartCoroutine(Invincible());
            hitpoints -= damage;
            healthBar.SetHealth(hitpoints, maxHitpoints);
            if (hitpoints <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private IEnumerator Invincible()
    {
        invincible = true;
        yield return new WaitForSeconds(0.75f);
        invincible = false;
    }
}

