using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 posi = gameObject.GetComponent<Transform>().position;
        //Vector3 newposi = new Vector3(posi.x + 1, posi.y, posi.z);
        gameObject.GetComponent<Transform>().position= new Vector3(posi.x, posi.y, posi.z+0.1f);
    }
}
