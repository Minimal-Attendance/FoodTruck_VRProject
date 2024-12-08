using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customerOrder : MonoBehaviour
{
    //If the customer wants these ingredients
    public bool wantsTomato = false;
    public bool wantsLettuce = false;
    public bool wantsCheese = false;

    public int ingredientsNeeded;

    //public bool[] burgerIngredients = new bool[3];

    [SerializeField] private GameObject tomatoOrderText;
    [SerializeField] private GameObject lettuceOrderText;
    [SerializeField] private GameObject cheeseOrderText;

    [SerializeField] private GameObject orderBoardText;
    [SerializeField] private GameObject nextOrderText;

    private customerTimer customerTimer;

    void Start()
    {
        customerTimer = GetComponent<customerTimer>();

        tomatoOrderText.SetActive(false);
        lettuceOrderText.SetActive(false);
        cheeseOrderText.SetActive(false);

        orderBoardText.SetActive(true);
        nextOrderText.SetActive(false);

        pickIngredients();
        //burgerIngredients[1] = wantsTomato;
        //burgerIngredients[2] = wantsLettuce;
        //burgerIngredients[3] = wantsCheese;
    }
    public void pickIngredients()
    {
        int ingredientAmount = Random.Range(1, 4);

        //set to 3 for patty and buns
        ingredientsNeeded = 3;

        //for (int i = 1; i < ingredientAmount; i++)
        //{
        //burgerIngredients[Random.Range(1, 3)] = true;
        //}
        if (ingredientAmount <= 1)
        {
            wantsTomato = true;
            ingredientsNeeded += 1;
        }
        else if (ingredientAmount == 2)
        {
            wantsTomato = true;
            wantsLettuce = true;
            ingredientsNeeded += 2;
        }
        else if (ingredientAmount >= 3)
        {
            wantsTomato = true;
            wantsLettuce = true;
            wantsCheese = true;
            ingredientsNeeded += 3;
        }

        if (wantsTomato)
        {
            tomatoOrderText.SetActive(true);
        }
        if (wantsLettuce)
        {
            lettuceOrderText.SetActive(true);
        }
        if (wantsCheese)
        {
            cheeseOrderText.SetActive(true);
        }
    }

    public void turnOffOrderBoard()
    {
        orderBoardText.SetActive(false);
        nextOrderText.SetActive(true);
    }

    public void resetOrder()
    {
        wantsTomato = false;
        wantsLettuce = false;
        wantsCheese = false;

        nextOrderText.SetActive(false);
        orderBoardText.SetActive(true);
        tomatoOrderText.SetActive(false);
        lettuceOrderText.SetActive(false);
        cheeseOrderText.SetActive(false);

        ingredientsNeeded = 0;

        pickIngredients();
    }
}
