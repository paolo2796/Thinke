using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TakePictureController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {


    // CONST
    private const int IMG_MAXSIZE = 20024;

    [SerializeField]
    private Image fillimage;
    private bool pointerDown;
    private float pointerDownTimer;
    public float requiredHoldTime;
    private Vector3 scaleInit;
    public Texture2D textureImage;



    private GameObject pictureGO;

    //Reference UI
    public GameObject confirmSavePhotoBtn;
    public GameObject confirmCancelPhotoBtn;




    void Start() {

        fillimage = GetComponent<Image>();
        scaleInit = this.transform.localScale;

        Input.location.Start();

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData) { }

    public void Update() {



        if (pointerDown) {

            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer > requiredHoldTime) {
                Reset();

                if (string.Equals(this.gameObject.name, "ButtonTakePhoto"))
                    LoadImageInsidePicture();
                else if (string.Equals(this.gameObject.name, "ButtonTakeVideo"))
                    LoadVideoInsidePicture();

                else { }

            }

            fillimage.fillAmount -= pointerDownTimer / requiredHoldTime;
        }

    }


    private void Reset() {

        pointerDown = false;
        pointerDownTimer = 0;
        fillimage.fillAmount = (float)1.0;
    }


    //Carica Texture all'interno del Prefab PictureImage utilizzato come quadro
    private void LoadImageInsidePicture() {

        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>{
            Debug.Log("Image path: " + path);
            if (path != null){
                // Create Texture from selected image
                Texture2D texture = NativeGallery.LoadImageAtPath(path, IMG_MAXSIZE);               

                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }


                foreach (GameObject element in GameObject.FindGameObjectsWithTag("TakePictureBtn")){
                    element.SetActive(false);
                }


                EnableButtonPhoto();

                pictureGO = Instantiate(Resources.Load<GameObject>("Prefabs/Picture/PictureImage"));
                pictureGO.GetComponent<PictureController>().SetMediaPath(path);
                Util.ResizeScalePictureToPoint(pictureGO, texture);
                pictureGO.GetComponent<Renderer>().material.mainTexture = (Texture)texture;
                confirmSavePhotoBtn.GetComponent<SavePhotoController>().setPicture(pictureGO);
                confirmCancelPhotoBtn.GetComponent<SavePhotoController>().setPicture(pictureGO);

            }

        }, "Select a  image", "image/*", IMG_MAXSIZE);
        Debug.Log("Permission result: " + permission);
    }


    public void LoadVideoInsidePicture() {
        NativeGallery.Permission permission = NativeGallery.GetVideoFromGallery((path) =>
        {
            Debug.Log("Video path: " + path);
            if (path != null) {
                foreach (GameObject element in GameObject.FindGameObjectsWithTag("TakePictureBtn"))
                {
                    element.SetActive(false);
                }

                NativeGallery.VideoProperties videoProperties = NativeGallery.GetVideoProperties(path);
                GameObject pictureVideo = Instantiate(Resources.Load<GameObject>("Prefabs/Picture/PictureVideo"));
                StreamVideo streamScript = pictureVideo.GetComponent<StreamVideo>();
                pictureVideo.GetComponent<PictureController>().SetMediaPath(path);

                if (videoProperties.rotation == 180 || videoProperties.rotation == 0){
                    streamScript.SetRotationVideo(videoProperties.rotation);

                }
                else {
                    streamScript.SetRotationVideo(videoProperties.rotation - 180);
                }
                streamScript.SetPath(path);
                streamScript.LoadVideoInsidePicture();

                EnableButtonPhoto();

                confirmSavePhotoBtn.GetComponent<SavePhotoController>().setPicture(pictureVideo);
                confirmCancelPhotoBtn.GetComponent<SavePhotoController>().setPicture(pictureVideo);


            }

        }, "Select a video");
        Debug.Log("Permission result: " + permission);
    }

    public void EnableButtonPhoto() {

        confirmSavePhotoBtn.SetActive(true);
        confirmCancelPhotoBtn.SetActive(true);
    }

}
 