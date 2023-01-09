    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class CanvasController : MonoBehaviour
{
    public Dropper dropper;
    public GameObject buildMenu;
    public GameObject upgradeMenu;
    public GameObject pauseMenu;
    public TextMeshProUGUI timer;
    private bool buildMenuActive = false;
    private bool upgradeMenuActive = false;
    private bool pauseMenuActive = false;

    public Image[] movementProgress;
    public Image[] pierceProgress;
    public Image[] harvestProgress;
    public Image[] healthProgress;

    public int movementUpgrade = 0;
    public int pierceUpgrade = 0;
    public int healthUpgrade = 0;
    public int harvestUpgrade = 0;

    //Costs of Buildings
    [SerializeField] int[] turretCost;
    [SerializeField] int[] harvesterCost;
    [SerializeField] int[] lureCost;
    [SerializeField] int[] bombCost;
    [SerializeField] int[] cannonCost;
   


    // Update is called once per frame
    void Update()
    {
        CanvasControl();
        timer.text = (300-(Time.time - GameManager.Instance.startTime)).ToString("f0") + " Seconds Left";
    }
    public void DropCannon()
    {
        if (GameManager.Instance.bone >= cannonCost[1] && GameManager.Instance.ichor >= cannonCost[0] && GameManager.Instance.ruby >= cannonCost[2])
        {
            dropper.DropCannon();
            GameManager.Instance.bone -= cannonCost[1];
            GameManager.Instance.ichor -= cannonCost[0];
            GameManager.Instance.ruby -= cannonCost[2];
        }
    }
    public void DropBomb()
    {
        if (GameManager.Instance.bone >= bombCost[1] && GameManager.Instance.ichor >= bombCost[0])
        {
            dropper.DropBomb();
            GameManager.Instance.bone -= bombCost[1];
            GameManager.Instance.ichor -= bombCost[0];
        }
    }
    public void DropTurret()
    {
        if (GameManager.Instance.bone >= turretCost[1] && GameManager.Instance.ichor >= turretCost[0])
        {
            dropper.DropTurret();
            GameManager.Instance.bone -= turretCost[1];
            GameManager.Instance.ichor -= turretCost[0];
        }
    }
    public void DropHarvester()
    {
        if (GameManager.Instance.bone >= harvesterCost[1] && GameManager.Instance.ichor >= harvesterCost[0])
        {
            dropper.DropHarvester();
            GameManager.Instance.bone -= harvesterCost[1];
            GameManager.Instance.ichor -= harvesterCost[0];
        }

    }
    public void DropLure()
    {
        if (GameManager.Instance.bone >= lureCost[1])
        {
            dropper.DropLure();
            GameManager.Instance.bone -= lureCost[1];
        }

    }
    public void UpgradeMovement()
    {
        if (movementUpgrade < 4){
            if (GameManager.Instance.organicMatter >= 5 && movementUpgrade == 0)
            {
                GameManager.Instance.organicMatter -= 5;
                movementUpgrade++;
                movementProgress[0].color = new Color32(0, 255, 0, 255);
            }
            else if (GameManager.Instance.organicMatter >= 10 && movementUpgrade == 1)
            {
                GameManager.Instance.organicMatter -= 10;
                movementUpgrade++;
                movementProgress[1].color = new Color32(0, 255, 0, 255);
            }
            else if (GameManager.Instance.organicMatter >= 15 && movementUpgrade == 2)
            {
                GameManager.Instance.organicMatter -= 15;
                movementUpgrade++;
                movementProgress[2].color = new Color32(0, 255, 0, 255);
            }
            else if (GameManager.Instance.organicMatter >= 20 && movementUpgrade == 3)
            {
                GameManager.Instance.organicMatter -= 20;
                movementUpgrade++;
                movementProgress[3].color = new Color32(0, 255, 0, 255);
            }
     
        }
        
    }
    public void UpgradePierce()
    {
        if (pierceUpgrade < 2)
        {
            if (GameManager.Instance.organicMatter >= 30 && pierceUpgrade == 0)
            {
                GameManager.Instance.organicMatter -= 30;
                pierceUpgrade++;
                pierceProgress[0].color = new Color32(0, 255, 0, 255);
            }
            else if (GameManager.Instance.organicMatter >= 50 && pierceUpgrade == 1)
            {
                GameManager.Instance.organicMatter -= 50;
                pierceUpgrade++;
                pierceProgress[1].color = new Color32(0, 255, 0, 255);
            }
        }
    }
    public void UpgradeHarvester()
    {
        if (harvestUpgrade < 4)
        {
            if (GameManager.Instance.organicMatter >= 5 && harvestUpgrade == 0)
            {
                GameManager.Instance.organicMatter -= 5;
                harvestUpgrade++;
                harvestProgress[0].color = new Color32(0, 255, 0, 255);
            }
            else if (GameManager.Instance.organicMatter >= 10 && harvestUpgrade == 1)
            {
                GameManager.Instance.organicMatter -= 10;
                harvestUpgrade++;
                harvestProgress[1].color = new Color32(0, 255, 0, 255);
            }
            else if (GameManager.Instance.organicMatter >= 15 && harvestUpgrade == 2)
            {
                GameManager.Instance.organicMatter -= 15;
                harvestUpgrade++;
                harvestProgress[2].color = new Color32(0, 255, 0, 255);
            }
            else if (GameManager.Instance.organicMatter >= 20 && harvestUpgrade == 3)
            {
                GameManager.Instance.organicMatter -= 20;
                harvestUpgrade++;
                harvestProgress[3].color = new Color32(0, 255, 0, 255);
            }

        }
    }
    public void UpgradeHealth()
    {
        if (healthUpgrade < 4)
        {
            if (GameManager.Instance.organicMatter >= 5 && healthUpgrade == 0)
            {
                GameManager.Instance.organicMatter -= 5;
                healthUpgrade++;
                healthProgress[0].color = new Color32(0, 255, 0, 255);
            }
            else if (GameManager.Instance.organicMatter >= 10 && healthUpgrade == 1)
            {
                GameManager.Instance.organicMatter -= 10;
                healthUpgrade++;
                healthProgress[1].color = new Color32(0, 255, 0, 255);
            }
            else if (GameManager.Instance.organicMatter >= 15 && healthUpgrade == 2)
            {
                GameManager.Instance.organicMatter -= 15;
                healthUpgrade++;
                healthProgress[2].color = new Color32(0, 255, 0, 255);
            }
            else if (GameManager.Instance.organicMatter >= 20 && healthUpgrade == 3)
            {
                GameManager.Instance.organicMatter -= 20;
                healthUpgrade++;
                healthProgress[3].color = new Color32(0, 255, 0, 255);
            }

        }
    }
    private void CanvasControl()
    {
        if (Input.GetKeyDown(KeyCode.E) && pauseMenuActive == false)
        {
            if(buildMenuActive == false)
            {
                buildMenu.SetActive(true);
                buildMenuActive = true;

                upgradeMenu.SetActive(false);
                upgradeMenuActive = false;                
            }
            else
            {
                buildMenu.SetActive(false);
                buildMenuActive = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) && pauseMenuActive == false)
        {
            if (upgradeMenuActive == false)
            {
                upgradeMenu.SetActive(true);
                upgradeMenuActive = true;

                buildMenu.SetActive(false);
                buildMenuActive = false;              
            }
            else
            {
                upgradeMenu.SetActive(false);
                upgradeMenuActive = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuActive == false)
            {

                pauseMenu.SetActive(true);
                pauseMenuActive = true;

                buildMenu.SetActive(false);
                buildMenuActive = false;

                upgradeMenu.SetActive(false);
                upgradeMenuActive = false;
                Pause();
            }
            else
            {
                pauseMenu.SetActive(false);
                pauseMenuActive = false;
                Resume();
            }
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }
    
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }
}
