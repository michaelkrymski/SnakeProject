using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] GameObject fruit;
    [SerializeField] Scoring score;
    [SerializeField] int maxScore;
    private AudioSource biteSound;

    private void Start()
    {
        biteSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<GameManager>().IncrementScore(1);
            score.UpdateScore(1, maxScore);
            other.transform.parent.GetComponent<SnakeManager>().AddBodyParts();
            CreateRandomFruit();
            biteSound.Play();
            Destroy(gameObject);
        }
    }

    private void CreateRandomFruit()
    {
        float x = Random.Range(-20.5f, 20.5f);
        float y = Random.Range(-10.5f, 10.5f);
        GameObject newFruit = Instantiate(fruit, new Vector3(x, y, 0), Quaternion.identity);
        newFruit.GetComponent<Fruit>().fruit = fruit;
        newFruit.GetComponent<Fruit>().score = score;
    }
}
