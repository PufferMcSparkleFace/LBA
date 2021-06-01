﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSwitch : MonoBehaviour
{
    public bool sticky = false;
    public GameObject wall;
    public GameObject gateopened;
    public SpriteRenderer switchunpressed;
    public SpriteRenderer switchpressed;
    public Clone clonescript;
    public BaldrControls baldrscript;
    public LokiControls lokiscript;
    // Start is called before the first frame update
    void Start()
    {
        switchpressed.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Clone" || collision.gameObject.tag == "Loki" || collision.gameObject.tag == "Baldr")
        {
            switchpressed.enabled = true;
            switchunpressed.enabled = false;
            wall.SetActive(false);
            gateopened.SetActive(true);
        }
        if (collision.tag == "Baldr")
        {
            baldrscript.ispressingswitch = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Baldr")
        {
            baldrscript.ispressingswitch = false;
        }
        if (sticky == false)
        {
            if (collision.gameObject.tag == "Clone" || collision.gameObject.tag == "Loki" || collision.gameObject.tag == "Baldr")
            {
                if (clonescript.ispressingswitch == true || lokiscript.ispressingswitch == true || baldrscript.ispressingswitch == true)
                {
                    return;
                }
                switchpressed.enabled = false;
                switchunpressed.enabled = true;
                wall.SetActive(true);
                gateopened.SetActive(false);
            }
        }

    }
}
