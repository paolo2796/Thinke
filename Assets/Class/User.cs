using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class User {

    string email;
    string password;
    int numcredits;
    string username;
    string name;
    string surname;
    int numphotopublic;
    int numphotocatch;
    System.DateTime datebirth;
    string profession;
    string sex;
    byte[] img_profile;


    public User() {
    }

    public User(string email, string password, int numcredits, string username, string name, string surname, int numphotopublic, int numphotocatch, System.DateTime datebirth, string profession, string sex, byte[] img_profile) {

        this.email = email;
        this.password = password;
        this.numcredits = numcredits;
        this.username = username;
        this.name = name;
        this.surname = surname;
        this.numphotopublic = numphotopublic;
        this.numphotocatch = numphotocatch;
        this.datebirth = datebirth;
        this.profession = profession;
        this.sex = sex;
        this.img_profile = img_profile;
    }

    public void SetEmail(string email) { this.email = email; }
    public string GetEmail() { return this.email; }



    public void SetPassword(string password) { this.password = password; }
    public string GetPassword() { return this.password; }

    public void SetNumCredits(int numcredits) { this.numcredits = numcredits; }
    public int GetNumCredits() { return this.numcredits; }


    public void SetUsername(string username) { this.username = username; }
    public string GetUsername() { return this.username; }

    public void SetName(string name) { this.name = name; }
    public string GetName() { return this.name; }


    public void SetSurname(string surname) { this.surname = surname; }
    public string GetSurname() { return this.surname; }

    public void SetNumPhotoPublic(int numphotopublic) { this.numphotopublic = numphotopublic; }
    public int GetNumPhotoPublic() { return this.numphotopublic; }

    public void SetNumPhotoCatch(int numphotocatch) { this.numphotocatch = numphotocatch; }
    public int GetNumPhotoCatch() { return this.numphotocatch; }

    
    public void SetDateBirth(System.DateTime datebirth) { this.datebirth = datebirth; }
    public System.DateTime GetDateBirth() { return this.datebirth; }



    public void SetProfession(string profession) { this.profession = profession; }
    public string GetProfession() { return this.profession; }


    public void SetSex(string sex) { this.sex = sex; }
    public string GetSex() { return this.sex; }



    public void SetImgProfile(byte[] img_profile) { this.img_profile = img_profile; }
    public byte[] GetImgProfile() { return this.img_profile; }

}
