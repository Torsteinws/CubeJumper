using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform cameraTransform;
    private Vector3 cameraOffset;
    public Rigidbody rigidBody;
    public float xSpeed = 100;
    public float ySpeed = 100;
    public float zSpeed = 100;

    private bool mvLeft = false;
    private bool mvRight = false;
    private bool mvBack = false;
    private bool mvForward = false;
    private bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        this.cameraOffset = this.cameraTransform.position - this.transform.position;
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        mvLeft = Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow);
        mvRight = Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow);
        mvBack = Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow);
        mvForward = Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow);
       
        jump = Input.GetKey(KeyCode.Space);
    }

    void FixedUpdate()
    {
        //rigidBody.AddForce(0, 0, 10 * Time.deltaTime, ForceMode.Impulse);

        if(mvLeft && !mvRight)
        {
            rigidBody.AddForce(-xSpeed * Time.deltaTime, 0, 0);
            Debug.Log("Move left");
        }
        else if(!mvLeft && mvRight)
        {
            rigidBody.AddForce(xSpeed * Time.deltaTime, 0, 0);
            Debug.Log("Move right");
        }

        if (mvForward && !mvBack)
        {
            rigidBody.AddForce(0, 0, zSpeed * Time.deltaTime);
            Debug.Log("Move forward");
        }
        else if(!mvForward && mvBack)
        {
            rigidBody.AddForce(0, 0, -zSpeed * Time.deltaTime);
            Debug.Log("Move back");
        }

        if (jump)
        {
            rigidBody.AddForce(0, ySpeed * Time.deltaTime, 0);
            Debug.Log("Jump");
        }

        UpdateCamera();

        //Debug.Log("Fixed Update complete");
        Reset();
    }

    void UpdateCamera()
    {
        cameraTransform.position = this.transform.position + cameraOffset;
    }

    void Reset()
    {
        mvLeft = false;
        mvRight = false;
        mvBack = false;
        mvForward = false;
        jump = false;
    }
}
