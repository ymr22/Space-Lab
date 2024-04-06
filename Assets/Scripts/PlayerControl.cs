using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerControl : MonoBehaviour
{
    public CharacterController controller;

    public float runningSpeed = 4;
    public float gravity = 8;
    public float rotationSpeed = 240;
    private bool running = false;
    private float rot = 0f;
    
    private Animator anim;

    public Vector3 moveDir = Vector3.zero;

    void Start() {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController> ();
    }

    void Update() {

        
        if (controller.isGrounded) {
            
            if (Input.GetKey(KeyCode.UpArrow)) {
                running = true;
                moveDir = new Vector3 (0, 0, 1);
                moveDir *= runningSpeed;
                moveDir = transform.TransformDirection(moveDir);
                anim.SetBool("walk",true);
            } 
            else if (Input.GetKey(KeyCode.DownArrow)) {
                running = true;
                moveDir = new Vector3 (0, 0, -1);
                moveDir *= runningSpeed;
                moveDir = transform.TransformDirection(moveDir);
                anim.SetBool("walk",true);
            }else {
                anim.SetBool("walk",true);
                moveDir = new Vector3 (0, 0, 0);
                running = false;
            }
            
            if (Input.GetKey(KeyCode.RightArrow)) {
                anim.SetBool("walk",false);
                rot += rotationSpeed * Time.deltaTime;
                transform.Rotate(0,3,0);
            }
            if (Input.GetKey(KeyCode.LeftArrow)) {
                anim.SetBool("walk",false);
                rot -= rotationSpeed * Time.deltaTime;
                transform.Rotate(0,-3,0);
            }
            
            if (Input.GetKey((KeyCode.Backspace)))
            {
                PlayerPrefs.SetInt("SavedScene",SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene (sceneName:"CollectElements");
            }
        }
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }
}
