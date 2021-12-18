using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Copy : MonoBehaviour
{
    //public Text t;
    // Start is called before the first frame update
   /* private void Start()
    {
        //ClipboardHelper.Copy(t.text);
        TextEditor te = new TextEditor();
        te.content = new GUIContent(t.text);
        te.SelectAll();
        te.Copy();

    }*/

    // Update is called once per frame
    /*public void test()
    {
        TextEditor te = new TextEditor();
        te.content = new GUIContent(t.text);
        te.SelectAll();
        te.Copy();
        // text.text.CopyToClipboard();
        Debug.Log("Copy");
        string[] Split = t.text.Split(char.Parse(":"));
        Debug.Log(Split[1]);

    }*/
}
/*public static class ClipboardExtension
{
    /// <summary>
    /// Puts the string into the Clipboard.
    /// </summary>
    public static void CopyToClipboard(this string str)
    {
        GUIUtility.systemCopyBuffer = str;
    }
}*/
