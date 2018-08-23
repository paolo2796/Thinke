using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCamScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {


            GameObject cameraParent = new GameObject("camParent");
            cameraParent.transform.position = this.transform.position + new Vector3(0,0,0);
            this.transform.parent = cameraParent.transform;
            cameraParent.transform.Rotate(Vector3.down, 90f);

       


        Input.gyro.enabled = true;

    }



    // Update is called once per frame
    void Update()
    {

        Quaternion cameraRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        this.transform.localRotation = cameraRotation;
        // bullet.transform.position = Camera.main.transform.position + new Vector3(0, 0, 2.33f);
        // bullet.transform.rotation = Camera.main.transform.rotation;
       
    }

    private void OnGUI(){

        GUILayout.Label(" Rotation CAmera: " + Camera.main.transform.rotation);
      //  GUILayout.Label("Rotation bullet:" + bullet.transform.rotation);
        GUILayout.Label("Position Camera:" + Camera.main.transform.position);
    //    GUILayout.Label("Position bullet:" + bullet.transform.position);
        GUILayout.Label("Attitude :" + Input.gyro.attitude);
    }

}
