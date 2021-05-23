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
    private float fastfallspeed;
    [SerializeField]
    private BaldrControls baldrControls;
    [SerializeField]
    private CinemachineVirtualCamera LokiCam;
    [SerializeField]
    private CinemachineVirtualCamera BaldrCam;



    // Start is called before the first frame update
    void Start()
    {
        GameObject baldr = GameObject.FindGameObjectWithTag("Baldr");
        Physics2D.IgnoreCollision(baldr.GetComponent < Collider2D > (), GetComponent < Collider2D > ());
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
        //when press tether button activate start coroutine
        
    
    }

    //tether coroutine
    //if baldr is close to loki
    //tell baldr to move to loki's position
    //wait
    //deactivate baldr sprite renderer
    //parent baldr to loki

    //void detether
    //activate baldr sprite render
    //deparent baldr to loki

    //in the clone, clonebounce, and switch player function, call the detether function
    
    void SwitchPlayer()
    {
        OnDisable();
        baldrControls.OnEnable();
        LokiCam.Priority = 0;
        BaldrCam.Priority = 1;
    }

    void Jump()
    {
        if(rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(0, jumpHeight);
        }
       
    }

    void Update()
    {
        Vector2 m = new Vector2(move.x, 0f) * Time.deltaTime * speed;
        transform.Translate(m, Space.World);
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
