using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.0f;
    [SerializeField] float slowMoveSpeed = 10.0f;
    [SerializeField] float boostMoveSpeed = 30.0f;
    [SerializeField] float steerSpeed = 300.0f;
    [SerializeField] float defaultMoveSpeed = 20.0f;
    [SerializeField] float timeOfBoost = 3.0f;

    private float startWatch;
    private bool shouldCheck;

    void Start(){
        moveSpeed = defaultMoveSpeed;
        startWatch = Time.time;
        shouldCheck = false;
    }

    void Update(){
        float steerMovement = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float carMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerMovement);
        transform.Translate(0, carMovement, 0);
        if(shouldCheck && Time.time - startWatch >= timeOfBoost) {
            moveSpeed = defaultMoveSpeed;
            shouldCheck = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowMoveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "SlowDown"){
            Debug.Log("Slow");
            moveSpeed = slowMoveSpeed;
            shouldCheck = true;
            startWatch = Time.time;
        }else if(other.tag == "SpeedUp"){
            Debug.Log("SpeedUp");
            moveSpeed = boostMoveSpeed;
            shouldCheck = true;
            startWatch = Time.time;
        }
    }
}
