using System.Collections;
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
    public CameraShake cameraShake;
    public GameObject shieldgameobject;
    public GameObject shieldpositiongameobject;
    public GameObject position1, position2;
    public SpriteRenderer shieldsprite;
    public Vector2 shieldrotation;
    public float shieldangle;
    public float currentshieldangle;
    public bool ispressingswitch = false;


    // Start is called before the first frame update
    void Start()
    {
        GameObject shield = GameObject.FindGameObjectWithTag("Mirror");
        Physics2D.IgnoreCollision(shield.GetComponent<BoxCollider2D>(), GetComponent<PolygonCollider2D>());
        LokiFollow = GameObject.FindGameObjectWithTag("Loki").GetComponent<Transform>();
      
    }

    void Awake()
    {
        controls = new PlayerControls();
        controls.Baldr.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Baldr.Move.canceled += ctx => move = Vector2.zero;
        controls.Baldr.AngleShield.performed += ctx => shieldrotation = ctx.ReadValue<Vector2>();
        controls.Baldr.AngleShield.canceled += ctx => LockShieldAngle();
        controls.Baldr.Jump.performed += ctx => Jump();
        controls.Baldr.Jump2.performed += ctx => Jump();
        controls.Baldr.SwitchPlayerLeft.performed += ctx => SwitchPlayerLeft();
        controls.Baldr.SwitchPlayerRight.performed += ctx => SwitchPlayerRight();
        controls.Baldr.Slide.performed += ctx => Slide();
        controls.Baldr.Tether.performed += ctx => tetherManagement();
        OnDisable();
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
        if (clonescript.active)
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

    public void Slide()
    {
        if (canslide)
        {
            if (move.x >= 0.5f || move.x <= -0.5f)
            {
                if (rb.velocity.y == 0)
                {

                    FindObjectOfType<AudioManager>().Play("Roll");
                    issliding = true;
                    currentslidetime = 1;
                    momentum *= momentumincrease;
                    cameraShake.ShakeCamera(momentum, 0.2f);
                   
                }
                canslide = false;
            }
      
        }
 
    }

    public void Jump()
    {
        
        if (rb.velocity.y != 0 && isTethered)
        {
            jumpbuffer = true;
        }
        if (rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(0, jumpHeight);
            jumpbuffer = false;
            
            if (issliding)
            {
                currentslidetime = 2;
                canslide = true;
            }
 
        }

    }

    public void LockShieldAngle()
    {
        shieldangle = currentshieldangle;
    }



    void Update()
    {
        shieldangle = currentshieldangle;
        if (shieldrotation.x >= 0.5 || shieldrotation.y >= 0.5 || shieldrotation.x <= -0.5 || shieldrotation.y <= -0.5)
        {
            shieldangle = Mathf.Atan2(shieldrotation.x, shieldrotation.y) * Mathf.Rad2Deg;
            currentshieldangle = shieldangle;
        }
        if (issliding)
        {
            currentslidetime -= Time.deltaTime;
            BaldrAnimator.SetBool("IsSliding", true);
            if(currentslidetime <= 0)
            {
                issliding = false;
                isslowingdown = true;
                BaldrAnimator.SetBool("IsSliding", false);
            }
        }
        if(isslowingdown)
        {
            momentum -= Time.deltaTime *2;
        }
        if(momentum <= 1)
        {
            canslide = true;
            isslowingdown = false;
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
       
        if(Vector2.Distance(transform.position, LokiFollow.position) >= distancetoloki && isTethered)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(LokiFollow.position.x, transform.position.y), speed * Time.deltaTime);
        }
        if(jumpbuffer && rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(0, jumpHeight);
            jumpbuffer = false;
        }

        if(rb.velocity.y > 0)
        {
            BaldrAnimator.SetBool("IsJumping", true);
            canslide = true;
        }
        else if (rb.velocity.y <0)
        {
            BaldrAnimator.SetBool("IsJumping", false);
            BaldrAnimator.SetBool("IsFalling", true);
            canslide = true;
        }
        if(rb.velocity.y == 0)
        {
            BaldrAnimator.SetBool("IsJumping", false);
            BaldrAnimator.SetBool("IsFalling", false);
        }
        
        BaldrAnimator.SetFloat("Speed", Mathf.Abs(move.x));



        if (move.x > 0 && BaldrSpriteRenderer.flipX)
        {
            BaldrSpriteRenderer.flipX = false;
         
        }
        if (move.x < 0 && BaldrSpriteRenderer.flipX == false)
        {
            BaldrSpriteRenderer.flipX = true;
            
        }


        if (isTethered)
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

        if (BaldrSpriteRenderer.flipX == false)
        {
            shieldgameobject.transform.eulerAngles = new Vector3(shieldgameobject.transform.eulerAngles.x, 0, shieldgameobject.transform.eulerAngles.z);
            shieldpositiongameobject.transform.position = position2.transform.position;
            shieldangle = -shieldangle;
        }

        if (BaldrSpriteRenderer.flipX)
        {
            shieldgameobject.transform.eulerAngles = new Vector3(shieldgameobject.transform.eulerAngles.x, 180, shieldgameobject.transform.eulerAngles.z);
            shieldpositiongameobject.transform.position = position1.transform.position;
        }
     
        if(issliding || rb.velocity.y != 0 || isTethered || isslowingdown)
        {
            shieldsprite.enabled = false;
        }
        else
        {
            shieldsprite.enabled = true;
        }

        shieldgameobject.transform.eulerAngles = new Vector3(shieldgameobject.transform.eulerAngles.x, shieldgameobject.transform.eulerAngles.y, shieldangle);

    }

    public void OnEnable()
    {
        controls.Baldr.Enable();
    }

    public void OnDisable()
    {
        controls.Baldr.Disable();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Mirror" || collision.gameObject.tag == "Stop" || collision.gameObject.tag == "Shield")
        {
            Physics2D.IgnoreCollision(collision.collider, this.gameObject.GetComponent<Collider2D>());
        }
    }


    void tetherManagement()
    {
        if (isTethered)
        {
            isTethered = false;
            lokiControls.isTethered = false;
            lokiControls.move.x = 0;
            return;
        }

        if (isTethered == false && Vector2.Distance(transform.position, LokiFollow.position) < 5)
        {
            isTethered = true;
            lokiControls.isTethered = true;
            OnDisable();
            lokiControls.OnEnable();
            BaldrCam.Priority = 0;
            LokiCam.Priority = 1;
            CloneCam.Priority = 0;
            lokiControls.cloneisfocus = false;
        }
    }

}
