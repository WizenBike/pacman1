using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayerControler : MonoBehaviour
{
    public static PayerControler Instance;

    public delegate void Collide();
    public Collide CollideWithPower;

    bool nodeSetted = false;
    public MovemantControler mc;
    // Start is called before the first frame update
    void Awake()
    {
        mc = GetComponent<MovemantControler>();
        Instance = this; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            mc.setDirection("right");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            mc.setDirection("left");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            mc.setDirection("up");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            mc.setDirection("down");
        }




        if (mc.direction == "right")
        {
            transform.rotation = Quaternion.Euler(0,0,0); 
        }
        else if (mc.direction == "left")
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (mc.direction == "up")
        {
            transform.rotation = Quaternion.Euler(0, 0,  90);
        }
        else if (mc.direction == "down")
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Gulicka") && nodeSetted == false)
        {
            mc.currentNode = collision.gameObject;
        }
    }
}
