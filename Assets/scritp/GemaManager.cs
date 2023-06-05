using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GemaManager : MonoBehaviour
{
    
    private void Update() 
    
    {

        allgemas();
    
    }
   public void allgemas() 
    {
        if (transform.childCount==0)
        {
            Debug.Log("YA GANASTE, PERO NO PUEDES GANAR EL AMOR DE ELLA");
           

        }
    }
}
