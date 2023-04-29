using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD53.Pathing
{
    public class Path : MonoBehaviour
    {
        [Range(0f, 2f)]
        public float waypointRadius = 1f;
        public Color waypointColor = Color.yellow;
        public Color lineColor = Color.red;
        [Tooltip("Connects the last waypoint with the start.")]
        public bool isLoop = true;
        [Tooltip("Reverse the waypoint order.")]
        public bool reverse = false;
        [Tooltip("The distance tolerance to dected a waypoint.")]
        public float distanceThreshold = .1f;

        private void OnDrawGizmos()
        {
            foreach (Transform item in transform)
            {
                Gizmos.color = waypointColor;
                Gizmos.DrawWireSphere(item.position, waypointRadius);
            }

            Gizmos.color = lineColor;
            for (int i = 0; i < transform.childCount - 1; i++)
            {
                Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
            }

            if (isLoop)
                Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position, transform.GetChild(0).position);
        }

        public Transform GetNext(Transform current)
        {
            if (reverse)
            {
                // we are starting the path (return the first waypoint)
                if (current == null)
                {
                    return transform.GetChild(transform.childCount - 1);
                }

                // waypoints unit the end of the path
                if (current.GetSiblingIndex() > 0)
                {
                    return transform.GetChild(current.GetSiblingIndex() - 1);
                }
                else if (isLoop) // start with the first waypoint again (only when we loop)
                {
                    return transform.GetChild(transform.childCount - 1);
                }
            }
            else
            {
                // we are starting the path (return the first waypoint)
                if (current == null)
                {
                    return transform.GetChild(0);
                }

                // waypoints unit the end of the path
                if (current.GetSiblingIndex() < transform.childCount - 1)
                {
                    return transform.GetChild(current.GetSiblingIndex() + 1);
                }
                else if (isLoop) // start with the first waypoint again (only when we loop)
                {
                    return transform.GetChild(0);
                }
            }
            
            return null;
        }
    }
}
