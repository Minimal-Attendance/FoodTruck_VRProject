using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;

public class orderPlacePoint : MonoBehaviour
{
    [SerializeField] private customerOrder customerOrder;
    [SerializeField] private customerTimer customerTimer;
    public int ingredientsPlaced;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("topBun"))
        {
            ingredientsPlaced += 1;
        }
        if (other.CompareTag("bottomBun"))
        {
            ingredientsPlaced += 1;
        }
        if (other.CompareTag("cookedPatty"))
        {
            ingredientsPlaced += 1;
        }

        if (customerOrder.wantsCheese && other.CompareTag("cheeseSlice"))
        {
            ingredientsPlaced += 1;
        }
        if (customerOrder.wantsLettuce && other.CompareTag("lettuce"))
        {
            ingredientsPlaced += 1;
        }
        if (customerOrder.wantsTomato && other.CompareTag("tomato"))
        {
            ingredientsPlaced += 1;
        }
        checkIngredientsPlaced();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("topBun"))
        {
            ingredientsPlaced -= 1;
        }
        if (other.CompareTag("bottomBun"))
        {
            ingredientsPlaced -= 1;
        }
        if (other.CompareTag("cookedPatty"))
        {
            ingredientsPlaced -= 1;
        }

        if (customerOrder.wantsCheese && other.CompareTag("cheeseSlice"))
        {
            ingredientsPlaced -= 1;
        }
        if (customerOrder.wantsLettuce && other.CompareTag("lettuce"))
        {
            ingredientsPlaced -= 1;
        }
        if (customerOrder.wantsTomato && other.CompareTag("tomato"))
        {
            ingredientsPlaced -= 1;
        }
    }

    public void checkIngredientsPlaced()
    {
        if (ingredientsPlaced == customerOrder.ingredientsNeeded)
        {
            customerTimer.customerOrderTaken();
        }
    }
}
