using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganicMatter : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, 3)];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int random = Random.Range(1, 4);
            GameManager.Instance.organicMatter += random;
            Destroy(gameObject);
        }
    }
}
