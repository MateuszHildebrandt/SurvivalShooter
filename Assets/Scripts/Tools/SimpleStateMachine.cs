using UnityEngine;

namespace State
{
    public class SimpleStateMachine : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] Substate defaultState;

        [Header("Debug")]
        [ReadOnly]
        [SerializeField] Substate currState;

        private void Start()
        {
            if (defaultState != null)
                defaultState.Enter();
        }

        internal void SetState(Substate newState)
        {
            if (newState == null)
                return;

            if (newState == currState)
                return;

            currState?.Exit();
            currState = newState;
        }
    }
}
