using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] GameObject fruit;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<GameManager>().IncrementScore(1);
            other.transform.parent.GetComponent<SnakeManager>().AddBodyParts();
            CreateRandomFruit();
            Destroy(gameObject);
        }
    }

    private void CreateRandomFruit()
    {
        float x = Random.Range(-21.5f, 21.5f);
        float y = Random.Range(-10.5f, 10.5f);
        GameObject newFruit = Instantiate(fruit, new Vector3(x, y, 0), Quaternion.identity);
        newFruit.GetComponent<Fruit>().fruit = fruit;
    }
}
