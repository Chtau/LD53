using LD53.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD53
{
    public class MouseLock : MonoBehaviour
    {
        public GameUIController gameUIController;

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
                gameUIController.ShowMenu(false);
            }
        }

        public void TryLock()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void TryUnlock()
        {
            if (!Cursor.visible)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
