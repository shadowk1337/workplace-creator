using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToStart : MonoBehaviour
{
    public Vector3 startPos;
    
    public float timer;
    public bool isDown;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        startPos = target.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKey("space"))
        {
            target.transform.position = startPos;
            gameObject.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
        }
    }
}
