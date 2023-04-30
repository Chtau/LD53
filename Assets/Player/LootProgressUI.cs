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

        private object id = "lp1";
        private object id1 = "lp2";

        public void SetProgress(int value)
        {
            DOTween.Complete(id);
            if (!(value >= 0 && value <= 100))
            {
                wrapper.SetActive(false);
                return;
            }
            
            if (!wrapper.activeSelf)
            {
                wrapper.transform.DOScale(1, 0);
                wrapper.SetActive(true);
            }
            progressText.text = value.ToString() + "%";
            progressImage.fillAmount = value / 100f;

            if (value >= 100)
            {
                if (wrapper.activeSelf)
                    wrapper.transform.DOScale(0, .2f).SetDelay(.5f).OnComplete(() => wrapper.SetActive(false)).SetId(id);
            }
        }

        public void HideProgress()
        {
            DOTween.Complete(id1);
            if (wrapper.activeSelf)
                wrapper.transform.DOScale(0, .2f).SetDelay(.5f).OnComplete(() => wrapper.SetActive(false)).SetId(id1);
        }
    }
}
