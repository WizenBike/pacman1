using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeControler : MonoBehaviour
{
    public bool canMoveUp;
    public bool canMoveDown;
    public bool canMoveRight;
    public bool canMoveLeft;
  
   
   

    public GameObject nodeUp;
    public GameObject nodeDown;
    public GameObject nodeRight;
    public GameObject nodeLeft;
    public bool startNode = false;

    // Start is called before the first frame update
    void Start()
    {
       if (startNode == false)
       {

        print("aede");
        RaycastHit2D[] hitDown;
        hitDown = Physics2D.RaycastAll(transform.position, -Vector2.up);
        for(int i = 0; i < hitDown.Length; i++)
        {
            if ( 1 >= Mathf.Abs( hitDown[i].point.y - transform.position.y) && hitDown[i].collider.gameObject.CompareTag("Gulicka")) 
            {
                canMoveDown = true;
                nodeDown = hitDown[i].collider.gameObject;
            }                                                     
        }

        RaycastHit2D[] hitUp;
        hitUp = Physics2D.RaycastAll(transform.position, Vector2.up);
        for (int i = 0; i < hitUp.Length; i++)
        {
            if (1 >= Mathf.Abs(hitUp[i].point.y - transform.position.y) && hitUp[i].collider.gameObject.CompareTag("Gulicka"))
            {
                canMoveUp = true;
                nodeUp = hitUp[i].collider.gameObject;
            }
        }

        RaycastHit2D[] hitLeft;
        hitLeft = Physics2D.RaycastAll(transform.position, -Vector2.right);
        for (int i = 0; i < hitLeft.Length; i++)
        {
            if (1 >= Mathf.Abs(hitLeft[i].point.x - transform.position.x) && hitLeft[i].collider.gameObject.CompareTag("Gulicka"))
            {
                canMoveLeft = true;
                nodeLeft = hitLeft[i].collider.gameObject;
            }
        }

        RaycastHit2D[] hitRight;
        hitRight = Physics2D.RaycastAll(transform.position, Vector2.right);
        for (int i = 0; i < hitRight.Length; i++)
        {
            if (1 >= Mathf.Abs(hitRight[i].point.x - transform.position.x) && hitRight[i].collider.gameObject.CompareTag("Gulicka"))
            {
                canMoveRight = true;
                nodeRight = hitRight[i].collider.gameObject;
            }
        }

        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (startNode == true)
        {
            print("aede");
            RaycastHit2D[] hitDown;
            hitDown = Physics2D.RaycastAll(transform.position, -Vector2.up);
            for (int i = 0; i < hitDown.Length; i++)
            {
                if (1 >= Mathf.Abs(hitDown[i].point.y - transform.position.y) && hitDown[i].collider.gameObject.CompareTag("Gulicka"))
                {
                    canMoveDown = true;
                    nodeDown = hitDown[i].collider.gameObject;
                    hitDown[i].collider.gameObject.GetComponent<NodeControler>().nodeUp = gameObject;
                }
            }

            RaycastHit2D[] hitUp;
            hitUp = Physics2D.RaycastAll(transform.position, Vector2.up);
            for (int i = 0; i < hitUp.Length; i++)
            {
                if (1 >= Mathf.Abs(hitUp[i].point.y - transform.position.y) && hitUp[i].collider.gameObject.CompareTag("Gulicka"))
                {
                    canMoveUp = true;
                    nodeUp = hitUp[i].collider.gameObject;
                    hitUp[i].collider.gameObject.GetComponent<NodeControler>().nodeDown = gameObject;
                }
            }

            RaycastHit2D[] hitLeft;
            hitLeft = Physics2D.RaycastAll(transform.position, -Vector2.right);
            for (int i = 0; i < hitLeft.Length; i++)
            {
                if (1 >= Mathf.Abs(hitLeft[i].point.x - transform.position.x) && hitLeft[i].collider.gameObject.CompareTag("Gulicka"))
                {
                    canMoveLeft = true;
                    nodeLeft = hitLeft[i].collider.gameObject;
                    hitLeft[i].collider.gameObject.GetComponent<NodeControler>().nodeRight = gameObject;
                }
            }

            RaycastHit2D[] hitRight;
            hitRight = Physics2D.RaycastAll(transform.position, Vector2.right);
            for (int i = 0; i < hitRight.Length; i++)
            {
                if (1 >= Mathf.Abs(hitRight[i].point.x - transform.position.x) && hitRight[i].collider.gameObject.CompareTag("Gulicka"))
                {
                    canMoveRight = true;
                    nodeRight = hitRight[i].collider.gameObject;
                    hitRight[i].collider.gameObject.GetComponent<NodeControler>().nodeLeft = gameObject;
                }
            }
            startNode = false;
        }  
    }

    public GameObject getNodeFromDirection(string direction) 
    {
        if(direction == "up" && canMoveUp)
        {
            return nodeUp;
        }
        else if (direction == "down" && canMoveDown)
        {
            return nodeDown;
        }
        else if (direction == "right" && canMoveRight)
        {
            return nodeRight;
        }
        else if (direction == "left" && canMoveLeft)
        {
            return nodeLeft;
        }
        else
        {
            return null;
        }

    }
}
