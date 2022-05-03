using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiOrange : EnemyControler
{
    public int a;
    public GameObject Pointer;
    // Start is called before the first frame update


    // Update is called once per frame

    protected override void SwitchToScatter()
    {


        time += Time.deltaTime;
        if (time >= scatterCooldown && ghostState == GhostStates.chase)
        {
            ghostState = GhostStates.scatter;
        }

        if (ghostState == GhostStates.scatter)
        {
            timeScatter += Time.deltaTime;

            if (timeScatter >= scatterDuration)
            {
                time = 0;
                timeScatter = 0;
                ghostState = GhostStates.chase;
            }
        }

    }

    protected override void goHome()
    {

        if (transform.position == startNode.transform.position)
        {
            print("Leblebleble");
            mc.currentNode = redNode;
        }

        if (transform.position == redNode.transform.position)
        {
            mc.currentNode = pinkNode;
        }
        if (transform.position == pinkNode.transform.position)
        {
            if (body.active != true)
            {
                mc.speed /= gainSpeedOnDeath;
                body.SetActive(true);
            }
            ghostState = GhostStates.goOutOfHome;
        }
    }

    protected override void goOutOfHome()
    {

        if (transform.position == pinkNode.transform.position)
        {
            mc.currentNode = redNode;
        }


        if (transform.position == redNode.transform.position)
        {
            mc.currentNode = startNode;
        }
        if (transform.position == startNode.transform.position)
        {
            ghostState = GhostStates.chase;
        }
    }

    protected override Vector3 PlayerPos(GameObject Player)
    {
        MovemantControler mcp = player.GetComponent<MovemantControler>();

        if (Vector2.Distance(transform.position, player.transform.position)>=8)
        {
            return player.transform.position;
        }
        else
        {
            return finder.transform.position;
        }

       

    }

}
