using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackmanMovemantAndrej : MonoBehaviour
{
   
    
        string currentDir;
        Rigidbody2D rb;
        public float speed;
        // Start is called before the first frame update
        void Start()
        {
            
            rb = GetComponent<Rigidbody2D>();
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.W)) currentDir = "up";
            if (Input.GetKeyDown(KeyCode.S)) currentDir = "down";
            if (Input.GetKeyDown(KeyCode.D)) currentDir = "right";
            if (Input.GetKeyDown(KeyCode.A)) currentDir = "left";
        }
        private void FixedUpdate()
        {
            switch (currentDir)
            {
                case "up":
                    Up();
                    break;
                case "down":
                    Down();
                    break;
                case "left":
                    Left();
                    break;
                case "right":
                    Right();
                    break;
            }
        }
        void Up()
        {
            rb.velocity = new Vector2(0, speed);
        }
        void Down()
        {
            rb.velocity = new Vector2(0, -speed);
        }
        void Left()
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        void Right()
        {
            rb.velocity = new Vector2(speed, 0);
        }


    
}
