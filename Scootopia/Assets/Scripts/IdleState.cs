using UnityEngine;
using System.Linq;

public class IdleState : IAIState
{
    private AIStateMachine stateMachine;
    private Transform[] waypoints;
    private int waypointIndex = 0;
    private Transform playerTransform;
    private float detectionRadius = 20f;
    private float idleSpeed = 5f;

    public IdleState(AIStateMachine stateMachine, UnityEngine.AI.NavMeshAgent agent)
    {
        this.stateMachine = stateMachine;
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint").Select(obj => obj.transform).ToArray();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Enter()
    {
        stateMachine.agent.speed = idleSpeed;
        waypointIndex = 0;
        stateMachine.agent.SetDestination(waypoints[waypointIndex].position);
    }

    public void Execute()
    {
        if (Vector3.Distance(stateMachine.agent.transform.position, playerTransform.position) <= detectionRadius)
        {
            stateMachine.SetState(new AttackState(stateMachine, stateMachine.agent));
        }
        else
        {
            if (stateMachine.agent.remainingDistance < 0.5f)
            {
                waypointIndex = (waypointIndex + 1) % waypoints.Length;
                stateMachine.agent.SetDestination(waypoints[waypointIndex].position);
            }
        }
    }

    public void Exit()
    {

    }
}
