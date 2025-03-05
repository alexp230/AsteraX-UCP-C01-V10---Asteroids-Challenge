using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPoint : MonoBehaviour {

    //get the transform of the turret to rotate it. 
    Transform t;


	// Use this for initialization
	void Start () {

        t = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        LookAtMouseCursor();
       	}

    public void LookAtMouseCursor()
    {
        Vector3 MouseInWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MouseInWorldSpace.z += 9f;
        transform.LookAt(MouseInWorldSpace, Vector3.back);
    }
}
