using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{
    public GameObject worldPath;
    private PathFinder PathFinder;
    private WorldGrid WorldGrid;
    private List<NodeForGrid> path;
    NodeForGrid endNode;
    NodeForGrid startNode;
    float step;
    float progress = 0;

    private void Start()
    {
        PathFinder = worldPath.GetComponent<PathFinder>();
        WorldGrid = worldPath.GetComponent<WorldGrid>();
        startNode = WorldGrid.NodeFromWorldPoint(transform.position);
        endNode = WorldGrid.NodeFromWorldPoint(PathFinder.target.position);
        path = PathFinder.RetracePath(startNode, endNode);
        step = 0.05f;
    }

    private void Update()
    {
        /*PathFinder = worldPath.GetComponent<PathFinder>();
        WorldGrid = worldPath.GetComponent<WorldGrid>();
        endNode = WorldGrid.NodeFromWorldPoint(transform.position);
        startNode = WorldGrid.NodeFromWorldPoint(PathFinder.target.position);
        path = PathFinder.RetracePath(startNode, endNode);*/
    }

    private void FixedUpdate()
    {
        if (path.Count != 1)
        {
            if (Vector3.Distance(transform.position, path[0].worldPosition) <= 0.01f)
            {
                progress = 0;
                path.RemoveAt(0);
            }
            transform.position = Vector2.Lerp(transform.position, path[0].worldPosition, progress);
            progress += step;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(2.5f, 1, 1.3f));
        if (startNode != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(startNode.worldPosition, 0.05f);
        }
        if (endNode != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(endNode.worldPosition, 0.05f);
        }
        if (path != null)
        {
            foreach (NodeForGrid n in path)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawSphere(n.worldPosition, 0.005f);
                if (n.parent != null)
                {
                    Gizmos.DrawLine(n.worldPosition, n.parent.worldPosition);
                }
            }
        }
    }
}
