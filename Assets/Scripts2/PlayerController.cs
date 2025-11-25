using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float forwardInput;
    public float horizontalInput;

    public GameObject tutorial;
    public Tutorial tutorialScript;

    void Start()
    {
        tutorialScript = tutorial.GetComponent<Tutorial>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialScript.finished == true)
        {
            forwardInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");

            //Move Forward with forward input
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
        }
    }
}