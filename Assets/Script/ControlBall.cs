 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ControlBall : MonoBehaviour
{
    // var pGain: float;
    // var iGain: float;
    // var dGain: float;
    // private var lastPError: float = 0;

    // function Pidloop(){
    //     var pError = desiredAngle - currentAngle;
    //     var iError += pError * Time.deltaTime;
    //     var dError = (pError - lastPError)/ Time.deltaTime;
    //     lastPError = pError; 
    //     torque = pGain*pError=iGain*iError=dGain*dError;
    //     ApplyTorque(torque);
    // } 
    
    // public float xForce = 10.0f;  
    // public float zForce = 10.0f;  
    // public float yForce = 500.0f;  
    public float speed;
    private Rigidbody rb;
    public float torque;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent <Rigidbody> ();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionEnter(){
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Set some local float variables equal to the value of our Horizontal and Vertical Inputs
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        // Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        // Add a physical force to our Player rigidbody using our 'movement' Vector3 above, 
        // multiplying it by 'speed' - our public player speed that appears in the inspector
        rb.AddForce (movement * speed);

        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded){
            rb.AddForce(jump* jumpForce, ForceMode.Impulse);
            isGrounded = false ;
        }
    }
}
