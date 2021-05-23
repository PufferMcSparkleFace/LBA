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


    // Start is called before the first frame update
    void Start()
    {
        GameObject loki = GameObject.FindGameObjectWithTag("Loki");
        Physics2D.IgnoreCollision(loki.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    void Awake()
    {
        controls = new PlayerControls();
        controls.Baldr.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Baldr.Move.canceled += ctx => move = Vector2.zero;
        controls.Baldr.Jump.performed += ctx => Jump();
        controls.Baldr.Jump2.performed += ctx => Jump();
    }

    void Jump()
    {
        if (rb.velocity.y == 0)
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
        controls.Baldr.Enable();
    }

    void OnDisable()
    {
        controls.Baldr.Disable();
    }
}