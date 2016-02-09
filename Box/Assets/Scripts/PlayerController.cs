using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody myRigidBody;

    public float jumpTime;
    private float jumpTimeCounter;

    public bool grounded;

    private BoxCollider myCollider;

    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();

        myCollider = GetComponent<BoxCollider>();

        jumpTimeCounter = jumpTime;

        myRigidBody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpForce, myRigidBody.velocity.z);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpForce, myRigidBody.velocity.z);
            }

        }


        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if (jumpTimeCounter > 0)
            {
                myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpForce, myRigidBody.velocity.z);
                jumpTimeCounter -= Time.deltaTime;
            }

        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0) )
        {
            jumpTimeCounter = 0;
        }

        
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, myRigidBody.velocity.y, myRigidBody.velocity.z + moveSpeed);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, myRigidBody.velocity.y, myRigidBody.velocity.z - moveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x + moveSpeed, myRigidBody.velocity.y, myRigidBody.velocity.z - moveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x - moveSpeed, myRigidBody.velocity.y, myRigidBody.velocity.z - moveSpeed);
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if(col.collider.name == "Ground")
        {
            Debug.Log("Collision with Ground detected");

            grounded = true;

            //Reset JumpTime
            jumpTimeCounter = jumpTime;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.collider.name == "Ground")
        {
            Debug.Log("Collision with Ground detected");

            grounded = false;
        }
    }

}
