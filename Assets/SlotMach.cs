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
    public bool shuffling = false;



    

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

    IEnumerator Shafle(Sprite[] rarity)
    {   
        print("Moj ti boh ");
        float wait = 0.01f ;
        int N = 0;
        for (int i = 0; i < 40; i++)
        {
            if (N == shafle.Count-1) N=0 ;
            N++; 
            sr.sprite = shafle[N];
            yield return new WaitForSeconds(wait);
            wait += 0.01f;
        }
        int rand = Random.Range(0, rarity.Length);
        sr.sprite = rarity[rand];

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
            skyns = comon;
        }
        //33%
        else if (chance >= 610-score*2 && chance < 940 - score)
        {
            Debug.Log("rare");
            skyns = rare;
        }
        //5%
        else if (chance >= 940-score && chance < 990)
        {
            Debug.Log("legendary");
            skyns = legendary;
        }
        //1%
        else if (chance >= 990)
        {
            Debug.Log("mythic");
        }
        if (shuffling == false)
        {
            shuffling = true;
            StartCoroutine(Shafle(comon));
            

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
        if (!shuffling) Button();
    }


}
