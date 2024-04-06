using UnityEngine;
using UnityEngine.SceneManagement;
public class AutoMovement : MonoBehaviour
{
    public Transform startPoint; // başlangıç noktası
    public Transform endPoint; // varış noktası
    public float speed = 1f; // hızı

    private float t = 0f; // zaman

    private void Start()
    {
        transform.position = startPoint.position; //başlangıç noktasındaki konumunu alır.
    }

    private void Update()
    {
       //Konumu hesaplayıp başlangıç ve bitiş arasında hareket ettirir.
        t += Time.deltaTime * speed;
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, t);

        // Hedefe ulaştıysa bitiyor.
        if (t >= 1f)
        {
            enabled = false;
        }
        
        if (Input.GetKey((KeyCode.Space)))
        {
            SceneManager.LoadScene (sceneName:"StoryScene");
        }
    }
}