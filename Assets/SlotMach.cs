using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMach : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button();
        Button();
        Button();
        Button();
        Button();
        Button();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Button()
    {
        float chance = Random.Range(0, 101);
        bool mythic = true;
        
        if (chance <= 70)
        {
            Debug.Log("common");
        }
        else if (chance > 70 &&chance<90)
        {
            Debug.Log("rare");
        }
        else if (chance >= 90&& chance<99)
        {
            Debug.Log("legendary");
        }
        else if (chance >= 99 && mythic)
        {
            Debug.Log("mythic");
        }


    }
}
