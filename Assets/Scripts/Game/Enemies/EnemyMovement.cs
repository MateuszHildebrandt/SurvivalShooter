using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        public float Speed { get; set; }
        public Transform Target { get; set; }


        private Rigidbody2D _rigidbody;
        private NavMeshAgent _agent;
        private float _minDistance = 1;
        private float _distanceToPlayer;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            _agent = GetComponent<NavMeshAgent>();
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
        }

        private void FixedUpdate()
        {
            if (Target == null)
                return;

            _distanceToPlayer = Vector2.Distance(Target.position, transform.position);
            if (_distanceToPlayer > _minDistance)
                ChasePlayer();
            else
                _rigidbody.velocity = new Vector2(0, 0);
        }

        private void ChasePlayer()
        {
            /*Vector2 moveDirection = (Target.position - transform.position).normalized;
            rigidbody.velocity = moveDirection * Speed;*/

            _agent.destination = Target.position;
        }
    }
}