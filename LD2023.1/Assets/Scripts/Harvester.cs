using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvester : MonoBehaviour
{
    public float range;
    private Resource target;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Target", 1.5f);
        //HarvesterAI();
    }

    // Update is called once per frame
    private void Target()
    {
        float smallest = range;
        int smallestIndex = -1;
        GameObject[] resources = GameObject.FindGameObjectsWithTag("Resource");

        for (int i = 0; i < resources.Length; i++)
        {
            if (resources[i] == null)
            {
                continue;
            }
            float next = Vector3.Distance(gameObject.transform.position, resources[i].transform.position);
            if (next < smallest)
            {
                smallest = next;
                smallestIndex = i;
            }
        }
        if(smallestIndex == -1) //There was nothing closer than the range
        {
            return;
        }
        target = resources[smallestIndex].GetComponent<Resource>();
        StartCoroutine(Harvesting());

    }
    //private void HarvesterAI()
    //{
    //    if (target == null)
    //    {
    //        Target();
    //        return;
    //    }
    //    Vector2 targetPos = target.position;
    //    direction = targetPos - (Vector2)transform.position;
    //    rayInfo = Physics2D.Raycast(transform.position, direction, range);
    //    if (rayInfo)
    //    {
    //        if (rayInfo.collider.gameObject.tag == "Resource")
    //        {
    //            detected = true;
    //        }
    //        else
    //        {
    //            detected = false;
    //        }
    //    }
    //    if (detected)
    //    {
    //        Debug.Log("Harvesting");
    //        StartCoroutine(Harvesting());
    //    }
    //}

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);

    }
    private IEnumerator Harvesting()
    {
        while (target != null) {
            //rayInfo.collider.gameObject.GetComponent<Resource>().Harvest();
            target.Harvest();
            yield return new WaitForSeconds(1f);
        }
    }
}
