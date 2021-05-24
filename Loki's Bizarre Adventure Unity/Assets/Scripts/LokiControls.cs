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



    // Start is called before the first frame update
    void Start()
    {
        GameObject baldr = GameObject.FindGameObjectWithTag("Baldr");
        Physics2D.IgnoreCollision(baldr.GetComponent < Collider2D > (), GetComponent < Collider2D > ());
        BaldrFollow = GameObject.FindGameObjectWithTag("Baldr").GetComponent<Transform>();
        GameObject clone = GameObject.FindGameObjectWithTag("Clone");
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
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
        
    
    }

    //void clone
    //if inactive = true, set clone active, set clone's position to yours, give force with opposite direction to yours, and detether baldr

    //in the clone, clonebounce, and switch player function, call the detether function
    
    void SummonClone()
    {
        if(clonescript.active == false)
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
            rb.gravityScale = 0.0f;
            clonerb.gravityScale = 0.0f;
            OnDisable();
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
       
    }

    void Update()
    {
        Vector2 m = new Vector2(move.x, 0f) * Time.deltaTime * speed;
        transform.Translate(m, Space.World);
        LokiAnimator.SetFloat("Speed", Mathf.Abs(move.x));
        if(rb.velocity.y == 0)
        {
            LokiAnimator.SetBool("IsJumping", false);
        }
        else
        {
            LokiAnimator.SetBool("IsJumping", true);
        }
        if(move.x > 0 && LokiSpriteRenderer.flipX == false)
        {
            LokiSpriteRenderer.flipX = true;
        }
        if(move.x<0 && LokiSpriteRenderer == true)
        {
            LokiSpriteRenderer.flipX = false;
        }
        if(cloneisfocus == true && clonescript.active == false)
        {
            CloneCam.Priority = 0;
            LokiCam.Priority = 1;
            cloneisfocus = false;
        }
        if(isDashing == true)
        {
            rb.velocity = DashDirection * DashForce;
            CurrentDashTime -= Time.deltaTime;
            if(CurrentDashTime <= 0)
            {
                isDashing = false;
                rb.gravityScale = 5;
                clonerb.gravityScale = 5;
                OnEnable();
            }

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

}
