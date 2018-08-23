using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {

    private bool startTimer;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {



        float timer = 600;
        float timerCurrent = Time.time;        
        if ((timer - timerCurrent) <= 0) {
            this.gameObject.SetActive(false);
            return;
        }
        this.GetComponentInChildren<Text>().text= (Util.FormatterTimerToString(timer - timerCurrent));
	}
}
