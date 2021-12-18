// Run in split-screen mode
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class vrSwitch : MonoBehaviour
{
    public bool vr = false;
    public string BackScence;
    void Start()
    {
        if (vr == false)
        {
            StartCoroutine(LoadDevice("None"));
        }
        else
        {
            StartCoroutine(LoadDevice("cardboard"));
        }
            
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (BackScence != "none")
            {
                SceneManager.LoadScene(BackScence);
            }
            else
            {
                Application.Quit();
            }
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