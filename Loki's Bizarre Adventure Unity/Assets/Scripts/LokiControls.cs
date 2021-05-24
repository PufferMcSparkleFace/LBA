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
    Vector2 move;
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
    



    // Start is called before the first frame update
    void Start()
    {
        GameObject baldr = GameObject.FindGameObjectWithTag("Baldr");
        Physics2D.IgnoreCollision(baldr.GetComponent < Collider2D > (), GetComponent < Collider2D > ());
        BaldrFollow = GameObject.FindGameObjectWithTag("Baldr").GetComponent<Transform>();
    }

    void Awake()
    {
        controls = new PlayerControls();
        controls.Loki.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Loki.Move.canceled += ctx => move = Vector2.zero;
        controls.Loki.Jump.performed += ctx => Jump();
        controls.Loki.Jump2.performed += ctx => Jump();
        controls.Loki.SwitchPlayerLeft.performed += ctx => SwitchPlayer();
        controls.Loki.SwitchPlayerRight.performed += ctx => SwitchPlayer();
        controls.Loki.TetherBaldr.performed += ctx => tetherManagement();
        
        
    
    }

    //in the clone, clonebounce, and switch player function, call the detether function
    
    void SwitchPlayer()
    {
        OnDisable();
        baldrControls.OnEnable();
        LokiCam.Priority = 0;
        BaldrCam.Priority = 1;
        isTethered = false;
        baldrControls.isTethered = false;
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
        }
       
    }

    void Update()
    {
        Vector2 m = new Vector2(move.x, 0f) * Time.deltaTime * speed;
        transform.Translate(m, Space.World);
        if(Vector2.Distance(transform.position, BaldrFollow.position) > 10)
        {
            isTethered = false;
            baldrControls.isTethered = false;
        }
    }

    void tetherManagement()
    {
        if(isTethered == true)
        {
            isTethered = false;
            baldrControls.isTethered = false;
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
