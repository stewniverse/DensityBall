using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePointer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Response - Pointer enter the Cube
    
    public void PointerEnter()
    {
        //change the color of the cube to blue
        GetComponent<Renderer>().material.color = Color.blue;
      }

    //Repsonse - Pointer exit the Cube
    public void PointerExit()
    {
        //reset the color of the cube to white
        GetComponent<Renderer>().material.color = Color.white;
    }

    //Response - Destroy the cube on click
    public void PointerClick()
    {
        //Destroy this object if the pointer clicks on it
        Destroy(gameObject);
    }
}
