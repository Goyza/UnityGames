using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    private int count;
    public Text CountText;
    public Text WinText;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        WinText.text = "";
        SetFunctionText();
    }

    private void SetFunctionText()
    {
        CountText.text = "Count:" + count.ToString();
        if (count>=9)
        {
            WinText.text = "Victory!";
        }
    }

    private void FixedUpdate()
    {
        float moveHorisontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorisontal, 0.0f, moveVertical);

        rb.AddForce(movement*speed);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetFunctionText();
        }
    }

}
