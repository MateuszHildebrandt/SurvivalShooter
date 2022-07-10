using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        public Transform Target { get; set; }
        public EnemyData Data { get; set; }

        private NavMeshAgent _agent;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
        }

        private void FixedUpdate()
        {
            if (Target == null)
                return;

            _agent.destination = Target.position;
        }
    }
}