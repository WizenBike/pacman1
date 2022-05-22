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
        int score = 0;
        if (Spawn.score >= 1000) score = Spawn.score / 500;

        float chance = Random.Range(0, 1000s);
        bool mythic = true;
        
        if (chance < 610-score*2)
        {
            Debug.Log("common");
        }
        else if (chance >= 610-score*2 && chance < 940 - score)
        {
            Debug.Log("rare");
        }
        else if (chance >= 940-score && chance < 990)
        {
            Debug.Log("legendary");
        }
        else if (chance >= 990 && mythic)
        {
            Debug.Log("mythic");
        }
    }
}
