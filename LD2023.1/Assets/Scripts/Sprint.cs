using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sprint : MonoBehaviour
{
    [SerializeField] Slider stamina;

    // Start is called before the first frame update
    public void Sprinting(float sprintEnergy, float maxSprint)
    {
        stamina.gameObject.SetActive(sprintEnergy < maxSprint);

        stamina.value = sprintEnergy;
        stamina.maxValue = maxSprint;
    }
}
