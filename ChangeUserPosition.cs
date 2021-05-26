using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleVR;

public class ChangeUserPosition : MonoBehaviour
{
    public GvrReticlePointer pointer;
    public RaycastHit hit;
    public GameObject player;
    BallLauncher bl;

    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
     
    }


    public void OnPointerClick() 
    {
        //Change the player's current position to the position they're pointing to
        player.transform.position = new Vector3(pointer.CurrentRaycastResult.worldPosition.x, 0.51f, pointer.CurrentRaycastResult.worldPosition.z);
    }
}
