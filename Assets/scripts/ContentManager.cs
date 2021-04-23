using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentManager : MonoBehaviour
{
    public GameObject contentList;
    public GameObject contentObjectPrefab;

    private void Start()
    {
        List<GameObject> gameObjects = contentList.GetComponent<TowerList>().towerPrefabs;
        foreach (GameObject gameObject in gameObjects)
        {
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            GameObject contentObject = Instantiate(contentObjectPrefab, transform.position, Quaternion.identity);
            contentObject.transform.SetParent(this.gameObject.transform);
            Image image = contentObject.GetComponent<Image>();
            image.sprite = spriteRenderer.sprite;
            image.color = spriteRenderer.color;
            contentObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
