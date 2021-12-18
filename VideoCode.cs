using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoCode : MonoBehaviour
{
    public VideoPlayer VideosAllPlayed;
    // Start is called before the first frame update
    public void VideoOnOff(Toggle change)
    {
        if (change.isOn)
        {
            VideosAllPlayed.Pause();
        }
        else
        {
            VideosAllPlayed.Play();
        }
        //Debug.Log(change.isOn);
    }
}
