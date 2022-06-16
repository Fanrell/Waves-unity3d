using JetBrains.Annotations;
using UnityEngine;

namespace Entities
{
    public class CameraBehaviour : MonoBehaviour
    {
        public float speed;
        [CanBeNull] public Transform trackingObject;
        private Vector3 _initialOffset;
        private Vector3 _cameraPosition;

        private void Start()
        {
            if (trackingObject != null) _initialOffset = transform.position - trackingObject.position;
        }

        public void Update()
        {
            if (trackingObject != null)
            {
                _cameraPosition = trackingObject.position + _initialOffset;
                transform.position = Vector3.Lerp(transform.position, _cameraPosition, speed * Time.deltaTime);
                
            }

        }
    }
}