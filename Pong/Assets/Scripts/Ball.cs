using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speedMultiplier = 1.1f;
    public float offsetMultiplier = 5f;
    private int playerOneScore = 0;
    private int playerTwoScore = 0;
    
    public Rigidbody rb;

    public Transform t;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
        rb.velocity = new Vector3(20, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (t.position.x > 26)
        {
            Debug.Log("Player 1 scores!");
            playerOneScore++;
            if (playerOneScore > 10)
            {
                Debug.Log("Player 1 wins!");
                Debug.Log("Final Score: " + playerOneScore + "-" + playerTwoScore);
                t.SetPositionAndRotation(Vector3.zero, new Quaternion(0,0,0, 0));
                rb.velocity = new Vector3(0, 0, 0);
            }
            else
            {
                Debug.Log("Current Score: " + playerOneScore + "-" + playerTwoScore);
                t.SetPositionAndRotation(Vector3.zero, new Quaternion(0, 0, 0, 0));
                rb.velocity = new Vector3(20, 0, 0);
            }
        } else if (t.position.x < -26)
        {
            Debug.Log("Player 2 scores!");
            playerTwoScore++;
            if (playerTwoScore > 10)
            {
                Debug.Log("Player 2 wins!");
                Debug.Log("Final Score: " + playerOneScore + "-" + playerTwoScore);
                t.SetPositionAndRotation(Vector3.zero, new Quaternion(0,0,0, 0));
                rb.velocity = new Vector3(0, 0, 0);
            }
            else
            {
                Debug.Log("Current Score: " + playerOneScore + "-" + playerTwoScore);
                t.SetPositionAndRotation(Vector3.zero, new Quaternion(0, 0, 0, 0));
                rb.velocity = new Vector3(-20, 0, 0);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if (collision.gameObject.name == "Left Paddle" || collision.gameObject.name == "Right Paddle")
        // {
        //     Vector3 offset = offsetMultiplier * Vector3.back * 
        //                      (collision.gameObject.GetComponent<Transform>().position.z - transform.position.z);
        //     float initialMagnitude = rb.velocity.magnitude;
        //
        //     rb.velocity = (rb.velocity + offset);
        //     rb.velocity *= initialMagnitude / rb.velocity.magnitude;
        //     rb.velocity *= speedMultiplier;
        // }
        if (collision.gameObject.name == "Left Paddle")
        {
            Vector3 direction = new Vector3(1,0,((collision.gameObject.GetComponent<Transform>().position.z - transform.position.z) / -2.5f)); //max angle 45
            float initialMagnitude = rb.velocity.magnitude;
            rb.velocity = (direction / direction.magnitude) * initialMagnitude * speedMultiplier;
        } else if (collision.gameObject.name == "Right Paddle")
        {
            Vector3 direction = new Vector3(-1,0,((collision.gameObject.GetComponent<Transform>().position.z - transform.position.z) / -2.5f)); //max angle 45
            float initialMagnitude = rb.velocity.magnitude;
            rb.velocity = (direction / direction.magnitude) * initialMagnitude * speedMultiplier;
        }
        
    }
}
