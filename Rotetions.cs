using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotetions : MonoBehaviour
{
    public Vector3 X;
    public LoopType loop;
    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(X, 2).SetLoops(-1, loop);
    }

}
