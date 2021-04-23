using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{
    public float step;
    public float distance;
    public int hp;

    private GameObject worldPath;
    private PathFinder PathFinder;
    private WorldGrid WorldGrid;
    private List<NodeForGrid> path;
    private NodeForGrid endNode;
    private NodeForGrid startNode;
    private float progress = 0;

    private void Start()
    {
        worldPath = GameObject.Find("WorldGrid");
        PathFinder = worldPath.GetComponent<PathFinder>();
        WorldGrid = worldPath.GetComponent<WorldGrid>();
        startNode = WorldGrid.NodeFromWorldPoint(transform.position);
        endNode = WorldGrid.NodeFromWorldPoint(PathFinder.target.position);
        path = PathFinder.RetracePath(startNode, endNode);
    }

    private void FixedUpdate()
    {
        if (path.Count != 1)
        {
            if (Vector3.Distance(transform.position, path[0].worldPosition) <= distance)
            {
                progress = 0;
                path.RemoveAt(0);
            }
            transform.position = Vector2.Lerp(transform.position, path[0].worldPosition, progress);
            progress += step;
        }
    }
    private void Update()
    {
        if (hp == 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D bullet)
    {
        if (bullet.transform.tag == "Bullet")
        {
            hp--;
            Destroy(bullet.gameObject);
            
        }
    }
}
