using UnityEngine;
using System.Collections.Generic;

public class PathFinder : MonoBehaviour
{

    public List<NodeForGrid> displayVisited = new List<NodeForGrid>();
    public Transform target;
    WorldGrid grid;

    void Awake()
    {
        grid = GetComponent<WorldGrid>();
    }

    private void Start()
    {
        FindPath(target.position);
    }

    void FindPath(Vector2 targetPos)
    {
        NodeForGrid startNode = grid.NodeFromWorldPoint(targetPos);

        List<NodeForGrid> openSet = new List<NodeForGrid>();
        HashSet<NodeForGrid> closedSet = new HashSet<NodeForGrid>();
        openSet.Add(startNode);

        NodeForGrid currentNode;
        while (openSet.Count > 0)
        {
            currentNode = openSet[0];
            displayVisited.Add(currentNode);
            closedSet.Add(currentNode);
            openSet.Remove(currentNode);
            foreach (NodeForGrid n in grid.GetNeighbours(currentNode))
            {
                if (!n.walkable || closedSet.Contains(n))
                {
                    continue;
                }
                if (!openSet.Contains(n))
                {
                    n.parent = currentNode;
                    openSet.Add(n);
                }
            }
        }
    }

    public List<NodeForGrid> RetracePath(NodeForGrid startNode, NodeForGrid endNode)
    {
        //строим путь от конечной ноды до начальной ноды, начиная с конечной
        List<NodeForGrid> path = new List<NodeForGrid>();
        NodeForGrid currentNode = startNode;

        while (currentNode != endNode)
        {
            path.Add(currentNode);
            if (currentNode.parent == null)
            {
                break;
            }
            currentNode = currentNode.parent;
        }
        return path;
    }

    //int GetDistance(NodeForGrid nodeA, NodeForGrid nodeB)
    //{
    //    float dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
    //    float dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

    //    if (dstX > dstY)
    //        return 14 * dstY + 10 * (dstX - dstY);
    //    return 14 * dstX + 10 * (dstY - dstX);
    //}

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(2.5f, 1, 1.3f));

        if (grid != null)
        {
            foreach (NodeForGrid n in displayVisited)
            {
                Gizmos.color = Color.black;
                // Gizmos.DrawSphere(n.worldPosition, 0.005f);
                if (n.parent != null)
                {
                    Gizmos.DrawLine(n.worldPosition, n.parent.worldPosition);
                }
            }
        }
    }
}