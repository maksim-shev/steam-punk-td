using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private GameObject target;
    public float speed;
    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            transform.position = Vector2.Lerp(transform.position, target.transform.position, speed);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
