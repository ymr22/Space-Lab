using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour
{
    public float delay = 0.1f;
    [Multiline]
    public string story;
  
    Text thisText;

    private void Start()
    {
        thisText = GetComponent<Text>();

        StartCoroutine(TypeWrite());
    }

    IEnumerator TypeWrite()
    {
        foreach(char i in story)
        {
            thisText.text += i.ToString();

            if(i.ToString() == ".") { yield return new WaitForSeconds(1); }
            else { yield return new WaitForSeconds(delay); }          
        }
    }
    
    public void LoadScene()
    {
        SceneManager.LoadScene("Station");
    }
}
