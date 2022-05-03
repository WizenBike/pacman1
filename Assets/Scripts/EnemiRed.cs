using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiRed : EnemyControler
{
    public int pointsToSwitchOffScatter;

    protected override void SwitchToScatter()
    {
        if (Spawn.ballCount <= pointsToSwitchOffScatter)
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
    }
    protected override void goHome()
    {

        if (transform.position == startNode.transform.position)
        {
            
            mc.currentNode = redNode;
        }

        
        if (transform.position == redNode.transform.position)
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



        if (transform.position == redNode.transform.position)
        {
            mc.currentNode = startNode;
        }
        if (transform.position == startNode.transform.position)
        {
            ghostState = GhostStates.chase;
        }
    }
}
