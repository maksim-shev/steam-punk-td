using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject bullet;
    private IEnumerator coroutine;
    private bool is_fiering = false;

    void OnTriggerStay2D(Collider2D enemy)
    {
        if (enemy.transform.tag == "Enemy" && !is_fiering)
        {
            coroutine = BulletGenerator(enemy.gameObject);
            StartCoroutine(coroutine);
        }
    }

    IEnumerator BulletGenerator(GameObject target_position)
    {
        Arrow new_bullet = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Arrow>();
        new_bullet.SetTarget(target_position);
        is_fiering = true;

        yield return new WaitForSeconds(.3f);
        is_fiering = false;
    }
}
