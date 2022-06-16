using System;
using Entities.Base;
using UnityEngine;

namespace Entities
{
    public class PlayerBehaviour : BaseEntity
    {
        private float _horizontal;
        private float _vertical;
        private byte _speed;
        private float _stamina;

        void Start()
        {
            _horizontal = 0;
            _vertical = 0;
            _stamina = maxStamina;
            maxSpeed = 5;
        }

        void Update()
        {
            ReadInput();
            if(_horizontal != 0 || _vertical != 0)
                Move(_horizontal , _vertical);
        }

        private void LateUpdate()
        {
            Regeneration();
        }

        public override void Move(float horizontal, float vertical)
        {
            var currentPosition = transform.position;
            var newPosition = currentPosition + new Vector3(horizontal, vertical);
            transform.position = Vector3.LerpUnclamped(
                currentPosition,
                newPosition, 
                Time.deltaTime * _speed);
            var newStamina= _stamina - ( (_speed > maxSpeed ? .8f : 0f) * Time.deltaTime);
            _stamina = Mathf.Max(newStamina, 0);
        }

        public override void Attack()
        {
            throw new System.NotImplementedException();
        }

        public override void Death()
        {
            throw new System.NotImplementedException();
        }

        public override void Regeneration()
        {
            _stamina += (_speed - maxSpeed == 0 && _stamina < maxStamina ? .2f : 0f) * Time.deltaTime;
        }

        private void ReadInput()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
            _speed = (byte)(
                    (Input.GetButton($"Dash") && _stamina > 0.5 ? maxSpeed * 3 : maxSpeed * 1)
                );
        }
    }
}
