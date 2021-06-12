using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float krai = 10f;
    public float speed = 10f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            transform.position -= new Vector3(0, 0, speed) * Time.deltaTime;
        }
        if (Input.GetKey("w"))
        {
            transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
        }
    }
}