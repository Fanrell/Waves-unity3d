using Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace Entities.Base
{
    public abstract class BaseEntity : MonoBehaviour
    {
        [FormerlySerializedAs("HitPoints")] 
        public float maxHitPoints;
        [FormerlySerializedAs("Cooldown")] 
        public float maxCooldown;
        [FormerlySerializedAs("Speed")] 
        public float maxSpeed;        
        [FormerlySerializedAs("Stamina")] 
        public float maxStamina;
        [FormerlySerializedAs("Status")] 
        public EntityStatusEnum status;
        [FormerlySerializedAs("Elemental")] 
        public ElementalEnum elemental;

        public abstract void Move(float horizontal, float vertical);
        public abstract void Attack();
        public abstract void Death();
        public abstract void Regeneration();
    }
}
