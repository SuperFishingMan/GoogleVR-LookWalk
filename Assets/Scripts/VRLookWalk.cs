using UnityEngine;
using System.Collections;

public class VRLookWalk : MonoBehaviour {

    // VR Main Camera
    public Transform vrCamera;
    // Angle at which walk/stop will be triggered(X value of main camera)
    public float toggleAngle = 15.0f;
    // How fast to move
    public float speed = 3.0f;
    // Should I move forward or not
    public bool moveForward;
    // CharcterController script
    private CharacterController cc; 

	// Use this for initialization
	void Start () {
        // Find the CharacterController cc 
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        // Check to see if the head has rotated down to the toggleangle, but not more than straight down
	    if(vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f)
        {
            moveForward = true;
        }else
        {
            moveForward = false;
        }

        // Check to see if I should move
        if (moveForward)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);

            cc.SimpleMove(forward * speed);
        }
	}
}
