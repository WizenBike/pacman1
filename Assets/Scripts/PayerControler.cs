using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayerControler : MonoBehaviour
{
    public static PayerControler Instance;

    public delegate void Collide();
    public Collide collisionWithGhost;
    public Collide CollideWithPower;
    public GameObject startNode;
    public SpriteRenderer sr;
    public Transform sprite;
  


    bool nodeSetted = false;
    public MovemantControler mc;
    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
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
            FlipR();
        }
        else if (mc.direction == "left")
        {
            FlipL();
        }
        else if (mc.direction == "up")
        {
            FlipUp();
        }
        else if (mc.direction == "down")
        {
            FlipDown();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Gulicka") && nodeSetted == false)
        {
            startNode =collision.gameObject; 
            mc.currentNode = collision.gameObject;
            nodeSetted = true;
        }

        if (collision.gameObject.CompareTag("Enemy") && collision.gameObject.GetComponent<EnemyControler>().ghostState != EnemyControler.GhostStates.scared && collision.gameObject.GetComponent<EnemyControler>().ghostState != EnemyControler.GhostStates.goHome)
        {
            collisionWithGhost?.Invoke();
            GameInstance.gi.HP--;
            transform.position = startNode.transform.position;
            mc.currentNode = startNode;
        }
    }
    public void FlipL()
    {
        
      
        
          transform.rotation = Quaternion.Euler(0, 180, 0);
           
        
    }
    public void FlipR()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0); 
    }
    public void FlipUp()
    {
        transform.rotation = Quaternion.Euler(0,0,90);
    }
    public void FlipDown()
    {
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }
}
