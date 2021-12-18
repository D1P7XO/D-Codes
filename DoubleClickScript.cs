using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using DG.Tweening;

public class DoubleClickScript : MonoBehaviour
{

    private float maxTime = 0.5f;
    private float lastTimeClicked;
    VideoPlayer Player;
    public GameObject FullScreanVideo;


    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float deltaTime = Time.time - lastTimeClicked;

            if (deltaTime < maxTime)
            {
                Debug.Log("Double Click!");
                Player = GetComponent<VideoPlayer>();
                Player.renderMode = VideoRenderMode.RenderTexture;
                FullScreanVideo.SetActive(true);
                MainMenuScripts.OpenStatus = true;
            }
            else
            {
                Debug.Log("Single Click!");
            }

            lastTimeClicked = Time.time;
        }
    }
    public void Clicked()
    {
        Debug.Log("Double Click!");
        Player = GetComponent<VideoPlayer>();
        //Player.renderMode = VideoRenderMode.RenderTexture;
        FullScreanVideo.SetActive(true);
        MainMenuScripts.OpenStatus = true;
    }
}
