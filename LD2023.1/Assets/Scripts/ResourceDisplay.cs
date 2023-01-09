using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceDisplay : MonoBehaviour
{
    public TextMeshProUGUI ruby;
    public TextMeshProUGUI ichor;
    public TextMeshProUGUI bone;
    public TextMeshProUGUI health;
    public TextMeshProUGUI organicMatter;

    public TextMeshProUGUI movementPrice;
    public TextMeshProUGUI piercePrice;
    public TextMeshProUGUI healthPrice;
    public TextMeshProUGUI harvestPrice;
    CanvasController canvasController;
    // Start is called before the first frame update
    void Start()
    {
        canvasController = FindObjectOfType<CanvasController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Prices

        //Movement
        if(canvasController.movementUpgrade == 0)
        {
            movementPrice.text = "" + 5;
        }
        if(canvasController.movementUpgrade == 1)
        {
            movementPrice.text = "" + 10;
        }
        if (canvasController.movementUpgrade == 2)
        {
            movementPrice.text = "" + 15;
        }
        if (canvasController.movementUpgrade == 3)
        {
            movementPrice.text = "" + 20;
        }
        if (canvasController.movementUpgrade == 4)
        {
            movementPrice.text = "Max";
        }
        //Pierce
        if(canvasController.pierceUpgrade == 0)
        {
            piercePrice.text = "" + 30;
        }
        if (canvasController.pierceUpgrade == 1)
        {
            piercePrice.text = "" + 50;
        }
        if (canvasController.pierceUpgrade == 2)
        {
            piercePrice.text = "Max";
        }
        //Health
        if(canvasController.healthUpgrade == 0)
        {
            healthPrice.text = "" + 5;
        }
        if (canvasController.healthUpgrade == 1)
        {
            healthPrice.text = "" + 10;
        }
        if (canvasController.healthUpgrade == 2)
        {
            healthPrice.text = "" + 15;
        }
        if (canvasController.healthUpgrade == 3)
        {
            healthPrice.text = "" + 20;
        }
        if (canvasController.healthUpgrade == 4)
        {
            healthPrice.text = "Max";
        }
        //Harvest
        if(canvasController.harvestUpgrade == 0)
        {
            harvestPrice.text = "" + 5;
        }
        if (canvasController.harvestUpgrade == 1)
        {
            harvestPrice.text = "" + 10;
        }
        if (canvasController.harvestUpgrade == 2)
        {
            harvestPrice.text = "" + 15;
        }
        if (canvasController.harvestUpgrade == 3)
        {
            harvestPrice.text = "" + 20;
        }
        if (canvasController.harvestUpgrade == 4)
        {
            harvestPrice.text = "Max";
        }

        //Main Gaim
        organicMatter.text = "" + GameManager.Instance.organicMatter;
        health.text = "" + GameManager.Instance.playerHealth;
        ruby.text = "" + GameManager.Instance.ruby;
        ichor.text = "" + GameManager.Instance.ichor;
        bone.text = "" + GameManager.Instance.bone;
    }
}
