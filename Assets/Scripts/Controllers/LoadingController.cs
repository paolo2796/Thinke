using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour {


    private const string COMMENTAFTERPROGRESS = "%";
    public Text textLoad;



    public void Update(){


        if (textLoad.text.Equals("100%")) {
            this.gameObject.SetActive(false);
        }
        
    }

    public void progressFillImage(decimal percentProgress) {
        this.GetComponent<Image>().fillAmount = (float) percentProgress;
        textLoad.text = (percentProgress * 100) + COMMENTAFTERPROGRESS;
    }

}
