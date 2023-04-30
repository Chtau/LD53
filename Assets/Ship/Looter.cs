using LD53.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD53.Ship
{
    public class Looter : MonoBehaviour
    {
        public AudioSource audioSource;
        public Score score;
        public GameUIController gameUIController;
        public LootProgressUI lootProgressUI;

        private List<int> completeLooted = new();

        private bool inLootingArea = false;
        private int lootAreaNumber = 0;
        private int currentLootTarget = 0;
        private int lootValue = 0;
        private float timer = 0.0f;

        private void Update()
        {
            if (inLootingArea)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    if (lootAreaNumber != currentLootTarget)
                    {
                        // reset loot progress
                        currentLootTarget = lootAreaNumber;
                        lootValue = 0;
                        timer = 0.0f;
                    }
                    else
                    {
                        // increase progress till we reach 100%
                        timer += Time.deltaTime;
                        lootValue = Mathf.RoundToInt(timer % 60) * (100 / 30);
                        if (lootValue > 100)
                            lootValue = 100;
                    }
                    lootProgressUI.SetProgress(lootValue);
                    if (lootValue >= 100 && !completeLooted.Contains(lootAreaNumber))
                    {
                        // loot complete
                        completeLooted.Add(lootAreaNumber);
                        score.Add(Random.Range(10, 15));
                        lootProgressUI.HideProgress();
                        gameUIController.ShowLootAlert(false);
                        gameUIController.ShowEventMessage("Delivery intercepted");
                        audioSource.Play();
                    }
                }
            }
        }

        public void SetLoot(int loot)
        {
            // already complete looted
            if (completeLooted.Contains(loot))
            {
                gameUIController.ShowLootAlert(false);
                return;
            }
            // 0 indicates we exit the looting area
            inLootingArea = loot == 0 ? false : true;
            lootAreaNumber = loot;
            gameUIController.ShowLootAlert(loot == 0 ? false : true);
        }
    }
}
