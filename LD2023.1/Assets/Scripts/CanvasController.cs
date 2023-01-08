    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CanvasController : MonoBehaviour
{
    public Dropper dropper;
    public GameObject buildMenu;
    public GameObject upgradeMenu;
    public GameObject pauseMenu;

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
                movementProgress[0].color = new Color32(0, 255, 0, 255);
            }
            else if (GameManager.Instance.organicMatter >= 80 && movementUpgrade == 1)
            {
                GameManager.Instance.organicMatter -= 80;
                movementUpgrade++;
                movementProgress[1].color = new Color32(0, 255, 0, 255);
            }
            else if (GameManager.Instance.organicMatter >= 200 && movementUpgrade == 2)
            {
                GameManager.Instance.organicMatter -= 200;
                movementUpgrade++;
                movementProgress[2].color = new Color32(0, 255, 0, 255);
            }
            else if (GameManager.Instance.organicMatter >= 300 && movementUpgrade == 3)
            {
                GameManager.Instance.organicMatter -= 300;
                movementUpgrade++;
                movementProgress[3].color = new Color32(0, 255, 0, 255);
            }
     
        }
        
    }
    public void UpgradePierce()
    {
        if (pierceUpgrade < 2)
        {
            if (GameManager.Instance.organicMatter >= 100 && pierceUpgrade == 0)
            {
                GameManager.Instance.organicMatter -= 100;
                pierceUpgrade++;
                pierceProgress[0].color = new Color32(0, 255, 0, 255);
            }
            else if (GameManager.Instance.organicMatter >= 200 && pierceUpgrade == 1)
            {
                GameManager.Instance.organicMatter -= 200;
                pierceUpgrade++;
                pierceProgress[1].color = new Color32(0, 255, 0, 255);
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
                harvestProgress[0].color = new Color32(0, 255, 0, 255);
            }
            else if (GameManager.Instance.organicMatter >= 80 && harvestUpgrade == 1)
            {
                GameManager.Instance.organicMatter -= 80;
                harvestUpgrade++;
                harvestProgress[1].color = new Color32(0, 255, 0, 255);
            }
            else if (GameManager.Instance.organicMatter >= 210 && harvestUpgrade == 2)
            {
                GameManager.Instance.organicMatter -= 210;
                harvestUpgrade++;
                harvestProgress[2].color = new Color32(0, 255, 0, 255);
            }
            else if (GameManager.Instance.organicMatter >= 320 && harvestUpgrade == 3)
            {
                GameManager.Instance.organicMatter -= 320;
                harvestUpgrade++;
                harvestProgress[3].color = new Color32(0, 255, 0, 255);
            }

        }
    }
    public void UpgradeHealth()
    {
        if (healthUpgrade < 4)
        {
            if (GameManager.Instance.organicMatter >= 50 && healthUpgrade == 0)
            {
                GameManager.Instance.organicMatter -= 50;
                healthUpgrade++;
                healthProgress[0].color = new Color32(0, 255, 0, 255);
            }
            else if (GameManager.Instance.organicMatter >= 100 && healthUpgrade == 1)
            {
                GameManager.Instance.organicMatter -= 100;
                healthUpgrade++;
                healthProgress[1].color = new Color32(0, 255, 0, 255);
            }
            else if (GameManager.Instance.organicMatter >= 220 && healthUpgrade == 2)
            {
                GameManager.Instance.organicMatter -= 220;
                healthUpgrade++;
                healthProgress[2].color = new Color32(0, 255, 0, 255);
            }
            else if (GameManager.Instance.organicMatter >= 300 && healthUpgrade == 3)
            {
                GameManager.Instance.organicMatter -= 300;
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
