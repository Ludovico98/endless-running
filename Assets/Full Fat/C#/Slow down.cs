using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    public Component GenerateTrack;
    public Player player;
    public bool pitStop;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pitStop = true;
            while (pitStop== true)
            {
                player.rb.AddForce(0, 0, 50);
            }
            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pitStop = false; 
        }
    }
}
