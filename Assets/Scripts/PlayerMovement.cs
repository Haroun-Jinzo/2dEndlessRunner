using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jumpForce = 2;
    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    private Animator playerAnimation;
    public float energy = 101;
    public LayerMask sensLayer;
    public static PlayerMovement inst;
    [SerializeField] public SpriteRenderer sr;
    public float speedRotation;

    private void Awake()
    {
        inst = this;
    }
  

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "sensChecker")
        {
            if (sr.flipX == false)
                flip();
            else
                reFlip();
        }
    }
    // Start is called before the first frame update
    private void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

        CheckIfGrounded();
  
        playerAnimation.SetBool("isGrounded", isGrounded);

        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) 
            {
                if (touch.position.x < ScreenSplit.inst.screenWidth / 2)
                {
                    if (sr.flipX == false)
                    {
                        flip();
                    }
                    else
                    {
                        reFlip();
                    }
                }
            }
            if (touch.position.x >= ScreenSplit.inst.screenWidth / 2)
            {
                if (EnergyBar.instance.currentEnergy - 2 >= 0)
                {
                    fly();
                }

            }
        }

        
    }

    void fly()
    {
        EnergyBar.instance.useEnergy(10);
        rb.AddForce(Vector2.up * jumpForce);
        ScoreManager.ins.AddPoint();
    }
   
    void flip()
    {
        speed = -speed;
        sr.flipX = true;
    }
    void reFlip()
    {
        speed = -speed;
        sr.flipX = false;
    }
    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        if (collider != null)
        {
            isGrounded = true;
        } 
        else
        {
            isGrounded = false;
        }
    }
}