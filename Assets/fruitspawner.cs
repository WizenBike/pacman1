using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitspawner : MonoBehaviour
{
    public GameObject[] fruits;
    [SerializeField]
    float timeToSpawn;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            Instantiate(fruits[Random.Range(0,fruits.Length)],transform.position,Quaternion.identity);
        }
    }
}
