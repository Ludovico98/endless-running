using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitStop : MonoBehaviour
{

    //public Component GenerateTrack;
    public Player player;
    public Randomization random;
    public bool pitStop;
    public int newSpeed;
    


    private void Awake()
    {
        newSpeed = player.MaxSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        newSpeed = player.MaxSpeed + 500;
        pitStop = true;
        random.used = false;
        if (pitStop && other.tag == "Player")
        {
            player.MaxSpeed = 500;
        }

    }

    private void OnTriggerExit(Collider other)
    {

        pitStop = false;
        if (!pitStop)
        {
            player.IncreaseSpeed = player.IncreaseSpeed + 2;
            player.MaxSpeed = newSpeed ;
        }
    }
}
