using UnityEngine;

public class ScreenRotation : MonoBehaviour
{
    public ScreenOrientation screenOrientation;
    void Start()
    {
        Screen.orientation = screenOrientation;
    }
}
