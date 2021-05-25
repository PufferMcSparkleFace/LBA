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

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
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
        }
        cloneAnimator.SetFloat("Speed", Mathf.Abs(move.x));
        if (rb.velocity.y == 0)
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
        
        if (isDashing == true)
        {
            rb.velocity = DashDirection * DashForce;
            CurrentDashTime -= Time.deltaTime;
            if (CurrentDashTime <= 0)
            {
                isDashing = false;
            }

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

}
    
