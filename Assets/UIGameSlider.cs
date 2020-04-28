using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIGameSlider : MonoBehaviour
{
    private Slider slider;

    protected float storedMaxValue;
    protected float storedCurrentValue;

    public abstract float GetMaxValue();
    public abstract float GetCurrentValue();

    void Start()
    {
        VirtualStart();
    }

    private void Update()
    {
        slider.value = GetCurrentValue();
        slider.maxValue = GetMaxValue();
    }

    protected virtual void VirtualStart()
    {
        slider = GetComponent<Slider>();
        Debug.Log(slider);
    }


}