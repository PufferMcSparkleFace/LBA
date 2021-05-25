﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class BaldrControls : MonoBehaviour
{
    [SerializeField]
    PlayerControls controls;
    [SerializeField]
    public Vector2 move;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private LokiControls lokiControls;
    [SerializeField]
    private CinemachineVirtualCamera LokiCam;
    [SerializeField]
    private CinemachineVirtualCamera BaldrCam;
    public bool isTethered = true;
    private Transform LokiFollow;
    [SerializeField]
    public float distancetoloki;
    [SerializeField]
    private bool jumpbuffer = false;
    public Animator BaldrAnimator;
    public SpriteRenderer BaldrSpriteRenderer;
    [SerializeField]
    private CinemachineVirtualCamera CloneCam;
    public Clone clonescript;
    public float currentslidetime;
    public bool issliding = false;
    public float momentum = 1;
    public float momentumincrease;
    public bool canslide = true;
    public bool isslowingdown = false;
    public bool istouchingwall = false;
    public float xWallForce;
    public float yWallForce = 1;


    // Start is called before the first frame update
    void Start()
    {
        GameObject loki = GameObject.FindGameObjectWithTag("Loki");
        Physics2D.IgnoreCollision(loki.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        OnDisable();
        LokiFollow = GameObject.FindGameObjectWithTag("Loki").GetComponent<Transform>();
        GameObject clone = GameObject.FindGameObjectWithTag("Clone");
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    void Awake()
    {
        controls = new PlayerControls();
        controls.Baldr.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Baldr.Move.canceled += ctx => move = Vector2.zero;
        controls.Baldr.Jump.performed += ctx => Jump();
        controls.Baldr.Jump2.performed += ctx => Jump();
        controls.Baldr.SwitchPlayerLeft.performed += ctx => SwitchPlayerLeft();
        controls.Baldr.SwitchPlayerRight.performed += ctx => SwitchPlayerRight();
        controls.Baldr.Slide.performed += ctx => Slide();
    }

    void SwitchPlayerRight()
    {
        OnDisable();
        lokiControls.OnEnable();
        BaldrCam.Priority = 0;
        LokiCam.Priority = 1;
        CloneCam.Priority = 0;
        lokiControls.cloneisfocus = false;
    }

    void SwitchPlayerLeft()
    {
        OnDisable();
        lokiControls.OnEnable();
        BaldrCam.Priority = 0;
        if (clonescript.active == true)
        {
            LokiCam.Priority = 0;
            CloneCam.Priority = 1;
            lokiControls.cloneisfocus = true;
        }
        else if(clonescript.active == false)
        {
            LokiCam.Priority = 1;
            CloneCam.Priority = 0;
            lokiControls.cloneisfocus = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            istouchingwall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            istouchingwall = false;
        }
    }

    public void Slide()
    {
        //else if on wall
        //make jump opposite direction
        //set currentslide time to 3 seconds
        if(canslide == true)
        {
            if (rb.velocity.y == 0)
            {
                issliding = true;
                currentslidetime = 1;
                momentum *= momentumincrease;
                canslide = false;
            }
            else if (istouchingwall == true)
            {
                rb.velocity = new Vector2(xWallForce, yWallForce);
            }
        }
 
    }

    public void Jump()
    {
        
        if (rb.velocity.y != 0 && isTethered == true)
        {
            jumpbuffer = true;
        }
        if (rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(0, jumpHeight);
            jumpbuffer = false;
            if(issliding == true)
            {
                currentslidetime = 2;
                canslide = true;
            }
 
        }

    }



    void Update()
    {

        if(issliding == true)
        {
            currentslidetime -= Time.deltaTime;
            BaldrAnimator.SetBool("IsSliding", true);
            if(currentslidetime <= 0)
            {
                issliding = false;
                isslowingdown = true;
            }
        }
        if(isslowingdown == true)
        {
            momentum -= Time.deltaTime;
        }
        if(momentum <= 1)
        {
            canslide = true;
            isslowingdown = false;
            BaldrAnimator.SetBool("IsSliding", false);
        }

        if(momentum > 3)
        {
            momentum = 3;
        }

        if (isTethered == false)
        {
            Vector2 m = new Vector2(move.x, 0f) * Time.deltaTime * speed * momentum;
            transform.Translate(m, Space.World);
        }
       
        if(Vector2.Distance(transform.position, LokiFollow.position) > distancetoloki && isTethered == true)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2 (LokiFollow.position.x, transform.position.y), speed * Time.deltaTime);
        }
        if(jumpbuffer == true && rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(0, jumpHeight);
            jumpbuffer = false;
        }

        if(rb.velocity.y > 0)
        {
            BaldrAnimator.SetBool("IsJumping", true);
        }
        if (rb.velocity.y <0)
        {
            BaldrAnimator.SetBool("IsJumping", false);
            BaldrAnimator.SetBool("IsFalling", true);
        }
        if(rb.velocity.y == 0)
        {
            BaldrAnimator.SetBool("IsJumping", false);
            BaldrAnimator.SetBool("IsFalling", false);
        }
        
        BaldrAnimator.SetFloat("Speed", Mathf.Abs(move.x));



        if (move.x > 0 && BaldrSpriteRenderer.flipX == true)
        {
            BaldrSpriteRenderer.flipX = false;
        }
        if (move.x < 0 && BaldrSpriteRenderer.flipX == false)
        {
            BaldrSpriteRenderer.flipX = true;
        }


        if (isTethered == true)
        {
            move.x = lokiControls.move.x;
            if (LokiFollow.position.x > transform.position.x)
            {
                BaldrSpriteRenderer.flipX = false;
            }
            else if (LokiFollow.position.x < transform.position.x)
            {
                BaldrSpriteRenderer.flipX = true;
            }
        }

        //if touching wall set anim
        //if not set anim

        xWallForce = -move.x * speed * momentum * Time.deltaTime;
    }

    public void OnEnable()
    {
        controls.Baldr.Enable();
    }

    public void OnDisable()
    {
        controls.Baldr.Disable();
    }

}
