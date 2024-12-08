using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class moneyManager : MonoBehaviour
{
    public float moneyAmount = 0;
    [SerializeField] private TextMeshProUGUI moneyText;

    private void Start()
    {
        moneyText.text = "$" + moneyAmount.ToString();
    }

    public void addMoney(int moneyToAdd)
    {
        moneyAmount += moneyToAdd;
        moneyAmountCheck();
    }

    public void removeMoney(int moneyToRemove)
    {
        moneyAmount -= moneyToRemove;
        moneyAmountCheck();
    }

    public void moneyAmountCheck()
    {
        int moneyAmountRounded = Mathf.RoundToInt(moneyAmount);
        moneyText.text = "$" + moneyAmountRounded.ToString();

        if (moneyAmount < 0)
        {
            Application.Quit();
        }
    }
}
