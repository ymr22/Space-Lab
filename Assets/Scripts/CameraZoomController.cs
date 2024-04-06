using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CameraZoomController : MonoBehaviour
{
    
    public Transform finalTarget; // Sonraki zoom yapılacak hedef (başka nesne)

    public float initialZoomDuration = 3f; 
    public float finalZoomDuration = 3f; 

    public float initialZoomAmount = 2f;
    public float finalZoomAmount = 2f;

    public TMP_Text zoomText;
    public Button zoomButton;
    
    private Camera mainCamera;
    private float originalSize;
    private float initialTargetSize;
    private float finalTargetSize;
    private float zoomTimer;
    private bool initialZoomCompleted = false;
    private bool finalZoomCompleted = false;
    private Vector3 initialCameraPosition;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        initialCameraPosition = mainCamera.transform.position;
        originalSize = mainCamera.orthographicSize;
        initialTargetSize = originalSize / initialZoomAmount;
        finalTargetSize = originalSize / finalZoomAmount;
        zoomTimer = 0f;

        mainCamera.orthographicSize = originalSize;
        if (zoomText != null)
        {
            
            zoomText.gameObject.SetActive(false);
            zoomButton.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (!initialZoomCompleted)
        {
            zoomTimer += Time.deltaTime;

            if (zoomTimer <= initialZoomDuration)
            {
                float t = zoomTimer / initialZoomDuration;
                mainCamera.orthographicSize = Mathf.Lerp(originalSize, initialTargetSize, t);
            }
            else if (zoomTimer <= initialZoomDuration + 1f)
            {
                if (zoomText != null)
                {
                    zoomText.gameObject.SetActive(true);
                    zoomButton.gameObject.SetActive(true);
                }
            }
            else
            {
                mainCamera.orthographicSize = initialTargetSize;
                initialZoomCompleted = true;
            }
        }
        else if (!finalZoomCompleted)
        {
            zoomTimer += Time.deltaTime;

            if (zoomTimer <= initialZoomDuration + finalZoomDuration)
            {
                float t = (zoomTimer - initialZoomDuration) / finalZoomDuration;
                mainCamera.orthographicSize = Mathf.Lerp(initialTargetSize, finalTargetSize, t);
            }
            else
            {
                mainCamera.orthographicSize = finalTargetSize;
                finalZoomCompleted = true;
            }
        }

        if (finalZoomCompleted && finalTarget != null)
        {
            transform.position = initialCameraPosition;
        }
    }

}