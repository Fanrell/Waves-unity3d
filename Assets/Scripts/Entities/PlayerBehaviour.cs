using Entities.Base;
using UnityEngine;

namespace Entities
{
    public class PlayerBehaviour : BaseEntity
    {
        private float _horizontal;
        private float _vertical;

        void Start()
        {
            _horizontal = 1;
            _vertical = 0;
            speed = 5;
        }

        void Update()
        {
            ReadInput();
            if(_horizontal != 0 || _vertical != 0)
                Move(_horizontal , _vertical);
        }

        public override void Move(float horizontal, float vertical)
        {
            var currentPosition = transform.position;
            var newPosition = currentPosition + new Vector3(horizontal, vertical);
            transform.position = Vector3.LerpUnclamped(currentPosition, newPosition, Time.deltaTime * speed);
        }

        public override void Attack()
        {
            throw new System.NotImplementedException();
        }

        public override void Death()
        {
            throw new System.NotImplementedException();
        }

        private void ReadInput()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
        }
    }
}
