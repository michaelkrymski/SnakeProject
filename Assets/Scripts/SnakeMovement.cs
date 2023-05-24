using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public GameObject snakePartPrefab;  // Prefab for the snake part
    private Rigidbody2D rb;
    [SerializeField] float speed = 1f;
    private float horizontalInput;
    private float verticalInput;
    private List<Transform> bodyParts = new List<Transform>();  // List to store the snake body parts

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bodyParts.Add(transform);  // Add the head of the snake to the body parts list
    }

    // Update is called once per frame
    private void Update()
    {
        float rawHInput = Input.GetAxisRaw("Horizontal");
        float rawVInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput == 0 && verticalInput == 0)
        {
            horizontalInput = 1;
            verticalInput = 0;
        }
        else if (rawHInput == horizontalInput * -1)
        {
            return;
        }
        else if (rawVInput == verticalInput * -1)
        {
            return;
        }
        else if (rawHInput != 0 && rawVInput == 0)
        {
            horizontalInput = rawHInput;
            verticalInput = 0;
        }
        else if (rawHInput == 0 && rawVInput != 0)
        {
            horizontalInput = 0;
            verticalInput = rawVInput;
        }

    }

    private void FixedUpdate()
    {
        Move();
        
    }

    private void Move()
    {
        // Move the head of the snake
        transform.position += new Vector3(horizontalInput * speed, verticalInput * speed, 0);

        // Move each body part to the position of the previous part
        for (int i = bodyParts.Count - 1; i > 0; i--)
        {
            bodyParts[i].position = bodyParts[i - 1].position;
        }
    }

    public float GetSpeed()
    {
        return speed;
    }

    // Function to add a new body part to the snake
    public void AddBodyPart()
    {
        // Instantiate a new snake part prefab
        GameObject newPart = Instantiate(snakePartPrefab, bodyParts[bodyParts.Count - 1].position, Quaternion.identity);
        bodyParts.Add(newPart.transform);
    }
}
