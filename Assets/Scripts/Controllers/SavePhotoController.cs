using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SavePhotoController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{


    //Const
    private const float RESIZELOCALSCALE = 0.08f;




    private float pointerDownTimer = 0f;
    public float requiredHoldTime;
    private Vector3 localScaleOrigin;
    private GameObject picture;
    private Texture2D texturePicture;


    //GameOjbect Reference
    public GameObject takePhotoPicture;
    public GameObject takeVideoPicture;
    public GameObject savePhotoController;
    public GameObject cancelPhotoController;


    // Use this for initialization
    void Start()
    {

        localScaleOrigin = transform.localScale;

    }

    public void OnPointerDown(PointerEventData eventData)
    {

        pointerDownTimer += Time.deltaTime;
        if (pointerDownTimer <= requiredHoldTime) {
            this.transform.localScale = new Vector3(transform.localScale.x - RESIZELOCALSCALE, transform.localScale.y - RESIZELOCALSCALE, transform.localScale.z - RESIZELOCALSCALE);

        }//END IF REQUIREDHOLDTIME
    }

    public void OnPointerUp(PointerEventData eventData) {
        Reset();
        if (eventData.pointerEnter.transform.parent.CompareTag("ButtonConfirmSavePhoto")) {

            Remember remember = picture.GetComponent<PictureController>().GenerateRemember();
            picture.GetComponent<PictureController>().saveRemember(remember);
            

        }

        else if (eventData.pointerEnter.transform.parent.CompareTag("ButtonCancelSavePhoto")) {

            if (picture != null) {
                Destroy(picture);
                takePhotoPicture.SetActive(true);
                takeVideoPicture.SetActive(true);
                savePhotoController.SetActive(false);
                cancelPhotoController.SetActive(false);

            }

        }

    }

    public void Reset() {
        transform.localScale = localScaleOrigin;
        pointerDownTimer = 0;


    }


    public void setPicture(GameObject picture)
    {

        this.picture = picture;
    }









}
