using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StreamVideo : MonoBehaviour {

    public RawImage image;


    public string path;
    private VideoPlayer videoPlayer;
    private AudioSource audioSource;

    private float rotation;

    public void LoadVideoInsidePicture() {
        Application.runInBackground = true;
        StartCoroutine(PlayVideo());

    }
    IEnumerator PlayVideo()
    {

            // VideoPlayer automatically targets the camera backplane when it is added
            // to a camera object, no need to change videoPlayer.targetCamera.
            videoPlayer = this.gameObject.AddComponent<UnityEngine.Video.VideoPlayer>();
            audioSource = this.gameObject.AddComponent<AudioSource>();

            // Play on awake defaults to true. Set it to false to avoid the url set
            // below to auto-start playback since we're in Start().
            videoPlayer.playOnAwake = false;
            audioSource.playOnAwake = false;


            // This will cause our scene to be visible through the video being played.
            videoPlayer.targetCameraAlpha = 0.5F;


            videoPlayer.transform.eulerAngles = new Vector3(0, 0, rotation);


        // Set the video to play. URL supports local absolute or relative paths.
        // Here, using absolute.

            videoPlayer.source = VideoSource.Url;
            videoPlayer.url = "file://" + path;
            videoPlayer.controlledAudioTrackCount = 1;

            videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
            videoPlayer.EnableAudioTrack(0, true);
            videoPlayer.SetTargetAudioSource(0, audioSource);

            // Skip the first 100 frames.
            videoPlayer.frame = 100;

     

            // Restart from beginning when done.
            videoPlayer.isLooping = true;
            videoPlayer.Prepare();


            //Wait until video is prepared
        while (!videoPlayer.isPrepared)
            {
                yield return null;
            }

            Debug.Log("Done Preparing Video");

            //Assign the Texture from Video to RawImage to be displayed
            image.texture = videoPlayer.texture;

            //Play Video
            videoPlayer.Play();
            audioSource.Play();

      /*      while (videoPlayer.isPlaying)
            {
                Debug.LogWarning("Video Time: " + Mathf.FloorToInt((float)videoPlayer.time));
                yield return null;
            }
            */
    }
    public void SetPath(string path) { this.path = path; }
    public string GetPath() { return path; }

    public void SetRotationVideo(float rotation) {
        this.rotation = rotation;
    }

}
