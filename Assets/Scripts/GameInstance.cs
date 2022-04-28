using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{  
    static public GameInstance gi;

    // Start is called before the first frame update
    void Start()
    {
        gi = this;
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Spawn.countOfAllBalls == Spawn.ballCount ) Win();
    }
    public void Win() 
    {
        print("U WON");
    }
}
