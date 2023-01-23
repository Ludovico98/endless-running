using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitStopInFrame : MonoBehaviour
{
    bool readyToGo;
    public TrackGeneration trackGeneration;

    public void OnBecameInvisible()
    {
        Debug.Log("Bye Bye");
        trackGeneration.PitStopNextPos();
        readyToGo = true;
    }

    public void OnBecameVisible()
    {
        if (readyToGo)
        {
            waitForShipToLeave();
        }
        
    }

    public IEnumerator waitForShipToLeave()
    {
        readyToGo = false;
        trackGeneration.PitStopNextPos();
        yield return new WaitForSeconds(2);
    }

}
