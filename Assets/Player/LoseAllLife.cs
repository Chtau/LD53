using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD53.Player
{
    public class LoseAllLife : MonoBehaviour
    {
        public GameUIController gameUIController;

        public void Lose()
        {
            gameUIController.ShowMenu(true);
        }
    }
}
