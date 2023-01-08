using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvester : MonoBehaviour
{
    public float range;
    private Resource target;
    private float harvestingTime;
    CanvasController canvasCon;
    // Start is called before the first frame update
    void Start()
    {
        canvasCon = FindObjectOfType<CanvasController>();
        Invoke("Target", 1f);
    }
    private void Update()
    {
        if(canvasCon.harvestUpgrade == 0)
        {
            harvestingTime = 1.5f;
        }
        if (canvasCon.harvestUpgrade == 1)
        {
            harvestingTime = 1.2f;
        }
        if (canvasCon.harvestUpgrade == 2)
        {
            harvestingTime = 0.9f;
        }
        if (canvasCon.harvestUpgrade == 3)
        {
            harvestingTime = 0.6f;
        }
        if (canvasCon.harvestUpgrade == 4)
        {
            harvestingTime = 0.3f;
        }
    }
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
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);

    }
    private IEnumerator Harvesting()
    {
        while (target != null) {
            target.Harvest();
            yield return new WaitForSeconds(harvestingTime);
        }
    }
}
