using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public GameObject playerObj;



    // Keeping track of score

    void Update()
    {
        if (playerObj.transform.position.z > 0)
        {
            scoreText.text = player.position.z.ToString("0");
        }

    }
}
