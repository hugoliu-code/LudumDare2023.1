    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasController : MonoBehaviour
{
    public Dropper dropper;
    public GameObject buildMenu;
    public GameObject upgradeMenu;
    private bool buildMenuActive = false;
    private bool upgradeMenuActive = false;
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
    public void DropLure()
    {
        if (GameManager.Instance.bone >= 20)
        {
            dropper.DropLure();
            GameManager.Instance.bone -= 20;
        }

    }


    private void CanvasControl()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("ENTER");
            if(buildMenuActive == false)
            {
                upgradeMenu.SetActive(false);
                upgradeMenuActive = false;

                buildMenu.SetActive(true);
                buildMenuActive = true;
            }
            else
            {
                upgradeMenu.SetActive(false);
                upgradeMenuActive = false;

                buildMenu.SetActive(false);
                buildMenuActive = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("ENTER");
            if (upgradeMenuActive == false)
            {
                buildMenu.SetActive(false);
                buildMenuActive = false;

                upgradeMenu.SetActive(true);
                upgradeMenuActive = true;
            }
            else
            {
                buildMenu.SetActive(false);
                buildMenuActive = false;

                upgradeMenu.SetActive(false);
                upgradeMenuActive = false;
            }
        }
    }
}
