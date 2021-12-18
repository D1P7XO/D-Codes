using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ToastCode : MonoBehaviour
{
    TMP_Text Mgs;

    private void OnEnable()
    {
        GameObject text = transform.GetChild(0).gameObject;
        Mgs = text.GetComponent<TMP_Text>();
        FadeController.FadeAll(0, 1, 1, gameObject);
        StartCoroutine(ActiveFalse());
    }
    public void Message(string s)
    {
        Mgs.text = s;
    }
    IEnumerator ActiveFalse()
    {
        yield return new WaitForSeconds(3);
        FadeController.FadeAll(1, 0, 1, gameObject);
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
