using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dayTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyToRemoveText;
    [SerializeField] private Image radialTimerImage;
    [SerializeField] private float timeAmount;
    [SerializeField] private int moneyToRemove = 10;
    [SerializeField] private int moneyRemoveDailyIncrease = 10;

    private moneyManager moneyManager;

    private float timeAmountStored;

    void Start()
    {
        moneyManager = GetComponent<moneyManager>();
        timeAmountStored = timeAmount;
        moneyToRemoveText.text = "-$" + moneyToRemove.ToString();
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
            moneyManager.removeMoney(moneyToRemove);
            moneyToRemove += moneyRemoveDailyIncrease;
            moneyToRemoveText.text = "-$" + moneyToRemove.ToString();
        }
    }
}
