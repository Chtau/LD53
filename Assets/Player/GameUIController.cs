using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LD53.Player
{
    public class GameUIController : MonoBehaviour
    {
        public MouseLock mouseLock;
        public Pause pause;

        public GameObject menuPanel;
        public TextMeshProUGUI menuText;
        public Image lootAlert;
        public TextMeshProUGUI currentScore;
        public TextMeshProUGUI healthPointsText;
        public Image healthPointsValue;
        public Button returnButton;
        public GameObject startMissionMenu;
        public ScrollRect scrollRectMission;
        public GameObject eventMessageObj;
        public TextMeshProUGUI eventMessageText;

        public int healthMaxValue = 100;

        private void Awake()
        {
            startMissionMenu.SetActive(true);
            menuPanel.SetActive(false);
            lootAlert.gameObject.SetActive(false);
            eventMessageObj.SetActive(false);
            currentScore.text = "0";
            healthPointsText.text = $"100/{healthMaxValue}";
            healthPointsValue.fillAmount = 1;
        }

        private void Start()
        {
            scrollRectMission.verticalNormalizedPosition = 1;
            pause.PauseGame();
        }

        public void UpdateHealth(int value)
        {
            healthPointsText.text = $"{value}/{healthMaxValue}";
            healthPointsValue.fillAmount = (float)value / healthMaxValue;
        }

        public void UpdateScore(int value)
        {
            currentScore.text = value.ToString();
        }

        public void ShowLootAlert(bool show)
        {
            lootAlert.gameObject.SetActive(show);
        }

        public void ShowMenu(bool isGameover = false)
        {
            pause.PauseGame();
            if (isGameover)
            {
                menuText.text = "Game Over";
                returnButton.gameObject.SetActive(false);
            }
            else
            {
                menuText.text = "Pause";
                returnButton.gameObject.SetActive(true);
            }
            menuPanel.SetActive(true);
        }

        public void GORestart()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

        public void GOExit()
        {
            Application.Quit();
        }

        public void GOReturn()
        {
            menuPanel.SetActive(false);
            mouseLock.TryLock();
            pause.UnpauseGame();
        }

        public void BtnMenu()
        {
            ShowMenu(false);
        }

        public void StartMission()
        {
            startMissionMenu.SetActive(false);
            mouseLock.TryLock();
            pause.UnpauseGame();
        }

        public void ShowEventMessage(string msg, bool positive = true)
        {
            eventMessageText.text = msg;
            eventMessageText.color = positive ? new Color(0.2904354f, 0.7357641f, 0.8396226f) : new Color(0.8392157f, 0.2901961f, 0.430219f);
            eventMessageObj.SetActive(true);

            eventMessageObj.transform.DOScale(0, 0.2f).SetDelay(3f).OnComplete(() => eventMessageObj.SetActive(false));
        }
    }
}
