using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CanvasController canvasCon;
    private Animator anim;
    private Rigidbody2D rb;
    private bool invincible;

    public Sprint staminaBar;
    public float stamina;
    public float maxStamina = 100;
    public float rechargeTime;
    public float lossTime;
    public bool isSprinting;

    private bool ticket0 = true;
    private bool ticket1 = true;
    private bool ticket2 = true;
    private bool ticket3 = true;
    private bool ticket4 = true;

    private enum State { idle, running }
    private State state = State.idle;

    [SerializeField] float speed;
    private float origSpeed;


    void Start()
    {
        origSpeed = speed;
        stamina = maxStamina;
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
        Sprint();
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
            maxStamina = 75f;
            lossTime = 20f;
            rechargeTime = 10f;
            staminaBar.Sprinting(stamina, maxStamina);
        }
        if (canvasCon.movementUpgrade == 1)
        {
            maxStamina = 100f;
            lossTime = 20f;
            rechargeTime = 15f;
            staminaBar.Sprinting(stamina, maxStamina);
        }
        if (canvasCon.movementUpgrade == 2)
        {
            maxStamina = 100f;
            lossTime = 15f;
            rechargeTime = 15f;
            staminaBar.Sprinting(stamina, maxStamina);
        }
        if (canvasCon.movementUpgrade == 3)
        {
            maxStamina = 125f;
            lossTime = 15f;
            rechargeTime = 20f;
            staminaBar.Sprinting(stamina, maxStamina);
        }
        if (canvasCon.movementUpgrade == 4)
        {
            maxStamina = 150f;
            lossTime = 10f;
            rechargeTime = 25f;
            staminaBar.Sprinting(stamina, maxStamina);
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
        yield return new WaitForSeconds(3f);
        invincible = false;
    }

    private void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            stamina -= Time.deltaTime * lossTime;
            staminaBar.Sprinting(stamina, maxStamina);
            isSprinting = true;
            if (stamina < 0)
            {
                stamina = 0;
                isSprinting = false;
            }
        }
        else if(state != State.running)
        {
            stamina += Time.deltaTime * rechargeTime;
            isSprinting = false;
            if(stamina > maxStamina)
            {
                stamina = maxStamina;
            }
            staminaBar.Sprinting(stamina, maxStamina);
        }
        else
        {
            isSprinting = false;
        }

        if (isSprinting)
        {
            speed = origSpeed * 1.5f;
        }
        else
        {
            speed = origSpeed;
        }
    }
}
