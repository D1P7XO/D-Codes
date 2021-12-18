using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]


public class RawJson : MonoBehaviour
{

    /*public Rub_ _Rub = new Rub_();
    public Marks_[] M = new Marks_[7];
    private void Start()
    {

        _Rub.marks = M;
        _Rub.stall_id = "379";
        _Rub.marks[0].rubrics_category_id = "2";
        _Rub.marks[0].marks = "30";
        _Rub.marks[1].rubrics_category_id = "3";
        _Rub.marks[1].marks = "50";
        _Rub.marks[2].rubrics_category_id = "4";
        _Rub.marks[2].marks = "10";
        _Rub.marks[3].rubrics_category_id = "5";
        _Rub.marks[3].marks = "30";
        _Rub.marks[4].rubrics_category_id = "6";
        _Rub.marks[4].marks = "10";
        _Rub.marks[5].rubrics_category_id = "7";
        _Rub.marks[5].marks = "10";
        _Rub.marks[6].rubrics_category_id = "8";
        _Rub.marks[6].marks = "10";
        string S = JsonUtility.ToJson(_Rub);
        Debug.Log(S);
        StartCoroutine(Sub());

    }
    IEnumerator Sub()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            string Data = JsonUtility.ToJson(_Rub);
            UnityWebRequest request = UnityWebRequest.Put("https://spiralworld.biz/spiralworld/post/rubrics_marks", Data);
            request.method = UnityWebRequest.kHttpVerbPOST;

            request.SetRequestHeader("Authorization", "Bearer ToQIggsrCTajj429cABj7CMmbMosn3");
            request.SetRequestHeader("Content-Type", "application/text");
            request.SetRequestHeader("Accept", "application/text");
            //request.SetRequestHeader("Authorization", "Bearer " + PlayerPrefs.GetString("Token"));
            *//*            request.SetRequestHeader("Access-Control-Allow-Origin", "*");
                        request.SetRequestHeader("Access-Control-Allow-Methods", "POST, GET, OPTIONS");
                        request.SetRequestHeader("Access-Control-Allow-Headers", "origin, Content-Type: application/wasm, accept");*//*

            yield return request.SendWebRequest();
            Debug.Log(request.downloadHandler.text);
        }
    }*/
    //Rub Marks = new Rub();
    //Example string param= "{"username":"aaa","app_key":"webGLTesting","password":"aaa"}";
}
