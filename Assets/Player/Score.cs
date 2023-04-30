using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LD53.Player
{
    public class Score : MonoBehaviour
    {
        public GameUIController gameUIController;

        public UnityEvent<int> ScoreChanged;

        public static int Value { get; private set; }

        public void Add(int value)
        {
            Value += value;
            gameUIController.UpdateScore(Value);
            ScoreChanged?.Invoke(Value);
        }
    }
}
