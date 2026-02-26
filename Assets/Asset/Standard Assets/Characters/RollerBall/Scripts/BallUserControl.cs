using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Ball
{
    public class BallUserControl : MonoBehaviour
    {

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
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 direction = Vector3.forward * moveVertical + Vector3.right * moveHorizontal;


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
