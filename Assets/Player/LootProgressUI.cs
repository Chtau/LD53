using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LD53.Player
{
    public class LootProgressUI : MonoBehaviour
    {
        public GameObject wrapper;
        public TextMeshProUGUI progressText;
        public Image progressImage;

        public void SetProgress(int value)
        {
            if (!(value >= 0 && value <= 100))
            {
                wrapper.SetActive(false);
                return;
            }
            
            if (!wrapper.activeSelf)
            {
                wrapper.SetActive(true);
            }
            progressText.text = value.ToString() + "%";
            progressImage.fillAmount = value / 100f;

            if (value >= 100)
            {
                wrapper.transform.DOScale(0, .2f).SetDelay(.5f).OnComplete(() => wrapper.SetActive(false));
            }
        }

        public void HideProgress()
        {
            wrapper.transform.DOScale(0, .2f).SetDelay(.5f).OnComplete(() => wrapper.SetActive(false));
        }
    }
}
