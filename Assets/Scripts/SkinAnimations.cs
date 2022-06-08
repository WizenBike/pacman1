using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinAnimations : MonoBehaviour
{
    public Animator animation;
    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {
        if (animation == null)
            animation = GetComponent<Animator>();
        if(animation!=null && GameInstance.gi!=null)
            animation.SetInteger("skinIndex", GameInstance.gi.currentSkynID);
        //print(GameInstance.gi.currentSkynID + "AHOOOOOOOOOOOOOOOOOJ");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
