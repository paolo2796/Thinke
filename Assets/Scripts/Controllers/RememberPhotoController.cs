using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RememberPhotoController : RememberController {

    private const float DISTANCECAMERATEXTURE = (float)3.5;
    private const float DISTANCECAMERATEXTURE_HIGH = (float)10;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {



    }

    public void UpdateTexture(){
        Texture2D texture = new Texture2D(2, 2, TextureFormat.RGBA32, true, false);
        texture.LoadImage(base.GetRemember().GetMedia());
        Util.ResizeScaleRememberToPoint(this.gameObject, texture);
        Renderer[] allChildren = GetComponentsInChildren<Renderer>();
        allChildren[1].GetComponent<Renderer>().material.mainTexture = texture;
    }
}
