using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _lastPosition = Vector3.zero;
    [SerializeField] private Vector3Variable _playerDestination;
    
    public LayerMask GroundLayer;
    public LayerMask NPCLayer;
    public LayerMask UILayer;

    [SerializeField] private bool _isHoveringOverGround;
    [SerializeField] private bool _isHoveringOverNpc;
    [SerializeField] private bool _isHoveringOverUI;

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
            if (_isHoveringOverGround)
                SetPlayerDestination();
            
            if( _isHoveringOverNpc)
                OnNPCClicked.Raise();
        }
    }
    
    // Left mouse button move
    public void StoreMousePosition(InputAction.CallbackContext context)
    {
        Ray ray = _camera!.ScreenPointToRay(context.ReadValue<Vector2>());

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, GroundLayer))
        {
            //Debug.DrawRay(ray.origin, (hit.point - ray.origin) * 100, Color.green);
            _lastPosition = hit.point;
            _isHoveringOverGround = true;
            return;
        }
        
        _isHoveringOverGround = false;
    }

    public void HoverOverNPC(InputAction.CallbackContext context)
    {
        Ray ray = _camera!.ScreenPointToRay(context.ReadValue<Vector2>());
        
        if (Physics.Raycast(ray, out RaycastHit hit2, Mathf.Infinity, NPCLayer))
        {
            _isHoveringOverNpc = true;
            _isHoveringOverGround = false;
            _isHoveringOverUI = false;
            
            //Debug.DrawRay(ray.origin, (hit2.point - ray.origin) * 100, Color.red);
            _lastPosition = hit2.point;

            if (hit2.collider.gameObject.GetType() == typeof(NPC))
            {
                ConversationManager.SetCurrentConversation(hit2.collider.GetComponent<NPC>().Conversation);
            }
            
            Debug.Log(hit2.collider.gameObject.name);
            return;
        }
        
        _isHoveringOverNpc = false;
    }

    public void HoverOverUI(InputAction.CallbackContext context)
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        Ray ray = _camera!.ScreenPointToRay(context.ReadValue<Vector2>());
        
        if (Physics.Raycast(ray, out RaycastHit hit2, Mathf.Infinity, UILayer))
        {
            _isHoveringOverUI = true;
            _isHoveringOverNpc = false;
            _isHoveringOverGround = false;
            return;
        }
        
        _isHoveringOverUI = false;
        
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