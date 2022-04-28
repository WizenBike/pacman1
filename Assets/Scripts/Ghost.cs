using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float castLenght;
    public float distance;
    Rigidbody2D rb;
    public LayerMask lm;
    bool up;
    bool right;
    bool left;
    bool down;


    // Start is called before the first frame update
    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
        Right();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   // Ray cast smerujuci a kontrolujuci hornu stranu enemaka
        Vector2 endPosUp = transform.position + transform.up * castLenght - transform.right * distance;
        Vector2 endPosUp2 = transform.position + transform.up * castLenght + transform.right * distance;

        RaycastHit2D hitUp = Physics2D.Linecast(transform.position - transform.right * distance, endPosUp, lm);
        RaycastHit2D hitUp2 = Physics2D.Linecast(transform.position + transform.right * distance, endPosUp2, lm);

        if ((hitUp.collider != null || hitUp.collider != null) && rb.velocity.y == 1)
        {
            Debug.DrawLine(transform.position - transform.right * distance, endPosUp, Color.red);
            Debug.DrawLine(transform.position + transform.right * distance, endPosUp2, Color.red);
            up = true;
            RandomDir();

        }
        else
        {
            up = false;

            Debug.DrawLine(transform.position - transform.right * distance, endPosUp, Color.green);
            Debug.DrawLine(transform.position + transform.right * distance, endPosUp2, Color.green);
        }

        // Ray cast smerujuci a kontrolujuci dolnu stranu enemaka
        Vector2 endPosDown = transform.position - transform.up * castLenght - transform.right * distance;
        Vector2 endPosDown2 = transform.position - transform.up * castLenght + transform.right * distance;
        RaycastHit2D hitDown = Physics2D.Linecast(transform.position - transform.right * distance, endPosDown, lm);
        RaycastHit2D hitDown2 = Physics2D.Linecast(transform.position + transform.right * distance, endPosDown2, lm);

        if ((hitDown.collider != null || hitDown2.collider != null) && rb.velocity.y == -1)
        {
            Debug.DrawLine(transform.position - transform.right * distance, endPosDown, Color.red);
            Debug.DrawLine(transform.position + transform.right * distance, endPosDown2, Color.red);
            down = true;
            RandomDir();

        }
        else
        {
            down = false;
            Debug.DrawLine(transform.position - transform.right * distance, endPosDown, Color.green);
            Debug.DrawLine(transform.position + transform.right * distance, endPosDown2, Color.green);
        }
        // Ray cast smerujuci a kontrolujuci pravu stranu enemaka
        Vector2 endPosRight = transform.position + transform.right * castLenght - transform.up * distance;
        Vector2 endPosRight2 = transform.position + transform.right * castLenght + transform.up * distance;
        RaycastHit2D hitRight = Physics2D.Linecast(transform.position - transform.up * distance, endPosRight, lm);
        RaycastHit2D hitRight2 = Physics2D.Linecast(transform.position + transform.up * distance, endPosRight2, lm);
        if ((hitRight.collider != null || hitRight2.collider != null) && rb.velocity.x == 1)
        {
            right = true;
            RandomDir();
            Debug.DrawLine(transform.position - transform.up * distance, endPosRight, Color.red);
            Debug.DrawLine(transform.position + transform.up * distance, endPosRight2, Color.red);
        }
        else
        {
            right = false;

            Debug.DrawLine(transform.position - transform.up * distance, endPosRight, Color.green);
            Debug.DrawLine(transform.position + transform.up * distance, endPosRight2, Color.green);
        }
        // Ray cast smerujuci a kontrolujuci lavu stranu enemaka
        Vector2 endPosLeft = transform.position - transform.right * castLenght - transform.up * distance;
        Vector2 endPosLeft2 = transform.position - transform.right * castLenght + transform.up * distance;
        RaycastHit2D hitLeft = Physics2D.Linecast(transform.position - transform.up * distance, endPosLeft, lm);
        RaycastHit2D hitLeft2 = Physics2D.Linecast(transform.position + transform.up * distance, endPosLeft2, lm);
        if ((hitLeft.collider != null || hitLeft2.collider != null) && rb.velocity.x == -1)
        {
            left = true;
            RandomDir();
            Debug.DrawLine(transform.position - transform.up * distance, endPosLeft, Color.red);
            Debug.DrawLine(transform.position + transform.up * distance, endPosLeft, Color.red);
        }
        else
        {
            left = false;
            Debug.DrawLine(transform.position - transform.up * distance, endPosLeft, Color.green);
            Debug.DrawLine(transform.position + transform.up * distance, endPosLeft2, Color.green);
        }
    }
    //Navádzanie enemáka ku hrácovy






    private void RandomDir()
    {
        List<string> dir = new List<string>();

        if (!up)
            dir.Add("up");
        if (down == false)

            dir.Add("down");
        if (right == false)

            dir.Add("left");
        if (left == false)

            dir.Add("right");
        string rand = dir[Random.Range(0, dir.Count)];


        switch (rand)
        {
            case "up":
                Up();
                break;
            case "Down":
                Down();
                break;
            case "left":
                Left();
                break;
            case "Right":
                Right();
                break;

        }


    }
    private void Up()
    {
        rb.velocity = new Vector2(0, 1);
    }
    private void Down()
    {
        rb.velocity = new Vector2(0, -1);
    }
    private void Left()
    {
        rb.velocity = new Vector2(-1, 0);
    }
    private void Right()
    {
        rb.velocity = new Vector2(1, 0);
    }
}
