using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tagged_User {


    Remember remember;
    User user;


    public Tagged_User() { }

    public Tagged_User(Remember remember, User user) {
        this.remember = remember;
        this.user = user;
    }

    public void SetRemember(Remember remember) { this.remember = remember; }
    public Remember GetRemember() { return this.remember; }

    public void SetUser(User user) { this.user = user; }
    public User GetUser() { return this.user; }
}
