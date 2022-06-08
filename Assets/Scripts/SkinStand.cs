using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkinStand : MonoBehaviour
{
    List<Skin> avableSkyns = new List<Skin>();
    public int Index = 0;
    SpriteRenderer sr;
    [SerializeField]
    TMP_Text ct;
    

    // Start is called before the first frame update
    void Start()
    {
        
        sr = GetComponent<SpriteRenderer>();
        //sr.sprite = skyns[GameInstance.gi.skinsIds[skynIndex]];
        foreach (Skin mojSkin in GameInstance.gi.mySkins)
        {
            if (GameInstance.gi.skinsIds.Contains(mojSkin.index))
            {
                Debug.LogError(mojSkin.index + "Naseusem");
                avableSkyns.Add(mojSkin);
            }              

        }
        sr.sprite = avableSkyns[0].skin;
        foreach(int i in GameInstance.gi.skinsIds){
            print(i);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Klick(); 
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
    }

   public void LoadSkyn()
   {
        sr.sprite = avableSkyns[Index].skin;
   }

    public void Klick()
    {
        if (GameInstance.gi.currentSkynID == avableSkyns[Index].index)
        {
            ct.color = new Color(239, 236, 0, 225);
        }
        else
        {
            ct.color = new Color(0, 174, 249, 225);
        }

    }



}
