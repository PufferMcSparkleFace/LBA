using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public float speed;
    public float jumpheight;
    public Vector2 move;
    public Rigidbody2D rb;
    public Animator cloneAnimator;
    public SpriteRenderer cloneSprite;
    public bool tethered = false;
    public bool active = false;
    public bool jumpbuffer = false;
    public LokiControls lokicontrols;
    public float DashForce;
    public float DashTime;
    public float CurrentDashTime;
    public bool isDashing = false;
    public Vector2 DashDirection;
    public bool canmirrorbounce = false;
    public bool isbouncing = false;
    public float mirrorboostamount = 1.5f;
    public float startingmirrorboostamount = 1.5f;
    public float canmirrorbouncetimer;
    public float startingcanmirrorbouncetimer = 0.75f;
    public Collider2D clonecollider;
    public Collision2D clonecollision;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        GameObject baldr = GameObject.FindGameObjectWithTag("Baldr");
        Physics2D.IgnoreCollision(baldr.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        if (canmirrorbounce == true)
        {
            canmirrorbouncetimer -= Time.deltaTime;
            if (canmirrorbouncetimer <= 0)
            {
                canmirrorbounce = false;
                
                isbouncing = false;
                mirrorboostamount = startingmirrorboostamount;
                rb.gravityScale = 5f;
                isDashing = false;
            }
        }

        if (jumpbuffer == true && rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(0, jumpheight);
            jumpbuffer = false;
        }
        if(tethered == true)
        {
            move.x = lokicontrols.move.x;
            Vector2 m = new Vector2(move.x, 0f) * Time.deltaTime * speed;
            transform.Translate(m, Space.World);
            cloneAnimator.SetFloat("Speed", Mathf.Abs(move.x));
        }
        if (rb.velocity.y == 0 && isDashing == false)
        {
            cloneAnimator.SetBool("IsJumping", false);
        }
        else
        {
            cloneAnimator.SetBool("IsJumping", true);
        }
        if (move.x > 0 && cloneSprite.flipX == false)
        {
            cloneSprite.flipX = true;
        }
        if (move.x < 0 && cloneSprite == true)
        {
            cloneSprite.flipX = false;
        }
        
        if (isDashing == true && isbouncing == false)
        {
            rb.velocity = DashDirection * DashForce;
            CurrentDashTime -= Time.deltaTime;
            if (CurrentDashTime <= 0)
            {
                isDashing = false;
            }

        }
        if(isDashing == true)
        {
            move.x = 0;
        }
    }

    public void Jump()
    {

        if (rb.velocity.y != 0 && tethered == true)
        {
            jumpbuffer = true;
        }
        if (rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(0, jumpheight);
            jumpbuffer = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mirror" && canmirrorbounce == true)
        {
            var direction = collision.contacts[0].normal;
            rb.velocity = direction * DashForce * mirrorboostamount;
            mirrorboostamount += 0.1f;
            canmirrorbouncetimer = startingcanmirrorbouncetimer;
            isbouncing = true;
            rb.gravityScale = 0.0f;
            move.x = 0;
        }
        if (collision.gameObject.tag == "Mirror" && canmirrorbounce == false)
        {
            Physics2D.IgnoreCollision(collision.collider, clonecollider);
            clonecollision = collision;
            //Invoke("IgnoreCollisions", 1f);
        }
    }

    //private void IgnoreCollisions()
    //{
    //    Physics2D.IgnoreCollision(clonecollision.collider, clonecollider, false);
    //}

}
    
