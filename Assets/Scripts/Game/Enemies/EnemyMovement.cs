using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        public float Speed { get; set; }
        public Transform Target { get; set; }

        private float minDistance = 1;

        private Rigidbody2D rigidbody;
        private NavMeshAgent _agent;
        private float distanceToPlayer;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();

            _agent = GetComponent<NavMeshAgent>();
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
        }

        private void FixedUpdate()
        {
            if (Target == null)
                return;

            distanceToPlayer = Vector2.Distance(Target.position, transform.position);
            if (distanceToPlayer > minDistance)
                ChasePlayer();
            else
                rigidbody.velocity = new Vector2(0, 0);
        }

        private void ChasePlayer()
        {
            /*Vector2 moveDirection = (Target.position - transform.position).normalized;
            rigidbody.velocity = moveDirection * Speed;*/

            _agent.destination = Target.position;
        }
    }
}