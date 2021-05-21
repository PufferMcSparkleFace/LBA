﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BaldrControls : MonoBehaviour
{
    PlayerControls controls;

    Vector2 move;

    public float speed;

    public float jumpHeight;

    public Rigidbody2D rb;

    public float fastfallspeed;

    public bool canfastfall = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        controls = new PlayerControls();
        controls.Baldr.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Baldr.Move.canceled += ctx => move = Vector2.zero;
        controls.Baldr.Jump.performed += ctx => Jump();
        controls.Baldr.Jump2.performed += ctx => Jump();
        controls.Baldr.FastFall.performed += ctx => FastFall();
    }

    void Jump()
    {
        if (rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(0, jumpHeight);
            canfastfall = false;
        }

    }

    void FastFall()
    {
        if (rb.velocity.y != 0 && canfastfall == true)
        {
            rb.velocity -= new Vector2(0, fastfallspeed);
        }
    }

    void Update()
    {
        Vector2 m = new Vector2(move.x, 0f) * Time.deltaTime * speed;
        transform.Translate(m, Space.World);
        if (rb.velocity.y < 0.5)
        {
            canfastfall = true;
        }
    }

    void OnEnable()
    {
        controls.Baldr.Enable();
    }

    void OnDisable()
    {
        controls.Baldr.Disable();
    }
}
