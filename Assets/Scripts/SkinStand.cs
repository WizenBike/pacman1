using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinStand : MonoBehaviour
{
    public Sprite[] skyns;
    public int skynIndex = 0;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = skyns[GameInstance.gi.skinsIds[skynIndex]];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Left()
    {
        if (skynIndex > 0)
        {
            skynIndex--;
            sr.sprite = skyns[GameInstance.gi.skinsIds[skynIndex]];
        }

        
    }
    public void Right()
    {
        if (skynIndex < GameInstance.gi.skinsIds.Count-1)
        {
            skynIndex++;
            sr.sprite = skyns[GameInstance.gi.skinsIds[skynIndex]];
        }
    }

    public void Pick()
    {

    }

   public void LoadSkyn()
   {
        sr.sprite = skyns[GameInstance.gi.skinsIds[skynIndex]]; 
   }

}
