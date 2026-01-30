using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _lastPosition = Vector3.zero;
    [SerializeField] private Vector3Variable _playerDestination;
    
    public LayerMask GroundLayer;
    public LayerMask NPCLayer;

    public VoidEventChannel OnNPCClicked;
    
    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        
    }
    
    // Left mouse button click
    public void UseMousePosition(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SetPlayerDestination();
            OnNPCClicked.Raise();
        }
    }

    public void StoreConversation()
    {
        
    }
    
    // Left mouse button move
    public void StoreMousePosition(InputAction.CallbackContext context)
    {
        Ray ray = _camera!.ScreenPointToRay(context.ReadValue<Vector2>());

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, GroundLayer))
        {
            //Debug.DrawRay(ray.origin, (hit.point - ray.origin) * 100, Color.green);
            _lastPosition = hit.point;
        }

        if (Physics.Raycast(ray, out RaycastHit hit2, Mathf.Infinity, NPCLayer))
        {
            //Debug.DrawRay(ray.origin, (hit2.point - ray.origin) * 100, Color.red);
            _lastPosition = hit2.point;

            if (hit2.collider.gameObject.GetType() == typeof(NPC))
            {
                ConversationManager.SetCurrentConversation(hit2.collider.GetComponent<NPC>().Conversation);
            }
            
            Debug.Log(hit2.collider.gameObject.name);
        }
    }

    private void SetPlayerDestination()
    {
        _playerDestination.SetValue(_lastPosition);
        Debug.Log($"Target position set to {_playerDestination.Value}");
        
        // GameObject spawnedObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        // spawnedObject.GetComponent<Renderer>().material.color = Color.cadetBlue;
        // spawnedObject.transform.position = _targetPositionSO.Value;
    }
}