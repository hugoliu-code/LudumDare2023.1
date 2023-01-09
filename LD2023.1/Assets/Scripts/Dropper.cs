using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{


    public Transform player;

    public GameObject harvester;
    public GameObject turret;
    public GameObject lure;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DropHarvester()
    {
        GameObject HarvesterIns = Instantiate(harvester, player.position, player.rotation);
        HarvesterIns.GetComponent<Rigidbody2D>().AddForce(HarvesterIns.transform.right* 1000000);
    }

    public void DropTurret()
    {
        GameObject TurretIns = Instantiate(turret, player.position, player.rotation);
        TurretIns.GetComponent<Rigidbody2D>().AddForce(TurretIns.transform.right*2500000);
    }

    public void DropLure()
    {
        GameObject LureIns = Instantiate(lure, player.position, player.rotation);
        LureIns.GetComponent<Rigidbody2D>().AddForce(LureIns.transform.right * 2500000);
    }
}
