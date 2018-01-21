using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate2 : MonoBehaviour {

    Quaternion originrotation;
    float angel;
    // Use this for initialization
    void Start()
    {

        originrotation = transform.rotation;

        float red = Random.Range(0.0f, 1.0f);
        float green = Random.Range(0.0f, 1.0f);
        float blue = Random.Range(0.0f, 1.0f);


        gameObject.GetComponent<Renderer>().material.color = new Color(red, green, blue);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        angel++;


        //Quaternion rotationY = Quaternion.AngleAxis(angel, /*Vector3.up*/ new Vector3(0, 1, 0));
        Quaternion rotationX = Quaternion.AngleAxis(angel, Vector3.up);
        transform.rotation = originrotation //* rotationY 
            * rotationX;
    }
}
