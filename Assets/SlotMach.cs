using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SlotMach : MonoBehaviour
{
    // Start is called before the first frame update
   
    
    public Sprite[] comon;
    public Sprite[] rare;
    public Sprite[] legendary;
    public Sprite[] mithic;
    public string rarita;
    public bool shuffling = false;
    public SpriteRenderer svetlo;
    public Animator machine;
 
    



    

    List<Sprite> shafle;
    SpriteRenderer sr;

   
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        shafle = new List<Sprite>();
       
        foreach (Sprite skyn in comon)
        {
            shafle.Add(skyn);
        }
        foreach (Sprite skyn in rare)
        {
            shafle.Add(skyn);
        }
        foreach (Sprite skyn in legendary)
        {
            shafle.Add(skyn);
        }


    }

    int FindID(Sprite skin)
    {
        foreach(Sprite sprite in shafle)
        {
         if(skin == sprite)
            {
                return shafle.IndexOf(sprite); 
            }
        }
        return 0;
    }

    IEnumerator Shafle(string rarity)
    {
        List<Skin> skinyNaVyber = new List<Skin>();
        print("Moj ti boh ");
        float wait = 0.01f ;
        int N = 0;
        for (int i = 0; i < 40; i++)
        {
            print(N);
            if (N == GameInstance.gi.mySkins.Length -1) {
                N = 0;
            } else
            {
                N++;
            }
            
            sr.sprite = GameInstance.gi.mySkins[N].skin;
            yield return new WaitForSeconds(wait);
            wait += 0.01f;
        }
        foreach (Skin mojSkinu in GameInstance.gi.mySkins)
        {
         if(mojSkinu.rarity == rarity)
            {
                skinyNaVyber.Add(mojSkinu);
            }
        }
        int rand = Random.Range(0, skinyNaVyber.Count );
        sr.sprite = skinyNaVyber[rand].skin;

        print(GameInstance.gi.skinsIds + " Labla ???");
        print(skinyNaVyber[rand].index + " ???");

        GameInstance.gi.AddSkin(skinyNaVyber[rand].index);
        ChangeCollor(skinyNaVyber[rand].rarity);


        machine.SetBool("pressed", false);
        shuffling = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Button()
    {
        int score = 0;
        if (Spawn.score >= 1000) score = Spawn.score / 500;

        float chance = Random.Range(0, 1000);
      
        Sprite[] skyns; 
        //61%
        if (chance < 610-score*2)
        {
            Debug.Log("common");
            rarita = "comon";
        }
        //33%
        else if (chance >= 610-score*2 && chance < 940 - score)
        {
            Debug.Log("rare");
            rarita = "rare";
        }
        //5%
        else if (chance >= 940-score && chance < 990)
        {
            Debug.Log("legendary");
            rarita = "legendary";
        }
        //1%
        else if (chance >= 990)
        {
            Debug.Log("mythic");
        }
        if (shuffling == false)
        {
            shuffling = true;
            StartCoroutine(Shafle("comon"));
            

        }

    }

    public void Comon()
    {
     
    }
    public void Rare()
    {

    }
    public void Legenadry()
    {

    }
    public void Mythic()
    {

    }

    public void Rolling()
    {
        machine.SetBool("pressed", true);
        if (!shuffling) Button();

    }

    public void ChangeCollor(string rarita)
    {
        
     if (rarita == "comon")
     {
            svetlo.color = new Color(0f,115f,50f,225);     
     }else if(rarita == "rare")
     {
            svetlo.color = new Color(0f, 50f, 115f, 225);
     }
     else if(rarita == "legendary")
     {
            svetlo.color = new Color(119, 119, 119, 225);
     }
     else 
     {
            svetlo.color = new Color(255, 19, 0, 225);
     }
     
    }
   


}

