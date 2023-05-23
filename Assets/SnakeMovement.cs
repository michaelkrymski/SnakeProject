using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed = 1f;
    public float horizontalInput;
    public float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float rawHInput = Input.GetAxisRaw("Horizontal");
        float rawVInput = Input.GetAxisRaw("Vertical");

        if(horizontalInput == 0 && verticalInput == 0)
        {
            horizontalInput = 1;
            verticalInput = 0;
        }
        else if(rawHInput == horizontalInput * -1)
        {
            return;
        }
        else if(rawVInput == verticalInput * -1)
        {
            return;
        }
        else if(rawHInput != 0 && rawVInput == 0)
        {
            horizontalInput = rawHInput;
            verticalInput = 0;
        }
        else if(rawHInput == 0 && rawVInput != 0)
        {
            horizontalInput = 0;
            verticalInput = rawVInput;
        }
        // else if(rawHInput != 0 && rawVInput != 0)
        // {
        //     horizontalInput = rawHInput;
        //     verticalInput = 0;
        // }
    }

    void FixedUpdate()
    {   
        transform.position = transform.position + new Vector3(horizontalInput * speed, verticalInput * speed, 0);
    }
}
