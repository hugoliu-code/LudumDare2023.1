using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int ruby;
    public int bone;
    public int ichor;
    public int organicMatter;
    public int playerHealth;
    public static GameManager Instance = null;

    public float startTime;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        
    }
    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        if(playerHealth <= 0)
        {
            //Load the death menu
        }
        if(Time.time-startTime > 300)
        {
            //load the win screen
        }
    }
}
