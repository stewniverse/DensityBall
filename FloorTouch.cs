using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTouch : MonoBehaviour
{
    private const string V = " is working";
    public GameObject floor;
    public BallLauncher launch;
    
    bool touchedFloor = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        hasTouchedFloor();
    }

    //Turns off physics when the ball touches the floor
    void hasTouchedFloor()
    {
        Debug.Log(name + V);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == floor)
        {
            hasTouchedFloor();
        }
    }
    //Response - Pointer enter the Sphere
    public void PointerEnter()
    {
        //change the color of the cube to Sphere
        GetComponent<Renderer>().material.color = Color.red;
    }

    //Repsonse - Pointer exit the Sphere
    public void PointerExit() =>
        //reset the color of the cube to Sphere
        GetComponent<Renderer>().material.color = Color.red;


    public void PointerClick() => launch.SetBall(GetComponent<Rigidbody>());


}
