using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuspawner : MonoBehaviour
{
    public GameObject[] menuenemies;
    public Transform spawnpoint;

    private int rand;

    public float startTimeSpawns;
    private float TimeSpawns;

    private void Start()
    {
        TimeSpawns = startTimeSpawns;
    }

    private void Update()
    {
        Instantiate(menuenemies[0], spawnpoint.transform.position, Quaternion.identity);

    }
}
