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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Turret") && chaserEnemy.currentTurret == null)
        {
            chaserEnemy.currentTurret = collision.gameObject;
        }
    }
}
