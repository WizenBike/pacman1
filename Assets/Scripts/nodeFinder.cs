using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodeFinder : MonoBehaviour
{
    public  GameObject findedNode;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gulicka"))
        {
            findedNode = collision.gameObject;
        }
    }
}
