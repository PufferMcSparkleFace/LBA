using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class LokiControls : MonoBehaviour
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
    private BaldrControls baldrControls;
    [SerializeField]
    private CinemachineVirtualCamera LokiCam;
    [SerializeField]
    private CinemachineVirtualCamera BaldrCam;
    [SerializeField]
    private bool isTethered = true;
    [SerializeField]
    private float delay = 1;
    private Transform BaldrFollow;
    public Animator LokiAnimator;
    public SpriteRenderer LokiSpriteRenderer;
    public Clone clonescript;
    public Rigidbody2D clonerb;
    public bool tethered = false;
    public bool active = false;
    public CinemachineVirtualCamera CloneCam;
    public bool cloneisfocus = false;
    public GameObject clone;
    public float DashForce;
    public float DashTime;
    public float CurrentDashTime;
    public bool isDashing = false;
    public Vector2 DashDirection;
    public bool canmirrorbounce = false;
    public float canmirrorbouncetimer;
    public float startingcanmirrorbouncetimer = 0.75f;
    public bool candash = true;
    public float clonebounceheight;
    public bool canclonebounce = false;
    private Transform clonebouncedetector;
    public CameraShake cameraShake;
    private Vector2 lastMove;
    public float mirrorboostamount = 1.5f;
    public float originalmirrorboostamount = 1.5f;
    public bool isbouncing = false;
    public GameObject shield;
    public Collider2D lokicollider;
    public Collision2D lokicollision;
    public bool isignoring = false;
    public BaldrClone baldrclonescript;
    public bool cloneisloki = true;
  

    

    // Start is called before the first frame update
    void Start()
    {
        GameObject baldr = GameObject.FindGameObjectWithTag("Baldr");
        Physics2D.IgnoreCollision(baldr.GetComponent < Collider2D > (), GetComponent < Collider2D > ());
        BaldrFollow = GameObject.FindGameObjectWithTag("Baldr").GetComponent<Transform>();
        GameObject clone = GameObject.FindGameObjectWithTag("Clone");
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        clonebouncedetector = GameObject.FindGameObjectWithTag("Clonebounce Detector").GetComponent<Transform>();
    }

    void Awake()
    {
        controls = new PlayerControls();
        controls.Loki.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Loki.Move.canceled += ctx => move = Vector2.zero;
        controls.Loki.Jump.performed += ctx => Jump();
        controls.Loki.Jump2.performed += ctx => Jump();
        controls.Loki.SwitchPlayerLeft.performed += ctx => SwitchPlayerLeft();
        controls.Loki.SwitchPlayerRight.performed += ctx => SwitchPlayerRight();
        controls.Loki.TetherBaldr.performed += ctx => tetherManagement();
        controls.Loki.SummonClone.performed += ctx => SummonClone();
        controls.Loki.SwitchCloneLeft.performed += ctx => SwitchCloneTarget();
        controls.Loki.SwitchCloneRight.performed += ctx => SwitchCloneTarget();
        
    
    }
    
    void SwitchCloneTarget()
    {
        if(cloneisloki == true)
        {
            cloneisloki = false;
        }
        else
        {
            cloneisloki = true;
        }
    }

    void SummonClone()
    {
        if(clonescript.active == false && candash == true)
        {
            clone.transform.position = this.gameObject.transform.position;
            clone.GetComponent<SpriteRenderer>().enabled = true;
            clonescript.active = true;
            clonescript.tethered = true;
            baldrControls.isTethered = false;
            isTethered = false;
            baldrControls.move.x = 0;
            isDashing = true;
            clonescript.isDashing = true;
            CurrentDashTime = DashTime;
            DashDirection = new Vector2(move.x, move.y);
            clonescript.DashDirection = new Vector2(-move.x, -move.y);
            clonescript.CurrentDashTime = clonescript.DashTime;
            canmirrorbounce = true;
            clonescript.canmirrorbounce = true;
            canmirrorbouncetimer = startingcanmirrorbouncetimer;
            candash = false;
            cameraShake.ShakeCamera(2f, 0.2f);
            clonescript.canmirrorbouncetimer = clonescript.startingcanmirrorbouncetimer;
        }
        else if (clonescript.active == true && clonescript.tethered == true)
        {
            clonescript.tethered = false;
            clonescript.move.x = 0;
        }
        else if (clonescript.active == true && clonescript.tethered == false)
        {
            clone.GetComponent<SpriteRenderer>().enabled = false;
            clonescript.active = false;
        }
    }

    
    void SwitchPlayerLeft()
    {
        if(cloneisfocus == false)
        {
            OnDisable();
            baldrControls.OnEnable();
            LokiCam.Priority = 0;
            BaldrCam.Priority = 1;
            isTethered = false;
            baldrControls.isTethered = false;
            baldrControls.move.x = 0;
            cloneisfocus = false;
        }
        if(cloneisfocus == true)
        {
            CloneCam.Priority = 0;
            LokiCam.Priority = 1;
            cloneisfocus = false;
        }
        
    }

    void SwitchPlayerRight()
    {
        if(clonescript.active == true && cloneisfocus == false)
        {
            LokiCam.Priority = 0;
            BaldrCam.Priority = 0;
            CloneCam.Priority = 1;
            cloneisfocus = true;
        }
        else if(clonescript.active == false || cloneisfocus == true)
        {
            OnDisable();
            baldrControls.OnEnable();
            LokiCam.Priority = 0;
            BaldrCam.Priority = 1;
            isTethered = false;
            baldrControls.isTethered = false;
            cloneisfocus = false;
            baldrControls.move.x = 0;
        }
    }

    void Jump()
    {
        if(rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(0, jumpHeight);
            if (isTethered == true)
            {
                StartCoroutine(tetheredJump());
            }
            if(clonescript.tethered == true)
            {
                clonescript.Jump();
            }
     
        }
        if(canclonebounce == true && rb.velocity.y < 0)
        {
            CloneBounce();
            isTethered = false;
            baldrControls.isTethered = false;
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
            cameraShake.ShakeCamera(1f, 0.2f);
            Debug.Log("bouncybouncy");
        }
        if (collision.gameObject.tag == "Mirror" && canmirrorbounce == false)
        {
            Physics2D.IgnoreCollision(collision.collider, lokicollider);
            lokicollision = collision;
            isignoring = true;
            //Invoke("IgnoreCollisions", 1);
        }
    }

    void Update()
    {
        if (canmirrorbounce == true)
        {
            canmirrorbouncetimer -= Time.deltaTime;
            if (canmirrorbouncetimer <= 0)
            {
                canmirrorbounce = false;
                isbouncing = false;
                mirrorboostamount = originalmirrorboostamount;
                rb.gravityScale = 5f;
                isDashing = false;
            }
        }
        if (canmirrorbounce == true && isignoring == true)
        {
            Physics2D.IgnoreCollision(lokicollision.collider, lokicollider, false);
            isignoring = false;
        }
        if (isbouncing == false)
        {
            Vector2 m = new Vector2(move.x, 0f) * Time.deltaTime * speed;
            transform.Translate(m, Space.World);
            if (move.x > 0 && LokiSpriteRenderer.flipX == false)
            {
                LokiSpriteRenderer.flipX = true;
            }
            if (move.x < 0 && LokiSpriteRenderer == true)
            {
                LokiSpriteRenderer.flipX = false;
            }
        }
        LokiAnimator.SetFloat("Speed", Mathf.Abs(move.x));
        
        if(rb.velocity.y == 0 && canmirrorbounce == false)
        {
            LokiAnimator.SetBool("IsJumping", false);
            canclonebounce = false;
        }
        else
        {
            LokiAnimator.SetBool("IsJumping", true);
        }

        if(cloneisfocus == true && clonescript.active == false)
        {
            CloneCam.Priority = 0;
            LokiCam.Priority = 1;
            cloneisfocus = false;
        }
        if(isDashing == true && isbouncing == false)
        {
            rb.velocity = DashDirection * DashForce;
            CurrentDashTime -= Time.deltaTime;
            if(CurrentDashTime <= 0)
            {
                isDashing = false;
            }

        }
        if(rb.velocity.y == 0 && clonescript.active == false)
        {
            candash = true;
        }
        if(clonescript.tethered == true || clonescript.active == false)
        {
            canclonebounce = false;
        }

      
    }

    
      
void tetherManagement()
    {
        if(isTethered == true)
        {
            isTethered = false;
            baldrControls.isTethered = false;
            baldrControls.move.x = 0;
            return;
        }

        if (isTethered == false && Vector2.Distance(transform.position, BaldrFollow.position) < 5)
        {
            isTethered = true;
            baldrControls.isTethered = true;
        }
    }

    

    IEnumerator tetheredJump()
    {
        yield return new WaitForSeconds(delay);
        baldrControls.Jump();
    }


    public void OnEnable()
    {
        controls.Loki.Enable();
    }

    public void OnDisable()
    {
        controls.Loki.Disable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Clonebounce Detector" && clonescript.tethered == false && clonescript.active == true)
        {
            canclonebounce = true;
        }

    }

    public void CloneBounce()
    {
        rb.velocity = new Vector2(0f, clonebounceheight);
        canclonebounce = false;
    }

    //void IgnoreCollisions()
    //{
    //    Physics2D.IgnoreCollision(lokicollision.collider, lokicollider, false);
    //}


}
