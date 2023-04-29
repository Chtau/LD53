using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD53.Pathing
{
    public class PathMoving : MonoBehaviour
    {
        public Path path;
        public float moveSpeed = 1f;

        private Transform currentWaypoint;

        private void Start()
        {
            currentWaypoint = path.GetNext(currentWaypoint);
            transform.position = currentWaypoint.position;

            // get the next waypoint to move towards
            currentWaypoint = path.GetNext(currentWaypoint);
            transform.LookAt(currentWaypoint);
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, currentWaypoint.position) < path.distanceThreshold)
            {
                currentWaypoint = path.GetNext(currentWaypoint);
                if (currentWaypoint != null)
                {
                    transform.LookAt(currentWaypoint);
                }
                else
                {
                    // TODO: handle target reached
                }
            }
        }
    }
}
