using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;
using MyBox;

[System.Serializable]
public class ApiFram
{
    public string APIName;
    public string URL;
    public bool Token;
    [ConditionalField(nameof(Token))]
    public string _Token;
}

public class API : MonoBehaviour
{
    public ApiFram[] Apis;
    public static API instance;
    public GameObject Toast;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //passing custom token
    public IEnumerator GetApi(string ApiName, string Token, System.Action<string> callback = null)
    {
        ApiFram _Api = Array.Find(Apis, item => item.APIName == ApiName);
        if (_Api == null)
        {
            Debug.LogWarning("Api did not found!");
            yield return null;
        }

        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            UnityWebRequest request = UnityWebRequest.Get(_Api.URL);
            request.SetRequestHeader("Authorization", "Bearer " + Token);
            yield return request.SendWebRequest();
            if (callback != null)
            {
                callback.Invoke(request.downloadHandler.text);
            }
        }
        else
        {

            TostMgs();
        }
    }

    //without passing token
    public IEnumerator GetApi(string ApiName, System.Action<string> callback = null)
    {
        ApiFram _Api = Array.Find(Apis, item => item.APIName == ApiName);
        if (_Api == null)
        {
            Debug.LogWarning("Api did not found!");
            yield return null;
        }
        //Debug.Log(_Api.URL);

        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            UnityWebRequest request = UnityWebRequest.Get(_Api.URL);
            if (_Api.Token)
            {
                request.SetRequestHeader("Authorization", "Bearer " + _Api._Token);
            }
            yield return request.SendWebRequest();
            if (callback != null)
            {
                callback.Invoke(request.downloadHandler.text);
            }
        }
        else
        {
            TostMgs();
        }
    }

    //custom url
    public IEnumerator GetApi(bool Url, string URL, System.Action<string> callback = null)
    {

        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            UnityWebRequest request = UnityWebRequest.Get(URL);
            yield return request.SendWebRequest();
            if (callback != null)
            {
                callback.Invoke(request.downloadHandler.text);
            }
        }
        else
        {
            TostMgs();
        }
    }
    //Post
    public IEnumerator GetApi(string ApiName, string Token, string[] FieldName, string[] FieldValue, System.Action<string> callback = null)
    {
        ApiFram _Api = Array.Find(Apis, item => item.APIName == ApiName);
        if (_Api == null)
        {
            Debug.LogWarning("Api did not found!");
            yield return null;
        }

        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            WWWForm form = new WWWForm();
            for (int i = 0; i < FieldName.Length; i++)
            {
                form.AddField(FieldName[i], FieldValue[i]);
            }
            UnityWebRequest request = UnityWebRequest.Post(_Api.URL, form);
            request.SetRequestHeader("Authorization", "Bearer " + Token);
            yield return request.SendWebRequest();
            if (callback != null)
            {
                callback.Invoke(request.downloadHandler.text);
            }
        }
        else
        {
            TostMgs();
        }
    }

    public IEnumerator GetApi(string ApiName, string[] FieldName, string[] FieldValue, System.Action<string> callback = null)
    {
        ApiFram _Api = Array.Find(Apis, item => item.APIName == ApiName);
        if (_Api == null)
        {
            Debug.LogWarning("Api did not found!");
            yield return null;
        }

        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            WWWForm form = new WWWForm();
            for (int i = 0; i < FieldName.Length; i++)
            {
                form.AddField(FieldName[i], FieldValue[i]);
            }
            UnityWebRequest request = UnityWebRequest.Post(_Api.URL, form);

            if (_Api.Token)
            {
                request.SetRequestHeader("Authorization", "Bearer " + _Api._Token);
            }
            yield return request.SendWebRequest();
            if (callback != null)
            {
                callback.Invoke(request.downloadHandler.text);
            }
        }
        else
        {
            TostMgs();
        }
    }
    void TostMgs()
    {
        Toast.SetActive(true);
        Toast.GetComponent<ToastCode>().Message("Invalid User Id or Password!");
    }
}