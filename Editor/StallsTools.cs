using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Video;


public class StallsTools : EditorWindow
{
    public int I;
    public int J;
    public TextAsset Asset;
    public GameObject Possition;
    public VideoController Cont;
    public Maps Map;
    public StallApi StallMaps;
    public GameObject VideoObject;
    public GameObject[] ChildPossition;

    public GameObject Stalls;
    public GameObject[] ChildStalls;

    public Renderer[] MainBanner;

    public Renderer[] LeftBanner;

    public Renderer[] RightBanner;

    public Renderer[] ExeBannerOne;
    public Renderer[] ExeBannerTwo;
    public Renderer[] Logo;
    public Renderer[] LogoDesk;
    public Renderer[] Mat;
    public GameObject Video;
    FullScreanVideoClose FullScreanVideo;
    //public FullScreanVideoClose FullScreanVideo;

    //public YoutubePlayers[] URL;
    //public YoutubePlayers[] URL;

    string AssignStall = "Set Stalls";
    ReadJson[] User;
    string Data;
    [MenuItem("MCT/MCT Game")]
    static void Init()
    {
        StallsTools window = (StallsTools)EditorWindow.GetWindow(typeof(StallsTools));
        window.Show();
    }

    void OnGUI()
    {
        Asset = EditorGUILayout.ObjectField("Stall Data", Asset, typeof(TextAsset), true) as TextAsset;
        Cont = EditorGUILayout.ObjectField("Video Controller", Cont, typeof(VideoController), true) as VideoController;
        //FullScreanVideo = EditorGUILayout.ObjectField("Full Screan Video", FullScreanVideo, typeof(FullScreanVideoClose), true) as FullScreanVideoClose;
        Possition = EditorGUILayout.ObjectField("Stall Possition", Possition, typeof(GameObject), true) as GameObject;
        Stalls = EditorGUILayout.ObjectField("Stalls", Stalls, typeof(GameObject), true) as GameObject;
        Map = EditorGUILayout.ObjectField("Maps", Map, typeof(Maps), true) as Maps;
        VideoObject = EditorGUILayout.ObjectField("VideoObject", VideoObject, typeof(GameObject), true) as GameObject;
        //Mat = EditorGUILayout.ObjectField("Materials", Mat, typeof(Material), true) as Material;
        I = EditorGUILayout.IntField("Start Stall Number:", I);
        J = EditorGUILayout.IntField("End Stall Number:", J);
        /*//ChildPossition;
        ScriptableObject ChildPossition_scriptableObj = this;
        SerializedObject ChildPossition_serialObj = new SerializedObject(ChildPossition_scriptableObj);
        SerializedProperty ChildPossition_serialProp = ChildPossition_serialObj.FindProperty("ChildPossition");

        EditorGUILayout.PropertyField(ChildPossition_serialProp, true);
        ChildPossition_serialObj.ApplyModifiedProperties();


        //ChildStalls;
        ScriptableObject ChildStalls_scriptableObj = this;
        SerializedObject ChildStalls_serialObj = new SerializedObject(ChildStalls_scriptableObj);
        SerializedProperty ChildStalls_serialProp = ChildStalls_serialObj.FindProperty("ChildStalls");

        EditorGUILayout.PropertyField(ChildStalls_serialProp, true);
        ChildStalls_serialObj.ApplyModifiedProperties();


        //MainBanner;
        ScriptableObject MainBanner_scriptableObj = this;
        SerializedObject MainBanner_serialObj = new SerializedObject(MainBanner_scriptableObj);
        SerializedProperty MainBanner_serialProp = MainBanner_serialObj.FindProperty("MainBanner");

        EditorGUILayout.PropertyField(MainBanner_serialProp, true);
        MainBanner_serialObj.ApplyModifiedProperties();

        //LeftBanner;
        ScriptableObject LeftBanner_scriptableObj = this;
        SerializedObject LeftBanner_serialObj = new SerializedObject(LeftBanner_scriptableObj);
        SerializedProperty LeftBanner_serialProp = LeftBanner_serialObj.FindProperty("LeftBanner");

        EditorGUILayout.PropertyField(LeftBanner_serialProp, true);
        LeftBanner_serialObj.ApplyModifiedProperties();

        //RightBanner;
        ScriptableObject RightBanner_scriptableObj = this;
        SerializedObject RightBanner_serialObj = new SerializedObject(MainBanner_scriptableObj);
        SerializedProperty RightBanner_serialProp = RightBanner_serialObj.FindProperty("RightBanner");

        EditorGUILayout.PropertyField(RightBanner_serialProp, true);
        RightBanner_serialObj.ApplyModifiedProperties();

        //ExeBanner;
        ScriptableObject ExeBanner_scriptableObj = this;
        SerializedObject ExeBanner_serialObj = new SerializedObject(ExeBanner_scriptableObj);
        SerializedProperty ExeBanner_serialProp = ExeBanner_serialObj.FindProperty("ExeBanner");

        EditorGUILayout.PropertyField(ExeBanner_serialProp, true);
        ExeBanner_serialObj.ApplyModifiedProperties();*/

        //URL;
        /*ScriptableObject ExeBanner_scriptableObj = this;
        SerializedObject ExeBanner_serialObj = new SerializedObject(ExeBanner_scriptableObj);
        SerializedProperty ExeBanner_serialProp = ExeBanner_serialObj.FindProperty("URL");

        EditorGUILayout.PropertyField(ExeBanner_serialProp, true);
        ExeBanner_serialObj.ApplyModifiedProperties();*/


        if (GUILayout.Button(AssignStall))
        {
            GameObject gameObject = new GameObject();
            gameObject.name = "All Stalls";
            Cont.videoPlayer = new VideoPlayer[J-I];
            Possition.transform.position = new Vector3(Possition.transform.position.x, 0, Possition.transform.position.z);
            FullScreanVideo = VideoObject.GetComponent<FullScreanVideoClose>();
            FullScreanVideo.Videos = new VideoPlayer[J - I];
            //var temp = Resources.Load<TextAsset>("Text/StallInfo");
            //Data = temp.ToString();
            Data = Asset.ToString();
            string JsonUser = JsonHelper.fixJson(Data);
            User = JsonHelper.FromJson<ReadJson>(JsonUser);
            Debug.Log(User[0].stall_type_id);

            ChildPossition = new GameObject[Possition.transform.childCount];
            ChildStalls = new GameObject[Stalls.transform.childCount];

            MainBanner = new Renderer[J - I];
            LeftBanner = new Renderer[J - I];
            RightBanner = new Renderer[J - I];
            ExeBannerOne = new Renderer[J - I];
            ExeBannerTwo = new Renderer[J - I];
            Logo = new Renderer[J - I];
            LogoDesk = new Renderer[J - I];
            Mat = new Renderer[J - I];
            //URL = new YoutubePlayers[J - I];

            for (int i = 0; i < Stalls.transform.childCount; i++)
            {
                ChildStalls[i] = Stalls.transform.GetChild(i).gameObject;
                Debug.Log(i);
            }


            for (int i = 0; i < ChildPossition.Length; i++)
            {
                ChildPossition[i] = Possition.transform.GetChild(i).gameObject;
            }
            Color c;
            for (int i = I; i < J; i++)
            {
                Debug.Log(i);
                GameObject tempObject = Instantiate(ChildStalls[User[i].stall_type_id - 1], ChildPossition[User[i - I].position - 1].transform.position, ChildPossition[User[i - I].position - 1].transform.rotation);
                tempObject.name = (i - I).ToString();
                tempObject.GetComponent<StallApi>().m = Map;
                tempObject.transform.parent = gameObject.transform;
                tempObject = tempObject.transform.GetChild(0).gameObject;
                tempObject.name = User[i].id.ToString();

                MainBanner[i - I] = tempObject.transform.GetChild(0).GetComponent<Renderer>();
                MainBanner[i - I].material.mainTexture = Base64.Base64ToImg(User[i].main_banner);

                LeftBanner[i - I] = tempObject.transform.GetChild(1).GetComponent<Renderer>();
                LeftBanner[i - I].material.mainTexture = Base64.Base64ToImg(User[i].left_banner);

                RightBanner[i - I] = tempObject.transform.GetChild(2).GetComponent<Renderer>();
                RightBanner[i - I].material.mainTexture = Base64.Base64ToImg(User[i].right_banner);

                ExeBannerOne[i - I] = tempObject.transform.GetChild(3).GetComponent<Renderer>();
                ExeBannerOne[i - I].material.mainTexture = Base64.Base64ToImg(User[i].exe_banner);

                ExeBannerTwo[i - I] = tempObject.transform.GetChild(4).GetComponent<Renderer>();
                ExeBannerTwo[i - I].material.mainTexture = Base64.Base64ToImg(User[i].exe_banner2);

                Logo[i - I] = tempObject.transform.GetChild(5).GetComponent<Renderer>();
                Logo[i - I].material.mainTexture = Base64.Base64ToImg(User[i].stall_logo);

                LogoDesk[i - I] = tempObject.transform.GetChild(6).GetComponent<Renderer>();
                LogoDesk[i - I].material.mainTexture = Base64.Base64ToImg(User[i].stall_logo);

                ColorUtility.TryParseHtmlString(User[i].color, out c);
                Mat[i - I] = tempObject.transform.GetChild(7).GetComponent<Renderer>();
                Mat[i - I].material.color = c;
                Debug.Log(User[i].color);

                /*URL[i - I] = tempObject.transform.GetChild(4).GetComponent<YoutubePlayers>();
                URL[i - I].youtubeUrl = User[i].video_link;*/


               // URL[i - I] = tempObject.transform.GetChild(8).GetComponent<YoutubePlayers>();
               // URL[i - I].youtubeUrl = User[i].video_link;
                Video = tempObject.transform.GetChild(8).gameObject;
                Video.GetComponent<DoubleClickScript>().FullScreanVideo = VideoObject;
                Cont.videoPlayer[i - I] = tempObject.transform.GetChild(8).GetComponent<VideoPlayer>();
                FullScreanVideo.Videos[i - I] = tempObject.transform.GetChild(8).GetComponent<VideoPlayer>();

                /*Logo[i - I] = tempObject.transform.GetChild(8).GetComponent<Renderer>();
                Logo[i - I].material.mainTexture = Base64.Base64ToImg(User[i].exe_banner);*/
                //URL[i - I].url = "http://spiralworld.biz:8080/test.mp4";



            }
            Possition.transform.position = new Vector3(Possition.transform.position.x, 2.6f, Possition.transform.position.z);

        }
    }

}