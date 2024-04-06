using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorController : MonoBehaviour
{
    public int NumberOfElements { get; set; }

    public void ElementCollected()
    {
        NumberOfElements++;
    }
}
