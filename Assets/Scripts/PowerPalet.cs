using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPalet : MonoBehaviour
{
    public int scoreOnCollect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            PayerControler.Instance.CollideWithPower?.Invoke();
            Spawn.score += scoreOnCollect;
            Destroy(gameObject);
        }
    }
}
