using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LokiControls : MonoBehaviour
{
    PlayerControls controls;

    Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        controls = new PlayerControls();
        controls.Loki.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Loki.Move.canceled += ctx => move = Vector2.zero;
    }

    void Update()
    {
        Vector2 m = new Vector2(move.x, 0f) * Time.deltaTime;
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
