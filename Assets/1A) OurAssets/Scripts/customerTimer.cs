using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class customerTimer : MonoBehaviour
{
    [SerializeField] private Image radialTimerImage;
    [SerializeField] private float timeAmount;

    [SerializeField] private float cooldownTime = 10;

    public bool customerTimerActive;

    private float timeAmountStored;

    private customerOrder customerOrder;

    void Start()
    {
        customerOrder = GetComponent<customerOrder>();
        timeAmountStored = timeAmount;
        customerTimerActive = true;
        customerOrder.pickIngredients();
    }

    void Update()
    {
        if (timeAmount > 0 && customerTimerActive)
        {
            timeAmount -= Time.deltaTime;
            radialTimerImage.fillAmount = timeAmount / timeAmountStored;
        }
        else if (timeAmount <= 0 && customerTimerActive)
        {
            customerTimerActive = false;
            StartCoroutine(timerCooldown());
            customerOrder.turnOffOrderBoard();
            Debug.Log("No Time Left");
        }
    }

    public IEnumerator timerCooldown()
    {
        Debug.Log("timer cooldown started");
        yield return new WaitForSeconds(cooldownTime);
        resetCustomerTimer();
        Debug.Log("timer cooldown over");
    }

    public void resetCustomerTimer()
    {
        Debug.Log("timer reset");
        customerTimerActive = true;
        customerOrder.resetOrder();
        timeAmount = timeAmountStored;
        radialTimerImage.fillAmount = timeAmount / timeAmountStored;
    }
}
