using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour {

    public Vector2 startWait;

    public float dodge;
    public float smoothing;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public Boundary boundary;
    public float tilt;

    private float currentSpeed;
    private float targetManuver;
    private Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        currentSpeed = rb.velocity.z;
        StartCoroutine(Evaid());	

	}

    IEnumerator Evaid()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));
        while (true)
        {
            targetManuver = Random.Range(1, dodge)* -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x,maneuverWait.y));
        }
    }

	// Update is called once per frame
	void FixedUpdate () {
        float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManuver, Time.deltaTime*smoothing);
        rb.velocity = new Vector3(newManeuver,0.0f, currentSpeed);
        rb.position = new Vector3
            (Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
