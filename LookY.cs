using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float _mouseY = Input.GetAxis("Mouse Y");
        Vector3 newrotation = transform.localEulerAngles;
        newrotation.x += _mouseY;
        if (ThirdPersonUserControl.MouseRotation)
        {
            transform.localEulerAngles = newrotation;
        }



    }
}
