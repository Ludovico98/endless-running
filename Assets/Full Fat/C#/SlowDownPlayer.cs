using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownPlayer : MonoBehaviour
{
    public Player player;


    private void OnTriggerEnter(Collider other)
    {
        player.ForwardForce = player.ForwardForce/1.5f;

        this.gameObject.SetActive(false);
    }

}
