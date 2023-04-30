using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD53
{
    public class Pause : MonoBehaviour
    {
        public static bool IsPaused { get; private set; }

        public void PauseGame()
        {
            IsPaused = !IsPaused;
            Time.timeScale = IsPaused ? 0 : 1;
            AudioListener.pause = IsPaused;
        }

        public void UnpauseGame()
        {
            IsPaused = false;
            Time.timeScale = IsPaused ? 0 : 1;
            AudioListener.pause = IsPaused;
        }
    }
}
