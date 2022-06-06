using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinAnimations : MonoBehaviour
{
    Animator animation;
    // Start is called before the first frame update
    private void Awake()
    {
       
    }
    void Start()
    {
        animation = GetComponent<Animator>();
        print(this.gameObject.name);
        animation.SetInteger("skinIndex", GameInstance.gi.currentSkynID);

        print(GameInstance.gi.currentSkynID + "AHOOOOOOOOOOOOOOOOOJ");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
