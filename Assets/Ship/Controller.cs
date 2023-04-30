using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LD53.Ship
{
    public class Controller : MonoBehaviour
    {
        public float normalSpeed = 25f;
        public float accelerationSpeed = 45f;
        public Transform cameraPosition;
        public Camera mainCamera;
        public Transform spaceshipRoot;
        public float rotationSpeed = 1.0f;
        public float cameraSmooth = 4f;
        public RectTransform crosshairTexture;

        float speed;
        Rigidbody r;
        Quaternion lookRotation;
        float rotationZ = 0;
        float mouseXSmooth = 0;
        float mouseYSmooth = 0;
        Vector3 defaultShipRotation;

        private void Start()
        {
            r = GetComponent<Rigidbody>();
            lookRotation = transform.rotation;
            defaultShipRotation = transform.localEulerAngles;
            defaultShipRotation = spaceshipRoot.localEulerAngles;
            rotationZ = defaultShipRotation.z;
            
            /*Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;*/
        }

        private void FixedUpdate()
        {
            if (Cursor.lockState != CursorLockMode.Locked)
                return;
            if (Input.GetAxis("Vertical") > 0)
            {
                speed = Mathf.Lerp(speed, accelerationSpeed, Time.deltaTime * 3);
            }
            else
            {
                speed = Mathf.Lerp(speed, normalSpeed, Time.deltaTime * 10);
            }

            Vector3 moveDirection = new Vector3(0, 0, speed);
            //Transform the vector3 to local space
            moveDirection = transform.TransformDirection(moveDirection);
            //Set the velocity, so you can move
            r.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);

            //Camera follow
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, cameraPosition.position, Time.deltaTime * cameraSmooth);
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, cameraPosition.rotation, Time.deltaTime * cameraSmooth);

            //Rotation
            float rotationZTmp = 0;
            if (Input.GetKey(KeyCode.A))
            {
                rotationZTmp = 1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rotationZTmp = -1;
            }
            mouseXSmooth = Mathf.Lerp(mouseXSmooth, Input.GetAxis("Mouse X") * rotationSpeed, Time.deltaTime * cameraSmooth);
            mouseYSmooth = Mathf.Lerp(mouseYSmooth, Input.GetAxis("Mouse Y") * rotationSpeed, Time.deltaTime * cameraSmooth);
            Quaternion localRotation = Quaternion.Euler(-mouseYSmooth, mouseXSmooth, rotationZTmp * rotationSpeed);
            lookRotation *= localRotation;
            transform.rotation = lookRotation;
            rotationZ -= mouseXSmooth;
            rotationZ = Mathf.Clamp(rotationZ, -45, 45);
            spaceshipRoot.transform.localEulerAngles = new Vector3(defaultShipRotation.x, defaultShipRotation.y, rotationZ);
            rotationZ = Mathf.Lerp(rotationZ, defaultShipRotation.z, Time.deltaTime * cameraSmooth);

            //Update crosshair texture
            if (crosshairTexture)
            {
                crosshairTexture.position = mainCamera.WorldToScreenPoint(transform.position + transform.forward * 100);
            }
        }

        private void OnEnable()
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
        }

        private void OnDisable()
        {
            /*Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;*/
        }
    }
}
