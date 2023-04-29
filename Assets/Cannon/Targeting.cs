using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD53.Cannon
{
    public class Targeting : MonoBehaviour
    {
        [Tooltip("Speed multiplier for horizontal & vertical rotation.")]
        public Vector2 turnSpeed = new Vector2(1, 1);

        [Tooltip("Maximum rotation from the initial orientation.")]
        public Vector2 degreeClamp = new Vector2(90, 80);

        Quaternion initialOrientation;
        Vector2 currentAngles;
        CursorLockMode previousLockState;
        bool wasCursorVisible;

        private void OnEnable()
        {
            initialOrientation = transform.localRotation;
            previousLockState = Cursor.lockState;
            wasCursorVisible = Cursor.visible;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            // only on mouse lock allow to rotate
            if (Cursor.lockState != CursorLockMode.Locked)
                return;

            Vector2 motion = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            // Scale it by the turn speed, add it to our current angle, and clamp.
            motion = Vector2.Scale(motion, turnSpeed);
            currentAngles += motion;
            currentAngles = Vector2.Min(currentAngles, degreeClamp);
            currentAngles = Vector2.Max(currentAngles, -degreeClamp);

            // Rotate to look in this direction, relative to our initial orientation.
            Quaternion look = Quaternion.Euler(-currentAngles.y, 1f * currentAngles.x, 0);

            transform.localRotation = initialOrientation * look;
        }

        private void OnDisable()
        {
            Cursor.visible = wasCursorVisible;
            Cursor.lockState = previousLockState;
            transform.localRotation = initialOrientation;
        }
    }
}
