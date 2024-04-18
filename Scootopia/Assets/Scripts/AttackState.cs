using UnityEngine;

public class AttackState : IAIState
{
    private AIStateMachine stateMachine;
    private UnityEngine.AI.NavMeshAgent agent;
    private Transform playerTransform;
    private float detectionRadius = 20f;
    private float attackSpeed = 10;
    public BusCollision busCollision;
    public AttackState(AIStateMachine stateMachine, UnityEngine.AI.NavMeshAgent agent)
    {
        this.stateMachine = stateMachine;
        this.agent = agent;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        busCollision = GameObject.FindObjectOfType<BusCollision>();
    }

    public void Enter()
    {
        stateMachine.agent.speed = attackSpeed;
        Debug.Log("Entering Attack State");
    }

    public void Execute()
    {
        if (playerTransform != null)
        {
            agent.SetDestination(playerTransform.position);
        }

        if(Vector3.Distance(stateMachine.agent.transform.position, playerTransform.position) > detectionRadius)
        {
            stateMachine.SetState(new IdleState(stateMachine, stateMachine.agent));
        }

        if(busCollision.isRagdoll)
        {
            stateMachine.SetState(new IdleState(stateMachine, stateMachine.agent));
        }
    }

    public void Exit()
    {
        Debug.Log("Leaving Attack State");
    }
}
