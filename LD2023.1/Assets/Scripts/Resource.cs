using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] string name;
    private int resource = 50;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(resource <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Harvest()
    {
        resource--;

        if(name == "ruby")
        {
            gameManager.ruby++;
            Debug.Log("RUBY");
        }
        if (name == "bone")
        {
            gameManager.bone++;
            Debug.Log("BONE");
        }
        if(name == "ichor")
        {
            gameManager.ichor++;
            Debug.Log("ICHOR");
        }
    }
}
