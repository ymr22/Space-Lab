using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Element : MonoBehaviour
{
    
    public TMP_Text text;
    private void OnTriggerEnter(Collider other)
    {
        CollectorController collectorController = other.GetComponent<CollectorController>();
        
        if(collectorController != null) 
        {
            collectorController.ElementCollected();
            gameObject.SetActive(false);
            if (text.text.Length == 11)
                text.text += gameObject.name.ToString();
            else 
                text.text += ", " + gameObject.name.ToString();
        }
    }
}
