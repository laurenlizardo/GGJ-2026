using UnityEngine;
using System.Collections.Generic;

namespace LaurenLizardo.ToTheMasquerade
{
    public class CameraSwitcher : MonoBehaviour
    {
        public List<Camera> Cameras = new List<Camera>();
    
        private void Start()
        {
            EnableCamera(Camera.main);
        }
        
        public void EnableCamera(Camera camera)
        {
            for (int i = 0; i < Cameras.Count; i++)
            {
                if (Cameras[i] == camera)
                    Cameras[i].enabled = true;
                else
                    Cameras[i].enabled = false;
            }
        }
    
        public void EnableCamera(string cameraName)
        {
            for (int i = 0; i < Cameras.Count; i++)
            {
                if (Cameras[i].gameObject.name == cameraName)
                    Cameras[i].enabled = true;
                else
                    Cameras[i].enabled = false;
            }
        }
    }
}