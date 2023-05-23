using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSegmentManager : MonoBehaviour
{
    private List<Transform> segments = new List<Transform>();
    [SerializeField] GameObject segmentPrefab;

    private void Start()
    {
        segments.Add(transform);
    }
    
    public void AddSegment()
    {
        GameObject newSegment = Instantiate(segmentPrefab, transform.position, Quaternion.identity);
        segments.Add(newSegment.transform);
        UpdatePositions();
    }

    private void UpdatePositions()
    {
        for(int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }
        segments[0].position = transform.position;
    }

    private void FixedUpdate()
    {
        UpdatePositions();
    }
}
