using System.Collections;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public GameObject Mob;
    public float Timer;
    void Start()
    {
        StartCoroutine(Spawn());
    }
    private void Repeat()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Timer);
        Instantiate(Mob, transform.position, Quaternion.identity);
        Repeat();
    }
}
