using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SandRot : MonoBehaviour
{
    public GameObject Sand;
    public GameObject Round;
    public LoopType loop;
    // Start is called before the first frame update
    void Start()
    {
        Round.transform.DOScale(1.4f, 2).SetLoops(-1, loop);
        Sand.transform.DORotate(new Vector3(0, 0, 90), 2).SetLoops(-1, LoopType.Incremental);
    }

    // Update is called once per frame
}
