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
}
