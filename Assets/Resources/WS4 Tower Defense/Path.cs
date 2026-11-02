using UnityEngine;
using System.Collections.Generic;

public class Path : MonoBehaviour
{
    [SerializeField] Transform node1;
    [SerializeField] Transform node2;
    [SerializeField] Transform node3;
    [SerializeField] Transform node4;
    [SerializeField] Transform node5;
    [SerializeField] Transform node6;
    [SerializeField] Transform node7;
    [SerializeField] Transform node7End;
    [SerializeField] Transform node8;
    [SerializeField] Transform node8End;
    
    
    //enemies pass in their choice of end path, this function returns their personal list of nodes
    public List<Transform> GetPathNodes(bool chooseNode8)
    {
        List<Transform> myNodes = new List<Transform> { node1, node2, node3, node4, node5, node6, node7 };

        if (chooseNode8)
        {
            myNodes.Add(node8);
            myNodes.Add(node8End);
        }
        else
        {
            myNodes.Add(node7End);
        }

        return myNodes;
    }

    //find total length of a list of nodes 
    public float GetPathLength(List<Transform> nodes)
    {
        float totalLength = 0f;
        for (int i = 0; i < nodes.Count - 1; i++)
        {
            if (nodes[i] != null && nodes[i + 1] != null)
            {
                Vector2 posA = nodes[i].position;
                Vector2 posB = nodes[i + 1].position;
                totalLength += Vector2.Distance(posA, posB);
            }
        }
        return totalLength;
    }

    //find where you are exactly given how far along you are on the path 
    public Vector3 GetPointAtDistance(List<Transform> nodes, float distance, out int currentSegmentIndex)
    {
        currentSegmentIndex = 0;
        float accumulatedDistance = 0f;

        for (int i = 0; i < nodes.Count - 1; i++)
        {
            if (nodes[i] == null || nodes[i + 1] == null) continue;

            Vector2 posA = nodes[i].position;
            Vector2 posB = nodes[i + 1].position;
            float segmentLength = Vector2.Distance(posA, posB);

            if (distance <= accumulatedDistance + segmentLength)
            {
                currentSegmentIndex = i;
                float distanceIntoSegment = distance - accumulatedDistance;
                float t = segmentLength > 0 ? distanceIntoSegment / segmentLength : 0f;
                return Vector3.Lerp(nodes[i].position, nodes[i + 1].position, t);
            }

            accumulatedDistance += segmentLength;
        }

        currentSegmentIndex = nodes.Count - 2;
        return nodes[nodes.Count - 1].position;
    }
}
