using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    public int nodeAddedOnCatch;
    public SpriteRenderer sr;
    public bool unDestroyed = true;
    public bool unKillable = false;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (unKillable == false)
        {
            if (collision.gameObject.CompareTag("Wall") )
            {
                Destroy(gameObject);
                Spawn.countOfAllBalls--;
            }

            if (collision.gameObject.CompareTag("PowerPalet"))
            {
                unDestroyed = false;
                sr.color = new Color(1f, 1f, 1f, 0f);
                Spawn.countOfAllBalls--;

            }

            if (collision.gameObject.CompareTag("Player") && unDestroyed == true)
            {
                AddScore();
            }
        }
        
        
    }
       public void AddScore()
       {
        Spawn.score += nodeAddedOnCatch;
        Spawn.ballCount +=1;
        print(Spawn.ballCount);
        sr.color = new Color(1f,1f,1f,0f);
        unDestroyed = false;


       }
     
}
