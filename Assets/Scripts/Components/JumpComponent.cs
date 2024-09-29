using UnityEngine;
using Zenject;

namespace Components
{
    public sealed class JumpComponent : MonoBehaviour
    {
 
        [SerializeField] private float powerJump = 1000f;
        private Rigidbody _rg;
        private CapsuleCollider2D _capsuleCollider2D;
        private bool _isGrounded;

        [Inject]
        public void Construct(Rigidbody rb) => _rg = rb;

        public void Jump()
        {
            _rg.velocity = new Vector2(_rg.velocity.x, 0f);
            _rg.AddForce(Vector3.up * powerJump, ForceMode.Impulse);
        }
    }
}