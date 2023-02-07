using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class NavAgentMover : MonoBehaviour
{
    private NavMeshAgent agent = null;

    private void Awake() {
            //make sure has agent
            if (!agent && !TryGetComponent(out agent)) {
                Debug.Log("ENNEMY 2 :: " + name + " needs a navmesh agent");
            }
    }

    private void Update()
    {
        if (ReachedDestinationOrGaveUp()) {
            Stop();
        }
    }

    public bool ReachedDestinationOrGaveUp()
    {

        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }

        return false;
    }

    internal void MoveToPos(Vector3 pos, float speed = 0) {
        if (speed != 0) {
           agent.speed = speed; 
           agent.acceleration = speed; 
        }       
        agent.SetDestination(pos);
        agent.isStopped = false;
    }

    internal void Teleport(Vector3 pos) {
        agent.transform.position = pos;
        agent.isStopped = false;
    }
    
    internal void MoveTo(Transform transform) => MoveToPos(transform.position);

    internal bool HasArrived => !agent.hasPath || agent.remainingDistance <= agent.stoppingDistance;

    internal bool IsCloseToDest(float closeThreshold) => agent.remainingDistance <= closeThreshold;

    internal void Stop() => agent.isStopped = true;

    internal float GetMaxSpeed() => agent.speed;

    internal float GetCurrentSpeed() => agent.velocity.magnitude;
}
