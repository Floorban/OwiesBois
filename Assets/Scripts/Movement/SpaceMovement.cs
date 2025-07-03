using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UIElements;

public class SpaceMovement : MonoBehaviour
{
    [SerializeField] float maxSpeed = 5;
    [SerializeField] float acc = 0.001f;

    [SerializeField] float relForwardSpeed = 0;
    [SerializeField] float relSideSpeed = 0;
    [SerializeField] float relUpSpeed = 0;

    [SerializeField] float timer = 3f;
    bool startAnim;
    bool animplaying =false;
    [SerializeField] float timeSinceStarted = 0f;
    Vector3 posanim;
    Quaternion rotanim;
    float timerz = 0f;
    [SerializeField] private AnimationCurve curve;

    [SerializeField] Quaternion rot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        controls();
    }

    private void controls() {
        rot = transform.GetChild(1).localRotation;
        bool mov = false;
        this.transform.position += transform.forward * relForwardSpeed;
        this.transform.position += transform.forward * relSideSpeed;
        this.transform.position += transform.up * -relUpSpeed;

        if (Input.GetKey(KeyCode.W)) {
            if (relForwardSpeed < maxSpeed) {
                relForwardSpeed += acc;
            }
        } else if (relForwardSpeed >= 0) {
            relForwardSpeed -= acc / 2;
        } 
        if (Input.GetKey(KeyCode.S)) {
            if (relForwardSpeed < maxSpeed) {
                relForwardSpeed -= acc;
            }
        } else if (relForwardSpeed <= 0) {
            relForwardSpeed += acc / 2;
        }
        if (Input.GetKey(KeyCode.A)) {
            mov = true;
            if (relSideSpeed < maxSpeed) {
                relSideSpeed += acc;
                if (transform.GetChild(1).eulerAngles.z < 16 || transform.GetChild(1).eulerAngles.z > 345) {
                    transform.GetChild(1).Rotate(new Vector3(0f, 0f, 0.1f));
                }
            }
            transform.RotateAround(transform.GetChild(0).GetChild(0).transform.position, -transform.up, 2000 * acc);
        } else if (relSideSpeed >= 0) {
            relSideSpeed -= acc / 2;
            this.transform.position += transform.right * relSideSpeed;
        }
        if (Input.GetKey(KeyCode.D)) {
            mov = true;

            if (relSideSpeed < maxSpeed) {
                if (transform.GetChild(1).eulerAngles.z < 0.1f) {
                    transform.GetChild(1).localRotation = Quaternion.Euler(0f, 0f, 359f);
                }
                relSideSpeed += acc;
                Debug.Log(transform.GetChild(1).eulerAngles.z);
                if (transform.GetChild(1).eulerAngles.z < 16 || transform.GetChild(1).eulerAngles.z > 345) {
                    transform.GetChild(1).Rotate(new Vector3(0f, 0f, -0.1f));
                }
            }
            transform.RotateAround(transform.GetChild(0).GetChild(1).transform.position, transform.up, 2000 * acc);
        } else if (relSideSpeed >= 0) {
            relSideSpeed -= acc / 2;
            this.transform.position += -transform.right * relSideSpeed;
        }

        if (Input.GetKey(KeyCode.Q)) {
            mov = true;
            if (relUpSpeed < maxSpeed) {
                relUpSpeed += acc;
                transform.GetChild(1).transform.RotateAround(transform.GetChild(0).GetChild(2).transform.position, transform.right, 2000 * acc);
            } 
        } else if (relUpSpeed >= 0) {
            relUpSpeed -= acc / 2;
        }
        if (Input.GetKey(KeyCode.E)) {
            mov = true;
            if (relUpSpeed < maxSpeed) {
                relUpSpeed -= acc;
                transform.GetChild(1).transform.RotateAround(transform.GetChild(0).GetChild(3).transform.position, -transform.right, 2000 * acc);
            } 
        } else if (relUpSpeed <= 0) {
            relUpSpeed += acc / 2;
        }

        if (timer > 0 && !mov) {
            timer -= Time.deltaTime;
        } else if (timer<=0 && !mov) {
            startAnim = true;
            timer = 3;
        } else {
            startAnim = false;
            animplaying = false;
            timer = 5;
        }

        if (transform.GetChild(1).eulerAngles.z > 0 && transform.GetChild(1).eulerAngles.z < 270) {
            transform.GetChild(1).Rotate(new Vector3(0f, 0f, -0.01f));
        } 
        if (transform.GetChild(1).eulerAngles.z < 0 || transform.GetChild(1).eulerAngles.z > 270) {
            transform.GetChild(1).Rotate(new Vector3(0f, 0f, 0.01f));
        }
        if (startAnim) {
            StartAnim();
        }
    }

    void StartAnim() {
        if (!animplaying){
            posanim = transform.GetChild(2).position;
            rotanim = transform.GetChild(2).rotation;
            timeSinceStarted = 0f;
            animplaying = true;
        }
        MoveCam();
    }
    void MoveCam() {   
        timeSinceStarted += Time.deltaTime;
        float percentage = timeSinceStarted / 5f;
        transform.GetChild(2).position = Vector3.Lerp(transform.GetChild(2).position, transform.GetChild(1).GetChild(0).position,curve.Evaluate(percentage));
        transform.GetChild(2).rotation = Quaternion.Lerp(rotanim, transform.GetChild(1).GetChild(0).rotation, curve.Evaluate(percentage));

        if (percentage >= 5) { 
            animplaying=false;
            timeSinceStarted=0;
        }
    }
}
