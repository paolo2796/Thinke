using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Remember {

    string code;
    LocationInfo latlng;
    int numthinke;
    string thinktag;
    string state;
    string typemedia;
    User userpublished;
    byte[] media;
    System.DateTime dateinsert;
 
    public Remember() {}

    public Remember(string code,LocationInfo latlng,int numthinke,string thinktag, string state, string typemedia, User userpublished, byte[] media, System.DateTime dateInsert) {
        this.code = code;
        this.latlng = latlng;
        this.numthinke = numthinke;
        this.thinktag = thinktag;
        this.state = state;
        this.typemedia = typemedia;
        this.userpublished = userpublished;
        this.dateinsert = dateInsert;
    }




    public void SetCode(string code) { this.code = code; }
    public string GetCode() { return code; }


    public void SetLatLng(LocationInfo latlng) { this.latlng = latlng; }
    public LocationInfo GetLatLng() { return latlng; }


    public void SetNumThinke(int numthinke) { this.numthinke = numthinke; }
    public int GetNumThinke() { return numthinke; }


    public void SetThinkTag(string thinktag) { this.thinktag = thinktag; }
    public string GetThinkTag() { return thinktag; }


    public void SetState(string state) { this.state = state; }
    public string GetState() { return state; }


    public void SetTypeMedia(string typemedia) { this.typemedia = typemedia; }
    public string GetTypeMedia() { return typemedia; }



    public void SetUserPublished(User userpulished) { this.userpublished = userpulished; }
    public User GetUserPublished() { return this.userpublished; }


    public void SetMedia(byte[] media) { this.media = media; }
    public byte[] GetMedia() { return this.media; }


    public void SetDateInsert(System.DateTime dateInsert) { this.dateinsert = dateInsert; }
    public System.DateTime GetDateInsert() { return dateinsert; }


    public Dictionary<string, System.Object> ToDictionary(){

        System.DateTime baseDate = new System.DateTime(1970, 01, 01);
        Dictionary<string, System.Object> result = new Dictionary<string, System.Object>();
        result.Add("numthinke", numthinke);
        result.Add("latitude", latlng.latitude);
        result.Add("longitude", latlng.longitude);
        result.Add("thinktag", thinktag);
        result.Add("state", state);
        result.Add("typemedia", typemedia);
        result.Add("dateinsert", dateinsert.Subtract(baseDate).TotalSeconds);
        result.Add("userpublished", userpublished.GetUsername());
        return result;
    }

}
