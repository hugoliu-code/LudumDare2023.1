using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{

    [SerializeField] string resourceName;
    private int resource = 50;
    // Start is called before the first frame update
    void Start()
    {

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

        if(resourceName == "ruby")
        {
            GameManager.Instance.ruby++;

        }
        if (resourceName == "bone")
        {
            GameManager.Instance.bone++;

        }
        if(resourceName == "ichor")
        {
            GameManager.Instance.ichor++;

        }
    }
}
