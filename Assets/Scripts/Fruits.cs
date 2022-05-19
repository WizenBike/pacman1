using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public int fruteIndex;
    public Sprite[] pic;
    public int pints;
    public int[] scoreOnEat;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameInstance.gi.level)
        {
            case 0:
                fruteIndex = 0;
                break;
            case 1:
                fruteIndex = 0;
                break;
            case 2:
                fruteIndex = 1;

                break;
            case 3:
                fruteIndex = 2;
                break;
            case 4:
                fruteIndex = 3;
                break;
            case 5:
                fruteIndex = 4;
                break;
            case 6:
                fruteIndex = 5;
                break;
            case 7:
                fruteIndex = 6;
                break;
            case 8:
                fruteIndex = 7;
                break;
            case 9:
                fruteIndex = 8;
                break;
            case 10:
                fruteIndex = 9;
                break;
            case 11:
                fruteIndex = 10;
                break;
            case 12:
                fruteIndex = 11;
                break;
            case 13:
                fruteIndex = 12;
                break;
            default:
                fruteIndex = 12;
                break;
        }

        sr.sprite = pic[fruteIndex];

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Spawn.score += scoreOnEat[fruteIndex];
            Destroy(gameObject);
        }

    }
}