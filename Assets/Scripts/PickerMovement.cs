using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PickerMovement : MonoBehaviour
    {
        public Vector2 xBound;
        private Rigidbody rb;
        private Vector3 targetPosition;
        private bool horizontalMovement;
        

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            horizontalMovement = false;
            if (Input.GetMouseButton(0))
            {
                horizontalMovement = true;
                var inputPosition = GetInputPositionAtY(transform.position.y);
                targetPosition = transform.position;
                targetPosition.x = inputPosition.x;
                targetPosition.x = Mathf.Clamp(targetPosition.x, xBound.x, xBound.y);
                var distance=Vector3.Distance(transform.position, targetPosition);
                var acceleration = distance / Time.deltaTime;
                var force = acceleration * rb.mass;
                rb.AddForce((targetPosition - transform.position).normalized * force, ForceMode.Force);
            }
        }

        Vector3 GetInputPositionAtY(float hitY)
        {
            var plane = new Plane(Vector3.up, new Vector3(0, hitY, 0));
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out var distance))
            {
                return ray.GetPoint(distance);
            }
            return Vector3.zero;
        }
        
    }
    
}