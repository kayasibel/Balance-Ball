using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
namespace UnityStandardAssets.Vehicles.Ball
{
    public class JoystickPlayerExample : MonoBehaviour
    {
        /*
        public float speed;
        public VariableJoystick variableJoystick;
        public Rigidbody rb;
        Transform cam;

        public void FixedUpdate()
        {
            Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        }
        */

        public VariableJoystick variableJoystick;
        private Transform cam; // A reference to the main camera in the scenes transform
        public Ball ball;
        private Vector3 camForward; // The current forward direction of the camera
        public Rigidbody rb;
        private Vector3 move;
        private bool jump;

        private void Awake()
        {
            ball = GetComponent<Ball>();

            // get the transform of the main camera
            if (Camera.main != null)
            {
                cam = Camera.main.transform;
            }
        }

        private void Update()
        {
            Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            

            if (cam != null)
            {
                // calculate camera relative direction to move:
                camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
                move = (direction.z * camForward + direction.x * cam.right).normalized;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                move = (direction.z * Vector3.forward + direction.x * Vector3.right).normalized;
            }
        }

        private void FixedUpdate()
        {
            // Call the Move function of the ball controller
            ball.Move(move, jump);
            jump = false;
        }
    }
}
