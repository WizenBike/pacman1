using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinAnimations : MonoBehaviour
{
    Animator animation;
    // Start is called before the first frame update
    private void Awake()
    {

        animation = GetComponent<Animator>();
        animation.SetInteger("skinIndex",GameInstance.gi.currentSkynID);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
