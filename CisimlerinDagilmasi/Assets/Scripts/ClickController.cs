using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class ClickController : MonoBehaviour
{
    public GameObject clickedObject;
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            // for clicked object detection
           Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           RaycastHit hit;


            
            if (Physics.Raycast(ray, out hit, 100))
            {
                clickedObject = hit.transform.gameObject;
               
            }
            Debug.Log("clickControl: " + clickedObject.name);
            
        }
        //Debug.Log("Counter: " + counter);
    }
}