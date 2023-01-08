using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasController : MonoBehaviour
{
    public Dropper dropper;
    public GameObject imageGroup;
    private bool imageGroupActive = false;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CanvasControl();
    }
    public void DropTurret()
    {
        if (gameManager.bone >= 5 && gameManager.ichor >= 10)
        {
            dropper.DropTurret();
            gameManager.bone -= 5;
            gameManager.ichor -= 10;
        }
    }
    public void DropHarvester()
    {
        if (gameManager.bone >= 5 && gameManager.ichor >= 5)
        {
            dropper.DropHarvester();
            gameManager.bone -= 5;
            gameManager.ichor -= 5;
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
