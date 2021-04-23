using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int hp;
    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.transform.tag == "Enemy")
        {
            Destroy(enemy.gameObject);
            hp--;
        }
    }

    private void Update()
    {
        if (hp == 0)
        {
            Time.timeScale = 0;
        }
    }
}
