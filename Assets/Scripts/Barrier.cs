using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(other.transform.parent.GetComponent<SnakeManager>().ExitGameAsLoss(2f));
        }
    }
}
