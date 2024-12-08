using Autohand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fryingPanActivate : MonoBehaviour
{
    [SerializeField] private PlacePoint fryingPanPlacePoint;
    [SerializeField] private GameObject cookedMeatPrefab;
    [SerializeField] private ParticleSystem panSmoke;
    [SerializeField] private float cookTime = 15;
    private float cookTimeStored;
    private bool meatCooking = false;

    private void Start()
    {
        cookTimeStored = cookTime;
    }

    void Update()
    {
        if (meatCooking && fryingPanPlacePoint.placedObject)
        {
            if (cookTime > 0)
            {
                cookTime -= Time.deltaTime;
            }
            else
            {
                stopCookingMeat();
                Instantiate(cookedMeatPrefab, fryingPanPlacePoint.placedObject.transform.position, fryingPanPlacePoint.placedObject.transform.rotation);
                Destroy(fryingPanPlacePoint.placedObject.gameObject);
            }
        }
    }

    public void cookMeat()
    {
        meatCooking = true;
        panSmoke = GetComponentInChildren<ParticleSystem>();
        panSmoke.Play();
    }

    public void stopCookingMeat()
    {
        meatCooking = false;
        panSmoke.Stop();
        cookTime = cookTimeStored;
    }
}
