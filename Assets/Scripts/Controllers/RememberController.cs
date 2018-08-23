using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RememberController : MonoBehaviour {

    private Remember remember;




    public void AddRemember(Remember remember) {this.remember = remember;}

    public Remember GetRemember() { return remember; }

}
