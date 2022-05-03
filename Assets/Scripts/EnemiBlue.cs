using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiBlue : EnemyControler
{
    // Start is called before the first frame update
    public GameObject Pointer;
    public GameObject RedGhost;

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

            mc.currentNode = redNode;
        }


        if (transform.position == redNode.transform.position)
        {
            mc.speed /= gainSpeedOnDeath;
            body.SetActive(true);
            ghostState = GhostStates.goOutOfHome;
        }
    }

    protected override void goOutOfHome()
    {



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

        Pointer.transform.position = player.transform.position - (RedGhost.transform.position - (Player.transform.position));



        return player.transform.position-(RedGhost.transform.position - (Player.transform.position));

    }
}
