using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomization : MonoBehaviour
{
    public bool used = false;
    public PitStop pitStop;

    [Header("Objects")]
    public GameObject ObsticleCube;
    public GameObject PickUp;
    Vector3 DeactivatedPlace;

    [Header("Parent")]
    public GameObject ParentTracks;

    [Header("Ground")]
    public GameObject LeftObj;
    public GameObject CentreLeftObj;
    public GameObject CentreObj;
    public GameObject CentreRightObj;
    public GameObject RightObj;

    [Header("Obsticle")]
    public int DistanceIncrementsOf5;
    public int OffTagQuantity;
    public int QuantityPickUp;

    public List<GameObject> ObjCollection = new List<GameObject>();
    public List<GameObject> OffTags = new List<GameObject>();


    public void Start()
    {
        

        // tracks positions
        float LeftX = LeftObj.transform.position.x;
        float CentreLeftX = CentreLeftObj.transform.position.x;
        float CentreX = CentreObj.transform.position.x;
        float CentreRightX = CentreRightObj.transform.position.x;
        float RightX = RightObj.transform.position.x;
   
        for (int i = 1; i <= DistanceIncrementsOf5; i += 5) // multiple of 5, distance on track and place obsticle
        {
            Instantiate(ObsticleCube, new Vector3(LeftX, 1, i + LeftObj.transform.position.z), Quaternion.identity);
            Instantiate(ObsticleCube, new Vector3(CentreLeftX, 1, i + CentreLeftObj.transform.position.z), Quaternion.identity);
            Instantiate(ObsticleCube, new Vector3(CentreX, 1, i + CentreObj.transform.position.z), Quaternion.identity);
            Instantiate(ObsticleCube, new Vector3(CentreRightX, 1, i + CentreRightObj.transform.position.z), Quaternion.identity);
            Instantiate(ObsticleCube, new Vector3(RightX, 1, i + (RightObj.transform.position.z)), Quaternion.identity);
        }

        foreach (var ObsticleCube in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            ObjCollection.Add(ObsticleCube);
            ObsticleCube.transform.parent = ParentTracks.transform; // set the position of the instanciated obsticles to the track
        }

        DeactivateObsticles();

        if (pitStop.pitStop == true && used == false)
        {
            Debug.Log("I HAVE BEEN ACTIVATED");
            used = true;
            DeactivateObsticles();
        }

    }

    public void DeactivateObsticles()
    {
        var randomList = GetRandomElements(ObjCollection, OffTagQuantity); // place random position for pick up GameObjects 

        foreach (GameObject item in randomList)
        {
           
            item.gameObject.tag = "Off";
            OffTags.Add(item.gameObject);
            item.gameObject.SetActive(false);
            

            if (pitStop.pitStop == true)
            {
                OffTagQuantity = OffTagQuantity - 10;
                var TurnOnList = GetRandomElements(ObjCollection, OffTagQuantity);
                foreach ( var newItem in TurnOnList)
                {
                    item.gameObject.tag = "Off";
                    OffTags.Add(item.gameObject);
                    item.gameObject.SetActive(false);
                }


            }
            
        }
        PlacePickUpObj();
        
    }

    public void PlacePickUpObj()
    {

        var randomPickUpList = GetRandomElements(OffTags, QuantityPickUp);

        foreach (GameObject Deactivated in randomPickUpList ) // find deactivated obsticles and place pick up
        {
            Instantiate(PickUp, new Vector3(DeactivatedPlace.x, DeactivatedPlace.y, DeactivatedPlace.z), Quaternion.identity);
            DeactivatedPlace = Deactivated.transform.position;
            PickUp.transform.position = new Vector3(DeactivatedPlace.x, DeactivatedPlace.y, DeactivatedPlace.z);
            randomPickUpList[1].SetActive(false);
        }

        foreach (var PickUpClone in GameObject.FindGameObjectsWithTag("PickUp"))
        {
            PickUpClone.transform.parent = ParentTracks.transform;
        }

    }
    
    List<T> GetRandomElements<T>(List<T> InputList, int count)
    {
        List<T> container = new List<T>();

        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, InputList.Count);

            if (!container.Contains(InputList[index]))
            {
                container.Add(InputList[index]);
            }
            
        }

        return container;
    }

}

/*
     * 
     * attempt to generate another randomization at run time

    private void Update()
    {
        if (isActive.DestroyActive)
        {
            foreach (var item in GameObject.FindGameObjectsWithTag("Obstacle"))
            {
                Destroy(item);
            }
        }
        
    }
    */

