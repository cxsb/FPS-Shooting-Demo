using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace A2
{
    public enum MoveState
    {
        Stay = 1,
        Walk = 2,
        Run = 3
    }
    public class Character : MonoBehaviour
    {
        public Action<bool> actionRun;
        public Action<bool> actionMove;

        public HealthState healthState;
        public HitSender hitSender;

        [HideInInspector]
        public bool isBusy;
        [HideInInspector]
        private bool isRunning;
        private bool isMoving;

        [HideInInspector]
        public MoveState moveState{
            get
            {
                if(!isMoving)
                {
                    return MoveState.Stay;
                }
                else
                {
                    if(isRunning)
                    {
                        return MoveState.Run;
                    }
                    else
                    {
                        return MoveState.Walk;
                    }
                }
            }
        }

        public GameObject initiativeEquipmentRoot;
        public InitiativeEquipment initiativeEquipment;

        public float moveSpeed = 3;
        public float dashScale = 2;
        public float jumpForce = 40;
        public Rigidbody rigidBody;
        private float jumpTimeStamp = 0;
        public float minJumpInterval = 0.25f;

        public void Move(float v,float h, bool dash)
        {
            bool _isRunning = false;
            bool _isMoving = false;
            if(dash && v>0)
            {
                v = v * dashScale;
                _isRunning = true;
            }
            transform.Translate((Vector3.right * h + Vector3.forward * v) * moveSpeed * Time.deltaTime);
            if(rigidBody.velocity.magnitude < 1>>13)
            {
                _isRunning = false;
            }
            if(actionRun != null && isRunning != _isRunning)
            {
                actionRun(_isRunning);
            }
            isRunning = _isRunning;

            _isMoving = rigidBody.velocity.magnitude != 0 && (v!=0||h!=0);
            if(actionMove != null && isMoving != _isMoving)
            {
                actionMove(_isMoving);
            }
            isMoving = _isMoving;
        }

        public void Jump()
        {
            if(isJumpAvaliable) rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        public void Rotate(float rotateX, float rotateY)
        {
            float rotationX = transform.localEulerAngles.y + rotateX;
            float rotationY = initiativeEquipmentRoot.transform.localEulerAngles.x + rotateY;
            initiativeEquipmentRoot.transform.localEulerAngles = new Vector3 (rotationY, 0, 0);
            transform.localEulerAngles = new Vector3 (0, rotationX, 0);
        }

        private bool isGrounded;
        public bool isJumpAvaliable {
            get
            {
                bool jumpCooldownOver = (Time.time - jumpTimeStamp) >= minJumpInterval;
                if (jumpCooldownOver && isGrounded)
                {
                    jumpTimeStamp = Time.time;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private List<Collider> collisions = new List<Collider>();

        private void OnCollisionEnter(Collision collision)
        {
            ContactPoint[] contactPoints = collision.contacts;
            for(int i = 0; i < contactPoints.Length; i++)
            {
                if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
                {
                    if (!collisions.Contains(collision.collider)) {
                        collisions.Add(collision.collider);
                    }
                    isGrounded = true;
                }
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            ContactPoint[] contactPoints = collision.contacts;
            bool validSurfaceNormal = false;
            for (int i = 0; i < contactPoints.Length; i++)
            {
                if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
                {
                    validSurfaceNormal = true; break;
                }
            }

            if(validSurfaceNormal)
            {
                isGrounded = true;
                if (!collisions.Contains(collision.collider))
                {
                    collisions.Add(collision.collider);
                }
            } else
            {
                if (collisions.Contains(collision.collider))
                {
                    collisions.Remove(collision.collider);
                }
                if (collisions.Count == 0) { isGrounded = false; }
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if(collisions.Contains(collision.collider))
            {
                collisions.Remove(collision.collider);
            }
            if (collisions.Count == 0) { isGrounded = false; }
        }
    }
}
