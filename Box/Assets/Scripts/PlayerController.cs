using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody myRigidBody;

    public float jumpTime;
    private float jumpTimeCounter;

    public bool grounded;
    public LayerMask whatIsGround;

    private BoxCollider myCollider;

    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();

        myCollider = GetComponent<BoxCollider>();

        jumpTimeCounter = jumpTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded)
            {
                myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpForce, myRigidBody.velocity.z);
            }
        }
            
        

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded)
            {
                myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpForce, myRigidBody.velocity.z);
            }

        }


        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) || Input.GetKey(KeyCode.UpArrow))
        {
            if (jumpTimeCounter > 0)
            {
                myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpForce, myRigidBody.velocity.z);
                jumpTimeCounter -= Time.deltaTime;
            }

        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            jumpTimeCounter = 0;
        }

        /*
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, myRigidBody.velocity.y, myRigidBody.velocity.z);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, myRigidBody.velocity.y, myRigidBody.velocity.z);
        }
        */
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
