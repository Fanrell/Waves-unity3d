using UnityEngine;

namespace Entities.Base
{
    public interface IBaseEntity
    {
        public float HitPoints { get; set; }
        public float Cooldown { get; set; }
        public float Speed { get; set; }
        public EntityStatusEnum Status { get; set; }
        public ElementalEnum Elemental { get; set; }

        public void Move(float horizontal, float vertical);
        public void Attack();
        public void Death();
    }
}
