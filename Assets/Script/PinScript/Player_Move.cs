using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    float h;
    float v;
    float speed = 7f;
    float jumpForce = 5f;
    bool isJump = true;

    Rigidbody rb;
    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }
    private void Update() {
        h = Input.GetAxis("Horizontal") * speed;
        v = Input.GetAxis("Vertical") * speed;

        Vector3 direction = new Vector3(h,0f,v).normalized;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

            Vector3 MoveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            rb.velocity = new Vector3(MoveDir.x * speed, rb.velocity.y, MoveDir.z * speed);
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            if(!isJump){
                Jump();
            }
        }
    }

    void Jump(){
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isJump = true;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground")){
            isJump = false;
        }
    }
}
