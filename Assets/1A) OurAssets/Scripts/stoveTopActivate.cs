using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;

public class stoveTopActivate : MonoBehaviour
{
    [SerializeField] private PlacePoint stovePlacePoint;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void panOnStove()
    {
        if (stovePlacePoint.placedObject.CompareTag("fryingPan"))
        {
            stovePlacePoint.placedObject.GetComponent<fryingPanActivate>().cookMeat();
        }
    }

    private void takePanOffStove()
    {
        if (stovePlacePoint.placedObject.CompareTag("fryingPan"))
        {
            stovePlacePoint.placedObject.GetComponent<fryingPanActivate>().stopCookingMeat();
        }
    }
}
