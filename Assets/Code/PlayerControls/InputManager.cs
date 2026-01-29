using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private Vector3SO _targetPositionSO;
    
    public LayerMask GroundLayer;
    
    private void Start()
    {
        _camera = Camera.main;
    }
    
    public void MoveTo(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ShowTargetPosition();
        }
    }
    
    public void GetMousePosition(InputAction.CallbackContext context)
    {
        Ray ray = _camera.ScreenPointToRay(context.ReadValue<Vector2>());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, GroundLayer))
        {
            _targetPositionSO.Value = hit.point;
            return;
        }

        _targetPositionSO.Value = Vector3.zero;
    }

    private protected void ShowTargetPosition()
    {
        Debug.Log($"Target position set to {_targetPositionSO.Value}");
        
        GameObject spawnedObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        spawnedObject.GetComponent<Renderer>().material.color = Color.cadetBlue;
        spawnedObject.transform.position = _targetPositionSO.Value;
    }
}