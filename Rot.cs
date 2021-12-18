using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Rot : MonoBehaviour
{
    public GameObject[] Persion;
    public float Rote;
    public FloatingJoystick JoyStick;
    // Start is called before the first frame update
    void Start()
    {
        //PersionOne();
        Persion = new GameObject[this.transform.childCount];
        for (int i = 0; i < Persion.Length; i++)
        {
            Persion[i] = this.gameObject.transform.GetChild(i).gameObject;
        }
        Avtar(0);
    }

    // Update is called once per frame
    void Update()
    {
        float x = JoyStick.Horizontal * Rote;
        transform.Rotate(0, -x, 0);
    }
    public void Next(string Sence) {
        SceneManager.LoadScene(Sence);
    }
    public void Avtar(int Number)
    {
        foreach(GameObject persons in Persion)
        {
            persons.SetActive(false);
        }
        Persion[Number].SetActive(true);
        PlayerPrefs.SetInt("Player", Number);
    }
}
