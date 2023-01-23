using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundData : MonoBehaviour
{
    Player player;
    public GameObject playerObject;

    public GameObject[] Road;

    public int CurrentIntex;
    public float CurrentPositionX;

    private void Start()
    {
        CurrentIntex = 2; // starting in the center
        player = playerObject.GetComponent<Player>();
        CurrentPositionX = Road[CurrentIntex].transform.position.x;
    }

    public void checkPosition() //change position of player based on Road array 
    {

        if (player.MoveLeft && CurrentIntex > 0) 
        {
            CurrentIntex = CurrentIntex - 1;
            CurrentPositionX = Road[CurrentIntex].transform.position.x;
            player.MoveLeft = false;
        }

        if (player.MoveRight && CurrentIntex < 4)
        {
            CurrentIntex = CurrentIntex + 1;
            CurrentPositionX = Road[CurrentIntex].transform.position.x;
            player.MoveRight = false;
        }
        
    }

}
