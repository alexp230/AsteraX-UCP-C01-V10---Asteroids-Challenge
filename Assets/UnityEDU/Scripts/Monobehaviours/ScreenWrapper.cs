using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour {

    //the transform of the game object we want to manipulate 
    //(preferably the one this script is attached to)
    Transform t;
    // Use this for initialization

    [SerializeField]GameObject screenBounds;

    Camera cam;
   
	void Start () {

        t = gameObject.GetComponent<Transform>();
        screenBounds = GameObject.FindGameObjectWithTag("ScreenBoundaries");
        cam = Camera.main;

	}
	
    void OnTriggerExit(Collider col)
    {
        ScreenWrap();
    }

    public void ScreenWrap()
    {
        var viewportPosition = cam.WorldToViewportPoint(t.position);
        //Debug.Log("viewPortPosition" + viewportPosition) ;
        var newPosition = t.position;

        if (viewportPosition.x > 1 || viewportPosition.x < 0)
        {
            newPosition.x = -newPosition.x;
        }

        if (viewportPosition.y > 1 || viewportPosition.y < 0)
        {
            newPosition.y = -newPosition.y;
        }

        transform.position = newPosition;
    }


}
