using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController2D : MonoBehaviour
{
    float minSpeed = 0;
    float maxSpeed = 60;
    float acceleration = 5;
    float deacceleration = 8;
    float nudgeSpeed = 8;
    float nudgeX = 0;
    float nudgeY = 0;
    float nudgeMaxX = 1.5f;
    float nudgeMaxY = 4f;
    float curSpeed;

    public Camera daCamera;

    // Start is called before the first frame update
    void Start()
    {
        curSpeed = minSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // The Z key is the gas pedal
        if (Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.X))
        {
            curSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            curSpeed -= acceleration * Time.deltaTime;
        }

        // The X key serves as the brakes
        if (Input.GetKey(KeyCode.X))
        {
            curSpeed -= deacceleration * Time.deltaTime;
        }

        // The car can't go over the max speed or go under the min speed
        if (curSpeed > maxSpeed)
        {
            curSpeed = maxSpeed;
        }

        if (curSpeed < minSpeed)
        {
            curSpeed = minSpeed;
        }

        // The car moves
        transform.Translate(Vector3.forward * curSpeed * Time.deltaTime);
        daCamera.transform.Translate(Vector3.left * curSpeed * Time.deltaTime);

        // The car can be nudged
        if (Input.GetKey(KeyCode.UpArrow) && nudgeY >= -nudgeMaxY)
        {
            transform.position += Vector3.back * Time.deltaTime * nudgeSpeed;
            nudgeY -= Time.deltaTime * nudgeSpeed;
        }
        if (Input.GetKey(KeyCode.DownArrow) && nudgeY <= nudgeMaxY)
        {
            transform.position += Vector3.forward * Time.deltaTime * nudgeSpeed;
            nudgeY += Time.deltaTime * nudgeSpeed;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && nudgeX >= -nudgeMaxX)
        {
            transform.position += Vector3.right * Time.deltaTime * nudgeSpeed;
            nudgeX -= Time.deltaTime * nudgeSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow) && nudgeX <= nudgeMaxX)
        {
            transform.position += Vector3.left * Time.deltaTime * nudgeSpeed;
            nudgeX += Time.deltaTime * nudgeSpeed;
        }
    }
}