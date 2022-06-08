using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghustsound : MonoBehaviour
{
    float time = 0;
    public AudioSource scared;
    // Start is called before the first frame update
    void Start()
    {
        PayerControler.Instance.CollideWithPower += () => {
            Playscraedsound();


        };
    }
  
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > GameInstance.gi.scaredTime && scared.isPlaying)
        {
            scared.Stop();
        }
    }

    public void Playscraedsound()
    {
        time = 0;
        scared.Play();
    }


 
        
        
            
}
