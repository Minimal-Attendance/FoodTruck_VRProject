using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;

public class orderPlacePoint : MonoBehaviour
{
    [SerializeField] private customerOrder customerOrder;
    [SerializeField] private customerTimer customerTimer;
    private AudioSource audioSource;
    public int ingredientsPlaced;

    private GameObject topBun;
    private GameObject bottomBun;
    private GameObject cookedPatty;
    private GameObject tomato;
    private GameObject cheeseSlice;
    private GameObject lettuce;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("topBun"))
        {
            ingredientsPlaced += 1;
            topBun = other.gameObject;
        }
        if (other.CompareTag("bottomBun"))
        {
            ingredientsPlaced += 1;
            bottomBun = other.gameObject;
        }
        if (other.CompareTag("cookedPatty"))
        {
            ingredientsPlaced += 1;
            cookedPatty = other.gameObject;
        }

        if (customerOrder.wantsCheese && other.CompareTag("cheeseSlice"))
        {
            ingredientsPlaced += 1;
            cheeseSlice = other.gameObject;
        }
        else if (!customerOrder.wantsCheese && other.CompareTag("cheeseSlice"))
        {
            ingredientsPlaced -= 1;
            cheeseSlice = null;
        }

        if (customerOrder.wantsLettuce && other.CompareTag("lettuce"))
        {
            ingredientsPlaced += 1;
            lettuce = other.gameObject;
        }
        else if (!customerOrder.wantsLettuce && other.CompareTag("lettuce"))
        {
            ingredientsPlaced -= 1;
            lettuce = null;
        }

        if (customerOrder.wantsTomato && other.CompareTag("tomato"))
        {
            ingredientsPlaced += 1;
            tomato = other.gameObject;
        }
        else if (!customerOrder.wantsTomato && other.CompareTag("tomato"))
        {
            ingredientsPlaced -= 1;
            tomato = null;
        }

        checkIngredientsPlaced();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("topBun"))
        {
            ingredientsPlaced -= 1;
            topBun = null;
        }
        if (other.CompareTag("bottomBun"))
        {
            ingredientsPlaced -= 1;
            bottomBun = null;
        }
        if (other.CompareTag("cookedPatty"))
        {
            ingredientsPlaced -= 1;
            cookedPatty = null;
        }

        if (customerOrder.wantsCheese && other.CompareTag("cheeseSlice"))
        {
            ingredientsPlaced -= 1;
            cheeseSlice = null;
        }
        else if (!customerOrder.wantsCheese && other.CompareTag("cheeseSlice"))
        {
            ingredientsPlaced += 1;
            cheeseSlice = null;
        }

        if (customerOrder.wantsLettuce && other.CompareTag("lettuce"))
        {
            ingredientsPlaced -= 1;
            lettuce = null;
        }
        else if (!customerOrder.wantsLettuce && other.CompareTag("lettuce"))
        {
            ingredientsPlaced += 1;
            lettuce = null;
        }

        if (customerOrder.wantsTomato && other.CompareTag("tomato"))
        {
            ingredientsPlaced -= 1;
            tomato = null;
        }
        else if (!customerOrder.wantsTomato && other.CompareTag("tomato"))
        {
            ingredientsPlaced += 1;
            tomato = null;
        }
    }

    public void checkIngredientsPlaced()
    {
        if (ingredientsPlaced >= customerOrder.ingredientsNeeded)
        {
            customerTimer.customerOrderTaken();
            ingredientsPlaced = 0;

            Destroy(topBun);
            Destroy(bottomBun);
            Destroy(cookedPatty);
            Destroy(tomato);
            Destroy(lettuce);
            Destroy(cheeseSlice);

            audioSource.Play();
        }
    }
}
