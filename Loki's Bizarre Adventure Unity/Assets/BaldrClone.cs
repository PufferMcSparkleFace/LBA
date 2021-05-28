using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaldrClone : MonoBehaviour
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
    public Collider2D clonecollider;
    public Collision2D clonecollision;
    

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        GameObject baldr = GameObject.FindGameObjectWithTag("Baldr");
        Physics2D.IgnoreCollision(baldr.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mirror")
        {
            Physics2D.IgnoreCollision(collision.collider, clonecollider);
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (jumpbuffer == true && rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(0, jumpheight);
            jumpbuffer = false;
        }
        if (tethered == true)
        {
            move.x = lokicontrols.move.x;
            Vector2 m = new Vector2(move.x, 0f) * Time.deltaTime * speed;
            transform.Translate(m, Space.World);
            cloneAnimator.SetFloat("Speed", Mathf.Abs(move.x));
        }
        if(rb.velocity.y != 0)
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
