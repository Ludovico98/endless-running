using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInFrame : MonoBehaviour
{
    public TrackGeneration trackGeneration;
    public bool DestroyActive;


    public void OnBecameVisible()
    {
        //Debug.Log("You can see me");
        //trackGeneration.TrackNextPos();


    }

    public void OnBecameInvisible()
    {
        trackGeneration.TrackNextPos();
        DestroyActive = true;
    }

    
}
