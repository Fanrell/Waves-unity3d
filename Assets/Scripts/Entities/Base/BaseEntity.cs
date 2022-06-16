using Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace Entities.Base
{
    public abstract class BaseEntity : MonoBehaviour
    {
        [FormerlySerializedAs("HitPoints")] 
        public float hitPoints;
        [FormerlySerializedAs("Cooldown")] 
        public float cooldown;
        [FormerlySerializedAs("Speed")] 
        public float speed;
        [FormerlySerializedAs("Status")] 
        public EntityStatusEnum status;
        [FormerlySerializedAs("Elemental")] 
        public ElementalEnum elemental;

        public abstract void Move(float horizontal, float vertical);
        public abstract void Attack();
        public abstract void Death();
    }
}
