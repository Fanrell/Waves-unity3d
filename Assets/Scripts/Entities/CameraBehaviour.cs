using UnityEngine;

namespace Entities
{
    public class CameraBehaviour : MonoBehaviour
    {
        public float speed;
        public Transform trackingObject;
        private Vector3 _initialOffset;
        private Vector3 _cameraPosition;

        private void Start()
        {
            _initialOffset = transform.position - trackingObject.position;
        }

        public void Update()
        {
            _cameraPosition = trackingObject.position + _initialOffset;
            transform.position = Vector3.Lerp(transform.position, _cameraPosition, speed * Time.deltaTime);
        }
    }
}