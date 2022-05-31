using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : MonoBehaviour
{  
    static public GameInstance gi;
    public int HP = 5;
    public GameObject Fruit;
    public int[] levels;
    public int level = 1;
    public int levelIndex;
    public float fruteTimer;
    public int fruteTime;
    public bool fruitSpawned = false;
    public int currentSkynID;

    [HideInInspector]
    public List<int> skinsIds;
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

        if (!PlayerPrefs.HasKey("skins"))
        {
            PlayerPrefs.SetString("skins", "");
        }

        PlayerPrefs.SetString("skins", "0");



        skinsIds = GetSkinsIDS();
       
    }

    

    // Update is called once per frame
    void Update()
    {
       
        if (Spawn.countOfAllBalls == Spawn.ballCount && Spawn.countOfAllBalls > 0)
        {
            Win();
            


        }
        else if (HP <0)
        {
            Lose();
            levelIndex = 0;
            level = 1;
            HP = 5;
        }

        fruteTimer += Time.deltaTime;
        if (fruteTimer> fruteTime && fruitSpawned == false && Spawn.countOfAllBalls > 0)
        {
            SpawnFruit();
        }
    }

    public void Lose()
    {
        fruitSpawned = false;
        SceneManager.LoadScene(0);
    }
    public void Win() 
    {
        fruitSpawned = false;
        level++;
        print("U WON");
        if (levelIndex == levels.Length -1)
        {
            levelIndex = 0;
        }
        else
        {
            levelIndex ++; 
        }
        
        SceneManager.LoadScene(levels[levelIndex]); 
    }
    public void SpawnFruit()
    {
        Instantiate(Fruit, transform.position, Quaternion.identity) ;
        fruitSpawned = true;
    }

    public List<int> GetSkinsIDS()
    {
        string[] stringTexts;
        if (PlayerPrefs.HasKey("skins"))
        {
            stringTexts = PlayerPrefs.GetString("skins").Split(" ");

            List<int> ids = new List<int>();

            foreach (string id in stringTexts)
            {
                ids.Add(int.Parse(id));
            }

            return ids;
        }
        else
        {
            return null;
        }
    }

    public void AddSkin(int id)
    {
        skinsIds.Add(id);
    }

    private void OnApplicationQuit()
    {

        PlayerPrefs.SetString("skins", GetSkinsToString());
        PlayerPrefs.Save();
    }

    private string GetSkinsToString()
    {
        string s = "";

        foreach (int i in skinsIds)
        {
            s += " " +  i.ToString();
        }

        return s;
    }





}
