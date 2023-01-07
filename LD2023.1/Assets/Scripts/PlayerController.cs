using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Dropper dropper;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Drop();
        Movement();
    }

    private void Drop()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            dropper.DropHarvester();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            dropper.DropTurret();
        }
    }
    private void Movement()
    {
        Vector2 direction = new Vector2(0, 0);


        if (Input.GetKey(KeyCode.W))
        {
            direction.y = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            direction.x = -1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction.y = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            direction.x = 1;
        }
        rb.velocity = direction.normalized * speed;
    }
}
