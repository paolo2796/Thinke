using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Util : MonoBehaviour {

    public const float DISTANCECAMERATEXTURE_Picture = (float)240f;
    public const float DISTANCECAMERATEXTURE_HIGH_Picture = (float)360f;

    public const float DISTANCECAMERATEXTURE_Remember = (float)14;
    public const float DISTANCECAMERATEXTURE_HIGH_Remember = (float)30;
    public const string ARCamera = "ARCamera";


    public static string FormatterTimerToString(float number) {


        int minute = ((int)number / 60);
        float second = (number % 60);

        string minutes;
        string seconds;



        if (minute < 10)
            minutes = "0" + minute;
        else
            minutes = minute.ToString();


        seconds = second.ToString("0");


        return (minutes + ":" + seconds);


    }


    static System.DateTime ConvertFromUnixTimestamp(string timestamp)
    {
        System.DateTime origin = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
        return origin.AddSeconds(double.Parse(timestamp)).ToUniversalTime();

    }

   public static void ResizeScalePictureToPoint(GameObject gO, Texture2D texture) {
        if (texture.width > Screen.width || texture.height > Screen.height)
            gO.transform.localScale = new Vector3(texture.width / ((float)2.0 * DISTANCECAMERATEXTURE_HIGH_Picture * Mathf.Tan(Camera.main.fieldOfView * (float)0.5 * Mathf.Deg2Rad)), texture.height / ((float)2.0 * DISTANCECAMERATEXTURE_HIGH_Picture * Mathf.Tan(Camera.main.fieldOfView * (float)0.5 * Mathf.Deg2Rad)), gO.transform.localScale.z);
        else
            gO.transform.localScale = new Vector3(texture.width / ((float)2.0 * DISTANCECAMERATEXTURE_Picture * Mathf.Tan(Camera.main.fieldOfView * (float)0.5 * Mathf.Deg2Rad)), texture.height / ((float)2.0 * DISTANCECAMERATEXTURE_Picture * Mathf.Tan(Camera.main.fieldOfView * (float)0.5 * Mathf.Deg2Rad)), gO.transform.localScale.z);
    }


    public static void ResizeScaleRememberToPoint(GameObject gO, Texture2D texture){
        if (texture.width > Screen.width || texture.height > Screen.height)
            gO.transform.localScale = new Vector3(texture.width / ((float)2.0 * DISTANCECAMERATEXTURE_HIGH_Remember * Mathf.Tan(Camera.main.fieldOfView * (float)0.5 * Mathf.Deg2Rad)), texture.height / ((float)2.0 * DISTANCECAMERATEXTURE_HIGH_Remember * Mathf.Tan(Camera.main.fieldOfView * (float)0.5 * Mathf.Deg2Rad)), gO.transform.localScale.z);
        else
            gO.transform.localScale = new Vector3(texture.width / ((float)2.0 * DISTANCECAMERATEXTURE_Remember * Mathf.Tan(Camera.main.fieldOfView * (float)0.5 * Mathf.Deg2Rad)), texture.height / ((float)2.0 * DISTANCECAMERATEXTURE_Remember * Mathf.Tan(Camera.main.fieldOfView * (float)0.5 * Mathf.Deg2Rad)), gO.transform.localScale.z);
    }

}
