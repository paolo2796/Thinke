using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PictureController : MonoBehaviour {


    private Remember remember;
    private string path;

    //Firebase
    private const string REMEMBERSURLFIREBASE = "https://thinke-8f2d4.firebaseio.com/Remembers";

    private const string PICTUREIMAGE = "PictureImage";
    private const string IMAGE = "Image";
    private const string VIDEO = "Video";



    //Firebase
    private FirebaseDatabase fireDatabase;
    private DatabaseReference dataReference;

    public void Start(){

        fireDatabase = FirebaseDatabase.DefaultInstance;
        dataReference = fireDatabase.GetReferenceFromUrl(REMEMBERSURLFIREBASE);
    }

    public Remember GenerateRemember() {

        remember = new Remember();
        remember.SetLatLng(Input.location.lastData);
        remember.SetNumThinke(0);
        remember.SetThinkTag(null);
        remember.SetState("Free");

        if (string.Equals(this.gameObject.name, PICTUREIMAGE))
            remember.SetTypeMedia(IMAGE);
        else
            remember.SetTypeMedia(VIDEO);

        System.DateTime dateBirth = new System.DateTime();
        dateBirth.AddYears(1996);
        dateBirth.AddMonths(01);
        dateBirth.AddDays(27);
        remember.SetMedia(File.ReadAllBytes(path));


        remember.SetUserPublished(new User("paolovigorito96@gmail.com", "paolo", 0, "xedodu", "Paolo", "Vigorito", 0, 0, dateBirth, "Student", "Female", remember.GetMedia()));
        remember.SetDateInsert(System.DateTime.Now.ToUniversalTime());


        return remember; 
    }


    public void saveRemember(Remember remember) {


        //Save Data Remember
        Dictionary<string, System.Object> entry = remember.ToDictionary();

        string rememberCode = dataReference.Push().Key;
        remember.SetCode(rememberCode);
        dataReference.Child(rememberCode).SetValueAsync(entry).ContinueWith((task) =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Data saved successfully!");

            }
            else
            {

            };


        }); ;


        //Save Media Data Remember
        GameObject mainCameraUI = GameObject.Find(Util.ARCamera);
        GameObject buttonLoading = mainCameraUI.GetComponent<UIController>().buttonLoading;


        mainCameraUI.GetComponent<UIController>().buttonCancelMedia.SetActive(false);
        mainCameraUI.GetComponent<UIController>().buttonSaveMedia.SetActive(false);

        buttonLoading.SetActive(true);
        // Create a reference to the file you want to upload
        Firebase.Storage.FirebaseStorage storage = Firebase.Storage.FirebaseStorage.DefaultInstance;
        Firebase.Storage.StorageReference storage_ref = storage.GetReferenceFromUrl(FirebaseUtil.ROOTNODE_STORAGE);
        Firebase.Storage.StorageReference rivers_ref = storage_ref.Child(remember.GetCode() + ".jpeg");
        rivers_ref.PutBytesAsync(remember.GetMedia(), null, new Firebase.Storage.StorageProgress<Firebase.Storage.UploadState>(state =>
        {
            Debug.Log(string.Format("Progress: {0} of {1} bytes transferred.", state.BytesTransferred, state.TotalByteCount));
            decimal bytesTrasferred = System.Convert.ToDecimal(state.BytesTransferred);
            decimal totalByteCount = System.Convert.ToDecimal(state.TotalByteCount);
            decimal progress= ((bytesTrasferred / totalByteCount) * 100);
            decimal progressLoadingUI  = (progress / 100);

            buttonLoading.GetComponent<LoadingController>().progressFillImage(progressLoadingUI);

        }), System.Threading.CancellationToken.None, null).ContinueWith(task =>
        {
            Debug.Log(string.Format("OnClickUpload::IsCompleted:{0} IsCanceled:{1} IsFaulted:{2}", task.IsCompleted, task.IsCanceled, task.IsFaulted));
            if (task.IsFaulted || task.IsCanceled){
                Debug.Log(task.Exception.ToString());
                // Uh-oh, an error occurred!
            }

            else{

                // Metadata contains file metadata such as size, content-type, and download URL.
                Firebase.Storage.StorageMetadata metadata = task.Result;
                GameObject buttonTimer = mainCameraUI.GetComponent<UIController>().buttonTimer;
                buttonTimer.gameObject.SetActive(true);


                if (remember.GetTypeMedia().Equals("Image"))
                {
                    GameObject rememberGO = Instantiate(Resources.Load<GameObject>("Prefabs/Remember/RememberPhoto"));
                    rememberGO.GetComponent<RememberPhotoController>().AddRemember(remember);
                    rememberGO.GetComponent<RememberPhotoController>().UpdateTexture();
                }
                else {
                    GameObject rememberGO = Instantiate(Resources.Load<GameObject>("Prefabs/Remember/RememberVideo"));
                    rememberGO.GetComponent<RememberVideoController>().AddRemember(remember);
                    rememberGO.GetComponent<RememberVideoController>().UpdateTexture();
                }
                Debug.Log("Finished uploading...");

                Destroy(this.gameObject);
            }
        });


    }

    public void SetMediaPath(string path) {
        this.path = path;
    }

} 
