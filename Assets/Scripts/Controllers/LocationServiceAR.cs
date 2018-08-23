using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationServiceAR : MonoBehaviour {


    public static float originalLatitude;
    public static float originalLongitude;
    public static float originalAltitude;

    public static float currentLongitude;
    public static float currentLatitude;
    public static float currentAltitude;

    public static float MULTIPLEDISTANCE;
    public const int MAXWAIT = 30;
    public const float DESIDERACCURACYINMETERS = 5.0f;
    public const float UPDATEDISTANCEINMETERS = .1f;


    private static bool setOriginalValues = true;
    public Text coordinateInfo;


    void Start() {

        //start GetCoordinate() function 
        StartCoroutine("GetCoordinates");

    }


     IEnumerator GetCoordinates() {

        //while true so this function keeps running once started.
        while (true)
        {
            // check if user has location service enabled
            if (!Input.location.isEnabledByUser)
                yield break;

            // Start service before querying location
            Input.location.Start(DESIDERACCURACYINMETERS, UPDATEDISTANCEINMETERS);

            // Wait until service initializes
            int maxWait = MAXWAIT;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                yield return new WaitForSeconds(3);
                maxWait--;
            }
            // Service didn't initialize in 20 seconds
            if (maxWait < 1){
                print("Timed out");
                yield break;
            }
            // Connection has failed
            if (Input.location.status == LocationServiceStatus.Failed){
                print("Unable to determine device location");
                yield break;
            }
            else{

                // Access granted and location value could be retrieved
                coordinateInfo.text = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp;
                //print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);

                //if original value has not yet been set save coordinates of player on app start
                if (setOriginalValues)
                {
                    originalLatitude = Input.location.lastData.latitude;
                    originalLongitude = Input.location.lastData.longitude;
                    originalAltitude = Input.location.lastData.altitude;
                    setOriginalValues = false;
                }

                //overwrite current lat and lon everytime
                currentLatitude = Input.location.lastData.latitude;
                currentLongitude = Input.location.lastData.longitude;
                currentAltitude = Input.location.lastData.altitude;

            }
            Input.location.Stop();
        }
    }

    //calculates distance between two sets of coordinates, taking into account the curvature of the earth.
    public static float CalcDistance(float lat1, float lon1, float lat2, float lon2)
    {
        double distance;
        var R = 6378.137; // Radius of earth in KM
        var dLat = lat2 * Mathf.PI / 180 - lat1 * Mathf.PI / 180;
        var dLon = lon2 * Mathf.PI / 180 - lon1 * Mathf.PI / 180;
        float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
          Mathf.Cos(lat1 * Mathf.PI / 180) * Mathf.Cos(lat2 * Mathf.PI / 180) *
          Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);
        var c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        distance = R * c;
        distance = distance * 1000f; // meters

        //convert distance from double to float
        return (float) distance;
    }

}
