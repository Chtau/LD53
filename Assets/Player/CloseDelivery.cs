using LD53.Ship;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD53.Player
{
    public class CloseDelivery : MonoBehaviour
    {
        public GameObject indicator;
        public GameObject target;

        private Loot closestTarget;
        private float distance = -1;
        private float timer = 0.0f;

        private void Awake()
        {
            var color = indicator.GetComponentInChildren<Renderer>().material.color;
            var newColor = new Color(color.r, color.g, color.b, 0.5f);
            indicator.GetComponentInChildren<Renderer>().material.color = newColor;
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if (target != null)
            {
                indicator.transform.LookAt(target.transform);
                if (Mathf.RoundToInt(timer % 60) > 10)
                {
                    // try to find a new target every 10 seconds because we could be closer
                    TryFindNewTarget();
                    timer = 0f;
                }
            }
            else
            {
                if (Mathf.RoundToInt(timer % 60) > 5)
                {
                    TryFindNewTarget();
                    timer = 0f;
                }
            }
        }

        private void TryFindNewTarget()
        {
            foreach (Loot instance in GameObject.FindObjectsByType<Loot>(FindObjectsSortMode.InstanceID))
            {
                if (Looter.completeLooted.Contains(instance.LootIndex))
                    continue;
                var dis = Vector3.Distance(indicator.transform.position, instance.transform.position);
                if (distance == -1)
                {
                    distance = dis;
                    closestTarget = instance;
                }
                else if (dis < distance)
                {
                    closestTarget = instance;
                }
            }
            if (closestTarget != null)
            {
                Debug.Log("New Target found");
                target = closestTarget.gameObject;
            }
        }

        public void ShouldUpdateTarget()
        {
            closestTarget = null;
            distance = -1;
            target = null;
            TryFindNewTarget();
        }
    }
}
