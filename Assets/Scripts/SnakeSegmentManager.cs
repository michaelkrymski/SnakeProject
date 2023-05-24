using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSegmentManager : MonoBehaviour
{
    private List<GameObject> segments = new List<GameObject>();
    [SerializeField] GameObject segmentPrefab;

    private void Start()
    {
        //segments.Add(gameObject);
    }
    
    public void AddSegment()
    {
        GameObject newSegment = Instantiate(segmentPrefab, transform.position, Quaternion.identity);
        segments.Add(newSegment);
        UpdatePositions();
    }

    private void UpdatePositions()
    {
        
    }

    private void FixedUpdate()
    {
        UpdatePositions();
    }
}
