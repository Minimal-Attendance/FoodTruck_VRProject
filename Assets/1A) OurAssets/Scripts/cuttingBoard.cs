using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;

public class cuttingBoard : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;

    public void instantiateWhenCut()
    {
        Instantiate(prefabToSpawn, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
