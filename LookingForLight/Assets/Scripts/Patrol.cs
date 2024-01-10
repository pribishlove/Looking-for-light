using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int currentPatrolIndex;
    public float speed = 2;

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPatrolIndex].position, speed * Time.fixedDeltaTime);
        if (Vector2.Distance(transform.position, patrolPoints[currentPatrolIndex].position) < 0.2f)
        {
            if (currentPatrolIndex > 0)
            {
                currentPatrolIndex = 0;
            }
            else
            {
                currentPatrolIndex = 1;
            }
        }
    }

}

