using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class deathanimation : MonoBehaviour
{

    public float speed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            speed = 0;

        }
    }

    class GameController : MonoBehaviour
    {
        void Update()
        {
            //Ding the Health
        }
    }
}
