﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LokiControls : MonoBehaviour
{
    PlayerControls controls;

    Vector2 move;

    public float speed;

    public float jumpHeight;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        controls = new PlayerControls();
        controls.Loki.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Loki.Move.canceled += ctx => move = Vector2.zero;
        controls.Loki.Jump.performed += ctx => Jump();
        controls.Loki.Jump2.performed += ctx => Jump();
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

    void OnEnable()
    {
        controls.Loki.Enable();
    }

    void OnDisable()
    {
        controls.Loki.Disable();
    }
}
