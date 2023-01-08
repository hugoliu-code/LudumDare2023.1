using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CanvasController canvasCon;
    [SerializeField] float speed;
    private Animator anim;
    private Rigidbody2D rb;

    private enum State { idle, running }
    private State state = State.idle;

    void Start()
    {
        canvasCon = FindObjectOfType<CanvasController>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(canvasCon.movementUpgrade == 0)
        {
            speed = 5;
        }
        if (canvasCon.movementUpgrade == 1)
        {
            speed = 6;
        }
        if (canvasCon.movementUpgrade == 2)
        {
            speed = 7;
        }
        if (canvasCon.movementUpgrade == 3)
        {
            speed = 8;
        }
        if (canvasCon.movementUpgrade == 4)
        {
            speed = 10;
        }
        anim.SetInteger("state", (int)state);
        Movement();
        AnimationState();
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

    private void AnimationState()
    {
        if (Mathf.Abs(rb.velocity.x) > 0 || Mathf.Abs(rb.velocity.y) > 0)
        {
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
    }
}
