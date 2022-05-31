using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinStand : MonoBehaviour
{
    List<Skin> avableSkyns = new List<Skin>();
    public int Index = 0;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        //sr.sprite = skyns[GameInstance.gi.skinsIds[skynIndex]];
        foreach (Skin mojSkin in GameInstance.gi.mySkins)
        {
            Debug.LogError(mojSkin.skin);
            if (GameInstance.gi.skinsIds.Contains(mojSkin.index))
            {
                Debug.LogError(mojSkin.skin + "Naseusem");
                avableSkyns.Add(mojSkin);
            }              

        }
        sr.sprite = avableSkyns[0].skin;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Left()
    {
        if (Index > 0)
        {
            Index--;
            sr.sprite = avableSkyns[Index].skin;
        }

        
    }
    public void Right()
    {
        if (Index < GameInstance.gi.skinsIds.Count-1)
        {
            Index++;
            sr.sprite = avableSkyns[Index].skin;
        }
    }

    public void Pick()
    {
        GameInstance.gi.currentSkynID = avableSkyns[Index].index;
        Debug.LogError(avableSkyns[Index].index);
    }

   public void LoadSkyn()
   {
        sr.sprite = avableSkyns[Index].skin;
    }



}
