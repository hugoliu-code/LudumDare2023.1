using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CanvasController canvasCon;
    private Animator anim;
    private Rigidbody2D rb;
    private bool invincible;

    private bool ticket0 = true;
    private bool ticket1 = true;
    private bool ticket2 = true;
    private bool ticket3 = true;
    private bool ticket4 = true;

    private enum State { idle, running }
    private State state = State.idle;

    [SerializeField] float speed;


    void Start()
    {
        canvasCon = FindObjectOfType<CanvasController>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Upgrades();
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
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            if (invincible == false)
            {
                StartCoroutine(Invincible());
                GameManager.Instance.playerHealth--;
                if (GameManager.Instance.playerHealth <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
    private void Upgrades()
    {
        //Movement
        if (canvasCon.movementUpgrade == 0)
        {
            speed = 2.5f;
        }
        if (canvasCon.movementUpgrade == 1)
        {
            speed = 2.6f;
        }
        if (canvasCon.movementUpgrade == 2)
        {
            speed = 2.7f;
        }
        if (canvasCon.movementUpgrade == 3)
        {
            speed = 2.8f;
        }
        if (canvasCon.movementUpgrade == 4)
        {
            speed = 3;
        }

        //Health
        if (canvasCon.healthUpgrade == 0 && ticket0)
        {
            ticket0 = false;
            GameManager.Instance.playerHealth = 3;    
        }
        if (canvasCon.healthUpgrade == 1 && ticket1)
        {
            ticket1 = false;
            GameManager.Instance.playerHealth++;
        }
        if (canvasCon.healthUpgrade == 2 && ticket2)
        {
            ticket2 = false;
            GameManager.Instance.playerHealth++;
        }
        if (canvasCon.healthUpgrade == 3 && ticket3)
        {
            ticket3 = false;
            GameManager.Instance.playerHealth++;
        }
        if (canvasCon.healthUpgrade == 4 && ticket4)
        {
            ticket4 = false;
            GameManager.Instance.playerHealth++;
        }
    }
    private IEnumerator Invincible()
    {
        invincible = true;
        yield return new WaitForSeconds(4f);
        invincible = false;
    }
}
