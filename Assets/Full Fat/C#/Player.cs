using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // might be usefull FindObjectOfType<GameManager>().EndGame();

    public Rigidbody rb;
    GroundData groundData;

    [Header("Movement")]
    public float ForwardForce;
    public float IncreaseSpeed;
    public int MaxSpeed;

    float X1;
    float X2;

    public bool MoveRight;
    public bool MoveLeft;

    [Header("Track")]
    public int CurrentTrack;
    public GameObject groundObject;

    public void Awake()
    {
        groundData = groundObject.GetComponent<GroundData>();
    }

    private void FixedUpdate()
    {
        CurrentTrack = groundData.CurrentIntex;
    }

    public void Update()
    {
        if (ForwardForce < MaxSpeed )
        {
            ForwardForce = ForwardForce + IncreaseSpeed;
        }
        else
        {
            ForwardForce = MaxSpeed;
        }

        rb.AddForce(0, 0, ForwardForce * Time.deltaTime); //Constant forward force

        if (Input.GetMouseButtonDown(0)) // check for left and right swipe 
        {
            X1 = Input.mousePosition.x;
        }
        if (Input.GetMouseButtonUp(0))
        {
            X2 = Input.mousePosition.x;
            if (X1 < X2) //move left
            {
                MoveLeft = true;
                groundData.checkPosition();
                rb.transform.position = new Vector3(groundData.CurrentPositionX, transform.position.y, transform.position.z);
            }

            if (X1 > X2) //move right
            {
                MoveRight = true;
                groundData.checkPosition();
                rb.transform.position = new Vector3(groundData.CurrentPositionX, transform.position.y, transform.position.z);
            }
        }
        MoveLeft = false;
        MoveRight = false;
    }
}
