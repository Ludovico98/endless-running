using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGeneration : MonoBehaviour
{
    [Header("Tools")]
    public float newTrackZ;
    public float newPickUpZ;

    [Header("Info")]
    public GameObject trackObj;
    public GameObject pitStopObj;

    float constantDistanceTrack = 498.7f;
    float constantDistancePickUp = 460.6f;


    public void Start()
    {
        newTrackZ = trackObj.transform.position.z;
        newPickUpZ = pitStopObj.transform.position.z;
    }

    public void PitStopNextPos()
    {
        newPickUpZ = newTrackZ + constantDistancePickUp;
        pitStopObj.transform.position = new Vector3(0, 0, newPickUpZ);   
    }

    public void TrackNextPos()
    {
        newTrackZ = newTrackZ + constantDistanceTrack;
        trackObj.transform.position = new Vector3(0, 0, newTrackZ );
        trackObj.SetActive(false);
        trackObj.SetActive(true);
        
    }

}
