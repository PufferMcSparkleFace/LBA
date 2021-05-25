using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clonebounce : MonoBehaviour
{
    public Rigidbody2D lokirb;
    public LokiControls lokiscript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClonebounceFunction()
    {
        lokirb.velocity = new Vector2 (0f, lokiscript.clonebounceheight);
        lokiscript.canclonebounce = false;
    }
}
