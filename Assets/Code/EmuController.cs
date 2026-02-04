using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using LaurenLizardo.ToTheMasquerade.EventSystem;

namespace LaurenLizardo.ToTheMasquerade
{
     public class EmuController : MonoBehaviour
     {
          private NavMeshAgent _navMeshAgent;
          [SerializeField] private Vector3 _destination;
          [SerializeField] private GameObject _llama;
          [SerializeField] private bool _mouseOnLlama;
          
          public VoidEventChannel OnLlamaClicked;
          public VoidEventChannel OnLlamaReached;
     
          private Camera _camera;
          
          private void Start()
          {
               _navMeshAgent = GetComponent<NavMeshAgent>();
               _destination = transform.position;
               _camera = Camera.main;
          }
          
          private void Update()
          {
               if (CalculateDistanceTo(_llama) <= _navMeshAgent.stoppingDistance && !_navMeshAgent.isStopped)
               {
                    Debug.Log($"Remaining distance: {_navMeshAgent.remainingDistance}");
                    Debug.Log($"Stopping distance: {_navMeshAgent.stoppingDistance}");
                    Debug.Log($"Is stopped: {_navMeshAgent.isStopped}");
                    OnLlamaReached.Raise();
               }
          }
     
          // Left mouse button click
          public void CheckForLlama(InputAction.CallbackContext context)
          {
               // Check if mouse is on llama
               // Allow emu to move to llama if mouse is on llama then clicked.
               
               if (context.performed && _mouseOnLlama)
                    OnLlamaClicked.Raise();
          }
          
          // Mouse position
          public void TrackMousePosition(InputAction.CallbackContext context)
          {
               if (_camera != null)
               {
                    Ray ray = _camera.ScreenPointToRay(context.ReadValue<Vector2>());
     
                    if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
                    {
                         Debug.Log(hit.collider.gameObject.name);
                    
                         if (hit.collider.gameObject.name == _llama.name)
                         {
                              _mouseOnLlama = true;
                              return;
                         }
                         _mouseOnLlama = false;
                    }
               }
          }
     
          public void MoveToLlama()
          {
               _destination = new Vector3(_llama.transform.position.x, transform.position.y, _llama.transform.position.z);
               _navMeshAgent.SetDestination(_destination);
          }
     
          public void StopMoving()
          {
               _navMeshAgent.isStopped = true;
          }
     
          private float CalculateDistanceTo(GameObject go)
          {
               return Vector3.Distance(transform.position, go.transform.position);
          }
     }
}