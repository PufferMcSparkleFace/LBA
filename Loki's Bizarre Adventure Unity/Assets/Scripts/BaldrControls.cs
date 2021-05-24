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


    // Start is called before the first frame update
    void Start()
    {
        GameObject loki = GameObject.FindGameObjectWithTag("Loki");
        Physics2D.IgnoreCollision(loki.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        OnDisable();
        LokiFollow = GameObject.FindGameObjectWithTag("Loki").GetComponent<Transform>();
    }

    void Awake()
    {
        controls = new PlayerControls();
        controls.Baldr.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Baldr.Move.canceled += ctx => move = Vector2.zero;
        controls.Baldr.Jump.performed += ctx => Jump();
        controls.Baldr.Jump2.performed += ctx => Jump();
        controls.Baldr.SwitchPlayerLeft.performed += ctx => SwitchPlayer();
        controls.Baldr.SwitchPlayerRight.performed += ctx => SwitchPlayer();
    }

    void SwitchPlayer()
    {
        OnDisable();
        lokiControls.OnEnable();
        BaldrCam.Priority = 0;
        LokiCam.Priority = 1;
    }

   public void Jump()
    {
        if (rb.velocity.y == 0 || isTethered == true)
        {
            rb.velocity = new Vector2(0, jumpHeight);
        }

    }


    void Update()
    {
        Vector2 m = new Vector2(move.x, 0f) * Time.deltaTime * speed;
        transform.Translate(m, Space.World);
        if(Vector2.Distance(transform.position, LokiFollow.position) > distancetoloki && isTethered == true)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2 (LokiFollow.position.x, transform.position.y), speed * Time.deltaTime);
        }

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
