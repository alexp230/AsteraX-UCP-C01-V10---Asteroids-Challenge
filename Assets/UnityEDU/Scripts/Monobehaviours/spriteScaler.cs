using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteScaler : MonoBehaviour {

    //Camera variable to store the Main camera 
    //(so we aren't calling Camera.main 
    //in every frame which does FindCOmponent every time
    
    Camera cam;

    //sprite transform to scale when we have the aspect ratio

    Transform sprite;
    
    // Use this for initialization
   
    float cachedOrtho;
	
    void Start () {

        cam = Camera.main;
        sprite = gameObject.GetComponent<Transform>();
        cachedOrtho = cam.orthographicSize;
        Debug.Log(cam.pixelRect);
        ScaleToScreenSize(gameObject);

    }
	
	// Update is called once per frame
	void Update () {
		if(cam.orthographic == false)
        {
            Debug.LogWarning("YOUR CAMERA ISNT SET TO ORTHOGRAPHIC");
            return;
        }
        
	}

    public void ScaleToScreenSize(GameObject s)
    {

            var sr = s.GetComponent<SpriteRenderer>() ;
            if (sr == null) return;

            transform.localScale = Vector3.one;

            var width = sr.sprite.bounds.size.x;
            var height = sr.sprite.bounds.size.y;

            float worldScreenHeight = cam.orthographicSize * 2.0f;
            //Debug.Log(cam.orthographicSize);
            float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
            //Debug.Log(Screen.height + " width is: " + Screen.width);
            //Debug.Log(cam.aspect);
             transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height, 1);
             
        

    }
}
