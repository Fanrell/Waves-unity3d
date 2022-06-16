namespace Entities.Base
{
    public class BaseEnemy : BaseEntity
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public override void Move(float horizontal, float vertical)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public override void Rotate()
        {
            throw new System.NotImplementedException();
        }
    }
}
