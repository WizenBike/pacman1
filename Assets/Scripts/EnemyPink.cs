using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPink : EnemyControler
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

        if (mcp.direction == "up")
        {
            Pointer.transform.position = new Vector2(player.transform.position.x - 2, player.transform.position.y + 4);
            return new Vector2(player.transform.position.x - 2, player.transform.position.y + 4);
        }
        else if (mcp.direction == "down")
        {
            Pointer.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - 4);
            return new Vector2(player.transform.position.x, player.transform.position.y - 4);
        }
        else if (mcp.direction == "right")
        {
            Pointer.transform.position = new Vector2(player.transform.position.x + 4, player.transform.position.y);
            return new Vector2(player.transform.position.x + 4, player.transform.position.y);
        }
        else if (mcp.direction == "left")
        {
            Pointer.transform.position = new Vector2(player.transform.position.x - 4, player.transform.position.y);
            return new Vector2(player.transform.position.x - 4, player.transform.position.y);
        }

        return player.transform.position;

    }
}
