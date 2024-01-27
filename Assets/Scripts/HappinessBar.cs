using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappinessBar : MonoBehaviour
{
    private Slider slider;

    public void Start()
    {
        slider = GetComponent<Slider>();
    }

    [ContextMenu("Changes value of happiness bar")]
    public void UpdateBar(float currVal, float maxVal)
    {
        slider.value = currVal;
    }
}
