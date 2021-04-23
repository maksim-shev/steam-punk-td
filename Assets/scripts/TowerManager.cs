using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TowerManager : MonoBehaviour
{
    public LayerMask unwalkableMask;
    public TowerList towerList;

    private LayerMask towerMask;

    private void Start()
    {
        towerMask = LayerMask.GetMask(LayerMask.LayerToName(towerList.towerPrefabs[0].layer));
    }
    void Update()
    {
        {
            if (Input.GetButtonDown("Fire1") && !IsMouseOverUI())
            {
                GameObject tower = towerList.towerPrefabs[0];
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Vector3 origin = ray.origin;
                origin.z = 0;
                float nodeRadius = tower.GetComponent<CircleCollider2D>().radius;
                Vector3 rirht_point = origin;
                Vector3 left_point = origin;
                Vector3 top_point = origin;
                Vector3 bottom_point = origin;
                rirht_point.x -= nodeRadius;
                left_point.x += nodeRadius;
                top_point.y -= nodeRadius;
                bottom_point.y += nodeRadius;
                Collider2D q = Physics2D.OverlapCircle(origin, nodeRadius, towerMask);
                bool can_create = Physics2D.OverlapCircle(rirht_point, 0.001f, unwalkableMask)
                    && Physics2D.OverlapCircle(left_point, 0.001f, unwalkableMask)
                    && Physics2D.OverlapCircle(top_point, 0.001f, unwalkableMask)
                    && Physics2D.OverlapCircle(bottom_point, 0.001f, unwalkableMask)
                    && !q;
                if (can_create)
                {
                    Instantiate(tower, origin, transform.rotation);
                }
            }
        }
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
