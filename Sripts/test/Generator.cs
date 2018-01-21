using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Generator : MonoBehaviour
{
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MeshRenderer PlaceRenderer = gameObject.GetComponent<MeshRenderer>();
        float minX = PlaceRenderer.bounds.min.x;
        float minZ = PlaceRenderer.bounds.min.z;
        float maxX = PlaceRenderer.bounds.max.x;
        float maxZ = PlaceRenderer.bounds.max.z;

        float newX = Random.Range(minX, maxX);
        float newZ = Random.Range(minZ, maxZ);
        float newY = gameObject.transform.position.y + 5;

        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obj.transform.position = new Vector3(newX, newY, newZ);
            obj.AddComponent<Rigidbody>();
            float red = Random.Range(0.0f,1.0f);
            float green = Random.Range(0.0f, 1.0f);
            float blue = Random.Range(0.0f, 1.0f);


            obj.GetComponent<Renderer>().material.color= new Color (red,green,blue) ;

        }


        
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(300, collision.contacts[0].point,100);
    }*/
}
