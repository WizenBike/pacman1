using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{  
    static public GameInstance gi;
    public  int HP;
    public static GameObject[] hpDisplay;
    public GameObject hpPic;
    public Transform bar;
    // Start is called before the first frame update
    void Start()
    {
        gi = this;
        hpDisplay = new GameObject[1000];
    }



    // Update is called once per frame
    void Update()
    {
        DrawHP();
        if (Spawn.countOfAllBalls == Spawn.ballCount ) Win();
    }
    public void Win() 
    {
        print("U WON");
    }

    public void DrawHP()
    {
        foreach (GameObject pic in hpDisplay)
        {
            Destroy(pic);
        }
        for (int i = 0; i<HP; i++)
        {  
           Vector3 pos =  new Vector3(bar.position.x + (i * 2f), bar.position.y, bar.position.z);
           hpDisplay[i] =  Instantiate(hpPic,pos,Quaternion.identity);
        }
    }

    
}
