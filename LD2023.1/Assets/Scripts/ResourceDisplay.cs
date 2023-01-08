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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        health.text = "" + GameManager.Instance.playerHealth;
        ruby.text = "" + GameManager.Instance.ruby;
        ichor.text = "" + GameManager.Instance.ichor;
        bone.text = "" + GameManager.Instance.bone;
    }
}
