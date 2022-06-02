using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiRed : EnemyControler
{
    public int pointsToSwitchOffScatter;
    public float stayInHomeTime;
    public bool stayInHome;
    public AudioSource eyeR;
    float timeS;



    protected override void GetStartPos()
    {
        transform.position = startNode.transform.position;
    }
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

        if (!eyeR.isPlaying && !body.active)
        {
            eyeR.Play();
        }
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
                eyeR.Pause();
            }
            ghostState = GhostStates.goOutOfHome;
           
        }
    }

    protected override void goOutOfHome()
    {

        if (stayInHome == true)
        {
            timeS += Time.deltaTime;
            if (stayInHomeTime < timeS)
            {
                stayInHome = false;
                timeS = 0;
            }
        }



        if (stayInHome == false)
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

    protected override void posAfterCatch()
    {
        mc.currentNode = startNode;

        transform.position = startNode.transform.position;
        stayInHome = true;
        ghostState = GhostStates.chase;

        _anim.SetBool("isScared", false);
        if (body.active != true)
        {
            mc.speed /= gainSpeedOnDeath;
            body.SetActive(true);
        }

    }
}
