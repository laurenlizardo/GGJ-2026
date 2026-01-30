using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _lastPosition;
    [SerializeField] private Vector3Variable _playerDestination;
    
    public LayerMask GroundLayer;
    
    private void Start()
    {
        _camera = Camera.main;
    }
    
    public void UseMousePosition(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SetPlayerDestination();
        }
    }
    
    public void StoreMousePosition(InputAction.CallbackContext context)
    {
        Ray ray = _camera!.ScreenPointToRay(context.ReadValue<Vector2>());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, GroundLayer))
        {
            _lastPosition = hit.point;
            return;
        }

        _lastPosition = Vector3.zero;
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