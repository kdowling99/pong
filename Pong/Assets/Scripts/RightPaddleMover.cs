using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPaddleMover : MonoBehaviour
{
    public Transform transform;

    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.z < 10)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.z > -10)
        {
            transform.position += -Vector3.forward * speed * Time.deltaTime;
        }
    }
}
