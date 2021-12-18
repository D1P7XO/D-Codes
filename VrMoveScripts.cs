using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class VrMoveScripts : MonoBehaviour
{
    public int playerSpeed;

    public void Start()
    {

    }
    public void Update()
    {



        if (Input.GetButton("Fire1"))
        {
            transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
        }


    }
}
