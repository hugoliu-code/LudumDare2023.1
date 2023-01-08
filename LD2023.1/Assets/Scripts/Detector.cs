using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public Transform turretPos;
    [SerializeField] ChaserEnemy chaserEnemy;
    // Start is called before the first frame update
    void Start()
    {
        turretPos = gameObject.transform;
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Lure"))
        {
            if(chaserEnemy.currentTurret != null)
            {
                if (!chaserEnemy.CompareTag("Lure"))
                {
                    chaserEnemy.currentTurret = collision.gameObject;
                }
            }
            else
            {
                chaserEnemy.currentTurret = collision.gameObject;
            }
            
        }
        else if (collision.CompareTag("Turret") && chaserEnemy.currentTurret == null)
        {
            chaserEnemy.currentTurret = collision.gameObject;
        }
    }
}
