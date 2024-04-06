using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleExperiment : MonoBehaviour
{
    public GameObject panel;

    public void StartSample()
    {
        SceneManager.LoadScene (sceneName:"SampleExperiment");
    }
    
    public void StartReal()
    {
        panel.SetActive(false);
    }
}
