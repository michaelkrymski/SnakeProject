using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] GameObject fruit;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<GameManager>().IncrementScore(1);
        CreateRandomFruit();
        Destroy(gameObject);
    }

    private void CreateRandomFruit()
    {
        float x = Random.Range(-23.5f, 23.5f);
        float y = Random.Range(-11.5f, 11.5f);
        GameObject newFruit = Instantiate(fruit, new Vector3(x, y, 0), Quaternion.identity);
        newFruit.GetComponent<Fruit>().fruit = fruit;
    }
}
