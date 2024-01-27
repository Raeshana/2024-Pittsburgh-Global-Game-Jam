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

    [ContextMenu("Set max value of happiness bar")]
    public void SetMax(float maxVal)
    {
        slider.maxValue = maxVal;
    }

    [ContextMenu("Changes value of happiness bar")]
    public void UpdateBar(float currVal)
    {
        slider.value = currVal;
    }
}
