using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson {
    public class LookX : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float _mouseX = Input.GetAxis("Mouse X");
            Vector3 newrotation = transform.localEulerAngles;
            newrotation.y += _mouseX;
            if (ThirdPersonUserControl.MouseRotation)
            {
                transform.localEulerAngles = newrotation;

            }
        }
    } 
}
