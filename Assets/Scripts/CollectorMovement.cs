using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectorMovement : MonoBehaviour
{
    public float moveSpeed = 5f;         // Speed of the character movement
    public float rotationSpeed = 10f;    // Speed of character rotation

    private Rigidbody rb;
    private Vector3 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveDirection = Vector3.zero;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        
        /*if (Input.GetKey((KeyCode.Backspace)))
        {
            SceneManager.LoadScene (PlayerPrefs.GetInt(""SavedScene""));
        }*/

        if (gameObject.transform.position == new Vector3(7.71f, 0, -9.45f))
        {
            SceneManager.LoadScene (PlayerPrefs.GetInt("SavedScene"));
        }
    }
    

    private void FixedUpdate()
    {
        MoveCharacter();
        RotateCharacter();
    }

    private void MoveCharacter()
    {
        Vector3 movement = moveDirection * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void RotateCharacter()
    {
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            Quaternion rotation = Quaternion.Lerp(rb.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(rotation);
        }
    }
}
