using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundaries : MonoBehaviour {

    //Get the main camera
    Camera cachedCamera;

    //Screenbounds as a Vector3
    Vector3 ScreenBoundaryCalc;

    //set a singleton
    private static ScreenBoundaries bounds;

    //write a way to access that singleton

    Vector3 ScreenBounds;

    public Vector3 SCREENBOUNDS
    { get { return ScreenBounds; } }
    public static ScreenBoundaries BOUNDS
    {
        get { return bounds; }         
    }

    //get the calculatedScreenBounds of the object so we can find a random spot. 

    Vector3 CalculatedBounds;

	// Use this for initialization
	void Start () {
        //set bounds if it is nt already set
		if(bounds == null)
            bounds = this;

        cachedCamera = Camera.main;
        CalculateScreenBoundaries();
        //Debug.Log(CalculatedBounds);
	}
	
	// Update is called once per frame
	void Update () {
       // Debug.Log(cachedCamera.orthographicSize);
	}

    public void CalculateScreenBoundaries()
    {
        float boundsX = cachedCamera.aspect * cachedCamera.orthographicSize;
        float boundsY = cachedCamera.orthographicSize;
        float boundsZ = cachedCamera.transform.position.z - cachedCamera.transform.position.z;

        CalculatedBounds = new Vector3(boundsX, boundsY, 1);
        Debug.Log("Screen boundaries are x: " + boundsX + " and Y: " + boundsY);

        transform.localScale = new Vector3(boundsX*2.0f, boundsY * 2.0f, 1);
    }

    


}
