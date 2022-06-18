using System;
using Attacks;
using Entities.Base;
using UnityEngine;

namespace Entities
{
    public class PlayerBehaviour : BaseEntity
    {
        public GameObject bullet;
        
        private float _horizontal;
        private float _vertical;
        private int _rotate;
        private byte _speed;
        private float _stamina;
        private byte _hitPoint;
        private BaseBullet _baseBullet;

        void Start()
        {
            _horizontal = 0;
            _vertical = 0;
            _hitPoint = maxHitPoints;
            _stamina = maxStamina;
            _baseBullet = attack.GetComponent(typeof(BaseBullet)) as BaseBullet;

        }

        void Update()
        {
            ReadInput();
            if(_horizontal != 0 || _vertical != 0)
                Move(_horizontal , _vertical);
            Rotate();
        }

        private void LateUpdate()
        {
            Regeneration();
            if(_hitPoint <= 0)
                Death();
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
            _baseBullet.direction = transform.up;
            _baseBullet.startPosition = transform.position;
            Instantiate(attack, null, true);
        }

        public override void Death() //TODO change to take DMG method
        {
            Destroy(this.gameObject,Time.deltaTime); //TODO trigger only when HP below or equal 0
        }

        public override void Regeneration()
        {
            _stamina += (_speed - maxSpeed == 0 && _stamina < maxStamina ? .2f : 0f) * Time.deltaTime;
        }

        public override void Rotate()
        {
            transform.rotation= Quaternion.Euler(new Vector3(0,0,_rotate));
        }

        private void ReadInput()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
            _speed = (byte)(
                    (Input.GetButton($"Dash") && _stamina > 0.5 ? maxSpeed * 3 : maxSpeed * 1)
                );
            //TODO: Change input manager to use only two read input
            if (Input.GetButton($"FireUp"))
            {
                _rotate = 0;
                Attack();
            }
            else if (Input.GetButton($"FireLeft"))
            {
                _rotate = 90;
                Attack();
            }
            else if (Input.GetButton($"FireRight"))
            {
                _rotate = 270;
                Attack();
            }
            else if (Input.GetButton($"FireDown"))
            {
                _rotate = 180;
                Attack();

            }

            _hitPoint -= Input.GetButton("Cancel") ? (byte)maxHitPoints : (byte)0;
        }
    }
}
