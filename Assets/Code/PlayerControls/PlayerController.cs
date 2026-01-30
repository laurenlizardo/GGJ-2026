using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    [SerializeField] private Vector3Variable _playerDestination;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.SetDestination(transform.position);
    }

    private void Update()
    {
        Move();
    }
    
    private void Move()
    {
        // Go to the target position
        _navMeshAgent.SetDestination(_playerDestination.Value);
    }
}
