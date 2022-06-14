using UnityEngine;

namespace State
{
    public interface IStateEnter
    {
        internal void OnEnter();
    }

    public interface IStateExit
    {
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

        private IStateEnter[] _statesEnter;
        private IStateEnter[] StatesEnter
        {
            get => GetIStates(ref _statesEnter);
        }

        private IStateExit[] _statesExit;
        private IStateExit[] StatesExit
        {
            get => GetIStates(ref _statesExit);
        }

        private T[] GetIStates<T>(ref T[] states)
        {
            if (states == null)
                states = GetComponentsInChildren<T>();
            return states;
        }

        [ExposeMethodInEditor]
        public void Enter()
        {
            MyStateMachine.SetState(this);
            foreach (IStateEnter item in StatesEnter)
                item.OnEnter();

            PrintStateName();
        }

        public void Exit()
        {
            foreach (IStateExit item in StatesExit)
                item.OnExit();
        }

        private void PrintStateName()
        {
            if(isDebug)
                Debug.Log($"Enter state: {gameObject.name}", this);
        }
    }
}
