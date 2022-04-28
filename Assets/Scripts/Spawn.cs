using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Spawn : MonoBehaviour
{
    public float windowXStart;
    public float windowYStart;
    public GameObject ball;
    public Vector2 windowSize;
    public Vector2 tileSize;
    public static int ballCount;
    public static int score;
    public TMP_Text scoreT;
    public GameObject packman;
    public  static int countOfAllBalls;
    public static int currentBallsInScene;

    public static Spawn instance;
    // Start is called before the first frame update
    void Awake()
    {
        windowXStart = transform.position.x;
        windowYStart = transform.position.y;
        for (float x = 0 ; x <= windowSize.x ; x += 1) 
        {
            for (float y = 0; y <= windowSize.y ; y += 1)
            {
                countOfAllBalls++;
                Vector2 pos = new Vector2(windowXStart + x + 1.5f,windowYStart - y - 1.5f); 
                Instantiate(ball,pos,Quaternion.identity);
               
            }
        }

        instance = this;
    }
    void Update()
    {
        
        packman.SetActive(true);
        scoreT.text =  score.ToString();
    }



}
