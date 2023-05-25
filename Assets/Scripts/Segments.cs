using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segments : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(other.gameObject.GetComponent<SnakeManager>().ExitGameAsLoss(3f));
        }  
    }
}
