using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportacia : MonoBehaviour
{
    public static GameObject teleportLeft;
    public static GameObject teleportRight;
    public MovemantControler mc;

    private void Start()
    {
        mc = gameObject.GetComponent<MovemantControler>();
    }
    private void Update()
    {
        if(transform.position == teleportLeft.transform.position &&(mc.direction == "left" || mc.lastDirection == "left"))
        {
            transform.position = teleportRight.transform.position;
            mc.currentNode = teleportRight;

        }
        if (transform.position == teleportRight.transform.position && (mc.direction == "right" || mc.lastDirection == "right"))
        {
            transform.position = teleportLeft.transform.position;
            mc.currentNode = teleportLeft;

        }
    }




}
