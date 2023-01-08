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

    public int movementUpgrade = 0;
    public int pierceUpgrade = 0;
    public int healthUpgrade = 0;
    public int harvestUpgrade = 0;
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
    public void UpgradeMovement()
    {
        if (movementUpgrade < 4){
            if (GameManager.Instance.organicMatter >= 20 && movementUpgrade == 0)
            {
                GameManager.Instance.organicMatter -= 20;
                movementUpgrade++;
            }
            else if (GameManager.Instance.organicMatter >= 80 && movementUpgrade == 1)
            {
                GameManager.Instance.organicMatter -= 80;
                movementUpgrade++;
            }
            else if (GameManager.Instance.organicMatter >= 200 && movementUpgrade == 2)
            {
                GameManager.Instance.organicMatter -= 200;
                movementUpgrade++;
            }
            else if (GameManager.Instance.organicMatter >= 300 && movementUpgrade == 3)
            {
                GameManager.Instance.organicMatter -= 300;
                movementUpgrade++;
            }
     
        }
        
    }
    public void UpgradePierce()
    {
        if (pierceUpgrade < 2)
        {
            if (GameManager.Instance.organicMatter >= 20 && pierceUpgrade == 0)
            {
                GameManager.Instance.organicMatter -= 100;
                pierceUpgrade++;
            }
            else if (GameManager.Instance.organicMatter >= 80 && pierceUpgrade == 1)
            {
                GameManager.Instance.organicMatter -= 200;
                pierceUpgrade++;
            }
        }
    }
    public void UpgradeHarvester()
    {
        if (harvestUpgrade < 4)
        {
            if (GameManager.Instance.organicMatter >= 30 && harvestUpgrade == 0)
            {
                GameManager.Instance.organicMatter -= 30;
                harvestUpgrade++;
            }
            else if (GameManager.Instance.organicMatter >= 80 && harvestUpgrade == 1)
            {
                GameManager.Instance.organicMatter -= 80;
                harvestUpgrade++;
            }
            else if (GameManager.Instance.organicMatter >= 210 && harvestUpgrade == 2)
            {
                GameManager.Instance.organicMatter -= 210;
                harvestUpgrade++;
            }
            else if (GameManager.Instance.organicMatter >= 320 && harvestUpgrade == 3)
            {
                GameManager.Instance.organicMatter -= 320;
                harvestUpgrade++;
            }

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
