using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoor : MonoBehaviour
{
    public Vector3 openPosition;    
    public float slideSpeed = 2.0f; 

    private Vector3 closedPosition; 
    private bool isOpen = false;    

    private void Start()
    {
        closedPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            isOpen = !isOpen;
        }

        Vector3 targetPosition = isOpen ? openPosition : closedPosition;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * slideSpeed);
    }
}
