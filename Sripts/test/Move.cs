using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Quaternion originrotation;
    float angelhor;
    float angelver;
    float mouseSence = 5;
    float stop = 8;
    // Use this for initialization
    void Start()
    {

        originrotation = transform.rotation;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        angelhor+= Input.GetAxis("Mouse X") * mouseSence;
        angelver += Input.GetAxis("Mouse Y") * mouseSence;
        angelver = Mathf.Clamp(angelver, -60, 60);

        Quaternion rotationY = Quaternion.AngleAxis(angelhor, Vector3.up);
        Quaternion rotationX = Quaternion.AngleAxis(-angelver, Vector3.right);
        transform.rotation = originrotation * rotationY * rotationX;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward / stop;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.forward / stop;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right / stop;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= transform.right / stop;
        }
    }
}
