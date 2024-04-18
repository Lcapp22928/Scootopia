using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class AIStateMachine : MonoBehaviour
{
    private IAIState currentState;
    public NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        var idleState = new IdleState(this, agent);

        SetState(idleState);
    }

    public void SetState(IAIState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    private void Update()
    {
        currentState?.Execute();
    }
}
