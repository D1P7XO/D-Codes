using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class vrSwitch : MonoBehaviour
{
    public bool VR = false;
    void Start()
    {
        if (!VR)
        {
            StartCoroutine(LoadDevice("None"));
        }
        else
        {
            StartCoroutine(LoadDevice("cardboard"));
        }    
    }
    IEnumerator LoadDevice(string newDevice)
    {
        if (String.Compare(XRSettings.loadedDeviceName, newDevice, true) != 0)
        {
            XRSettings.LoadDeviceByName(newDevice);
            yield return null;
            XRSettings.enabled = true;
        }
    }
}