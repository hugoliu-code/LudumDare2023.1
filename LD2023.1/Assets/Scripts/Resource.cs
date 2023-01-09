using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{

    public string resourceName;
    [SerializeField] Sprite[] sprites; //index 0 is ichor, 1 is bone, 2 is ruby
    bool ichorNear = false;
    bool boneNear = false;
    bool rubyNear = false;
    private int resource = 100;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("RandomGeneration",0.1f); 
    }
    
    void RandomGeneration()
    {
        //will make this resource a random one based on the resources around it
        ArrayList resourcePool = new ArrayList() { 0,0,0,0,0,0 ,1,1,1,1,1, 2 };
        string[] names = new string[] { "ichor", "bone", "ruby" };
        if (!ichorNear)
        {
            resourcePool.Add(0);
            resourcePool.Add(0);
            resourcePool.Add(0);
            resourcePool.Add(0);
        }
        if (!boneNear)
        {
            resourcePool.Add(1);
            resourcePool.Add(1);
            resourcePool.Add(1);
            resourcePool.Add(1);
        }
        if (!rubyNear)
        {
            resourcePool.Add(2);
            resourcePool.Add(2);
        }
        int resourceType = (int)resourcePool[Random.Range(0,resourcePool.Count)];
        GetComponent<SpriteRenderer>().sprite = sprites[resourceType];
        resourceName = names[resourceType];
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks for nearby resources
        if (collision.CompareTag("Resource")){
            string name = collision.gameObject.GetComponent<Resource>().resourceName;
            if (name.Equals("ichor"))
            {
                ichorNear = true;
            }
            else if (name.Equals("bone"))
            {
                boneNear = true;
            }
            else if (name.Equals("ruby"))
            {
                rubyNear = true;
            }
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
        if (resource <= 0)
        {
            Destroy(gameObject);
        }
    }
}
