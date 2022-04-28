using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovemantControler : MonoBehaviour
{
    public float speed;
    public GameObject currentNode;
    public string direction;
    public string lastDirection;
    public EnemyControler ec;



    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.CompareTag("Enemy"))
        {
           ec = GetComponent<EnemyControler>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        NodeControler currentNodeControler = currentNode.GetComponent<NodeControler>();

        transform.position = Vector2.MoveTowards(transform.position,currentNode.transform.position, speed* Time.deltaTime);

        if (transform.position.x == currentNode.transform.position.x && transform.position.y == currentNode.transform.position.y) 
        {
            if (this.gameObject.CompareTag("Enemy"))
            {
                GameObject leftNode = currentNodeControler.getNodeFromDirection("left");
                GameObject rightNode = currentNodeControler.getNodeFromDirection("right");
                GameObject downNode = currentNodeControler.getNodeFromDirection("down");
                GameObject upNode = currentNodeControler.getNodeFromDirection("up");
                direction = ec.getBestTrajectory(leftNode, rightNode, upNode, downNode);

                
                
                GameObject newNode = currentNodeControler.getNodeFromDirection(direction);
                if (newNode != null)
                {
                    currentNode = newNode;
                    lastDirection = direction;
                }
                else
                {
                    direction = lastDirection;
                    newNode = currentNodeControler.getNodeFromDirection(direction);
                    if (newNode != null)
                    {
                        currentNode = newNode;
                    }
                }
            }
            if (this.gameObject.CompareTag("Player"))
            {
                GameObject newNode = currentNodeControler.getNodeFromDirection(direction);
                if (newNode != null)
                {
                    currentNode = newNode;
                    lastDirection = direction;
                }
                else
                {
                    direction = lastDirection;
                    newNode = currentNodeControler.getNodeFromDirection(direction);
                    if (newNode != null)
                    {
                        currentNode = newNode;
                    }
                }
            }
            

        }
 
    }

    public void setDirection(string newDirection)
    {
        direction = newDirection; 
    }

}
