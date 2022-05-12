using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : MonoBehaviour
{  
    static public GameInstance gi;
    public int HP = 5;
    
    public int[] levels;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        if (gi == null)
        {
            gi = this;
            
           
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }

        
       
    }

    

    // Update is called once per frame
    void Update()
    {
       
        if (Spawn.countOfAllBalls == Spawn.ballCount)
        {
            Win();
            
        }
        else if (HP <0)
        {
            Lose();

            level = 0;
            HP = 5;
        }
    }

    public void Lose()
    {
        SceneManager.LoadScene(0);
    }
    public void Win() 
    {
        print("U WON");
        if (level == levels.Length -1)
        {
            level = 0;
        }
        else
        {
            level++;
        }
        
        SceneManager.LoadScene(levels[level]); 
    }

   

    
}
