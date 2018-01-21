using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cliker : MonoBehaviour, IPointerClickHandler {
    public void OnPointerClick(PointerEventData eventData)
    {
        float red = Random.Range(0.0f, 1.0f);
        float green = Random.Range(0.0f, 1.0f);
        float blue = Random.Range(0.0f, 1.0f);


        gameObject.GetComponent<Renderer>().material.color = new Color(red, green, blue);

        
        Vector3 pointB = Camera.main.transform.position;
        Vector3 pointA = eventData.pointerPressRaycast.worldPosition;
        Vector3 direction = pointA - pointB;
        direction = direction.normalized;
        Vector3 force = direction * 300;

        Vector3 place = eventData.pointerPressRaycast.worldPosition;

        gameObject.GetComponent<Rigidbody>().AddForceAtPosition(force, place);

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
