using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Touch Touch;
    public bool LeftRight; // Make this true For Child Game Object
    public bool UpDown; // Make this true For Parent Game Object
    private Vector3 rotationY;
    private Vector3 rotationX;
    public float rotationSpeed = .1f;


    private void FixedUpdate()
    {
        if (Maps.Move)
        {
            if (Input.touchCount >= 0)
            {
                var tapCount = Input.touchCount;
                for (var i = 0; i < tapCount; i++)
                {
                    Touch = Input.GetTouch(i);
                    //Do whatever you want with the current touch.
                }
                //Touch = Input.GetTouch(0);
                if (Touch.phase == TouchPhase.Moved)
                {
                    rotationY = new Vector3(0f, -Touch.deltaPosition.x * rotationSpeed, 0f);
                    rotationX = new Vector3(Touch.deltaPosition.y * rotationSpeed, 0f, 0f);
                    if (UpDown)
                    {

                        if (transform.position.y < 2.5f)
                        {
                            if (transform.position.y > 0.8f)
                            {
                                /*transform.Rotate(rotationX);
                                Debug.Log(transform.eulerAngles.x);*/
                                transform.Translate(0, rotationX.x, 0);
                                //Debug.Log(transform.eulerAngles.x);}
                                Debug.Log(transform.position);
                            }
                            else
                            {
                                transform.position = new Vector3(transform.position.x, 0.89f, transform.position.z);
                                Debug.Log("Down");
                            }
                        }
                        else
                        {
                            transform.position = new Vector3(transform.position.x, 2.49f, transform.position.z);
                            Debug.Log("UP");
                        }
                    }
                    if (LeftRight)
                    {
                        transform.Rotate(-rotationY);
                    }
                }
            }
        }
    }
}