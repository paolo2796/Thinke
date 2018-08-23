using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RememberCatched : Remember {

    System.DateTime datecatch;

    public RememberCatched() : base() { }

    public RememberCatched(System.DateTime datecatch, string code, LocationInfo latlng, int numthinke, string thinktag, string state, string typemedia, User userpublished, byte[] media, System.DateTime dateinsert) : base(code, latlng,numthinke,thinktag,state,typemedia,userpublished,media,dateinsert)
    {

        this.datecatch = datecatch;
    }

}
