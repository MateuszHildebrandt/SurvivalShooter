using UnityEngine;

namespace State
{
    public interface IStateExtension
    {
        internal void OnEnter();
        internal void OnExit();
    }

    public class Substate : MonoBehaviour
    {
        private bool isDebug = false;

        private SimpleStateMachine _myStateMachine;
        private SimpleStateMachine MyStateMachine
        {
            get
            {
                if (_myStateMachine == null)
                    _myStateMachine = GetComponentInParent<SimpleStateMachine>();
                return _myStateMachine;
            }
        }

        private IStateExtension[] _myStateExtension;
        private IStateExtension[] MyStateExtension
        {
            get
            {
                if (_myStateExtension == null)
                    _myStateExtension = GetComponentsInChildren<IStateExtension>();
                return _myStateExtension;
            }
        }

        [ExposeMethodInEditor]
        public void Enter()
        {
            MyStateMachine.SetState(this);
            foreach (IStateExtension item in MyStateExtension)
                item.OnEnter();

            PrintStateName();
        }

        public void Exit()
        {
            foreach (IStateExtension item in MyStateExtension)
                item.OnExit();
        }

        private void PrintStateName()
        {
            if(isDebug)
                Debug.Log($"Enter state: {gameObject.name}", this);
        }
    }
}
