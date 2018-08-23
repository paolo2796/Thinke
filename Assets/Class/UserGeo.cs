using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserGeo : User {

    private LocationInfo latlng;

    public UserGeo() {}

    public UserGeo(LocationInfo latlng, string email, string password, int numcredits, string username, string name, string surname, int numphotopublic, int numphotocatch, System.DateTime datebirth, string profession, string sex, byte[] img_profile) : base(email,password,numcredits,username,name,surname, numphotopublic,numphotocatch,datebirth,profession,sex,img_profile){

        this.latlng = latlng;
    }


    public void SetLatLng(LocationInfo latlng) { this.latlng = latlng; }
    public LocationInfo GetLatLng() { return latlng; }

}
