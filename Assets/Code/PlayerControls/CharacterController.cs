using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Vector3SO _targetPositionSO;
    
    private NavMeshAgent _navMeshAgent;
    public float StoppingDistance = .25f;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void MoveToTarget(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // Enable nav mesh agent
            _navMeshAgent.isStopped = false;
        }
    }

    private void Move()
    {
        if (!_navMeshAgent.isStopped)
        {
            // Go to the target position
            //transform.position = _targetPositionSO.Value;
            transform.LookAt(new Vector3(_targetPositionSO.Value.x, 0, _targetPositionSO.Value.z));
            _navMeshAgent.SetDestination(_targetPositionSO.Value);
        
            // When close enough, stop moving
            if (_navMeshAgent.remainingDistance <= StoppingDistance)
            {
                _navMeshAgent.velocity = Vector3.zero;
                _navMeshAgent.isStopped = true;
                transform.position = transform.position;
            }
        }
    }

    private void Update()
    {
        Move();
    }
}
