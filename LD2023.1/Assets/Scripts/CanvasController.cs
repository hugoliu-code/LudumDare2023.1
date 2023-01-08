using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasController : MonoBehaviour
{
    public Dropper dropper;
    public GameObject imageGroup;
    private bool imageGroupActive = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CanvasControl();
    }
    public void DropTurret()
    {
        if (GameManager.Instance.bone >= 5 && GameManager.Instance.ichor >= 10)
        {
            dropper.DropTurret();
            GameManager.Instance.bone -= 5;
            GameManager.Instance.ichor -= 10;
        }
    }
    public void DropHarvester()
    {
        if (GameManager.Instance.bone >= 5 && GameManager.Instance.ichor >= 5)
        {
            dropper.DropHarvester();
            GameManager.Instance.bone -= 5;
            GameManager.Instance.ichor -= 5;
        }

    }

    private void CanvasControl()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("ENTER");
            if(imageGroupActive == false)
            {
                imageGroup.SetActive(true);
                imageGroupActive = true;
            }
            else
            {
                imageGroup.SetActive(false);
                imageGroupActive = false;
            }
        }
    }
}
