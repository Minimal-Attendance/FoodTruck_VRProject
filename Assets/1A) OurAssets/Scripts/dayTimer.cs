using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dayTimer : MonoBehaviour
{
    [SerializeField] private Image radialTimerImage;
    [SerializeField] private float timeAmount;

    private float timeAmountStored;

    void Start()
    {
        timeAmountStored = timeAmount;
    }

    void Update()
    {
        if (timeAmount > 0)
        {
            timeAmount -= Time.deltaTime;
            radialTimerImage.fillAmount = timeAmount / timeAmountStored;
        }
        else
        {
            timeAmount = timeAmountStored;
        }
    }
}
