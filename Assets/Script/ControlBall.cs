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

    void OnCollisionStay(){
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        rb.AddTorque(transform.forward * torque * Horizontal);

        float Vertical = Input.GetAxis("Vertical");
        rb.AddTorque(transform.right * torque * Vertical);

        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded){
            rb.AddForce(jump* jumpForce, ForceMode.Impulse);
            isGrounded = false ;
        }
    }
}
