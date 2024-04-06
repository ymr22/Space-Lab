using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowList : MonoBehaviour
{
    public GameObject list;

    private void Start()
    {
        list.SetActive(false);
    }

    private void OnTriggerEnter(Collider obj){ // turn message on when player is inside the trigger
        if (obj.tag == "Player")
        {
            gameObject.SetActive(true);
            list.SetActive(true);
        }
    }
    
}
