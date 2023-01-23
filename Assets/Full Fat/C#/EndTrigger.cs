using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody PlayerRb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameManager.Win();
            PlayerRb.constraints = RigidbodyConstraints.FreezePosition;
        }
        
    }
}
