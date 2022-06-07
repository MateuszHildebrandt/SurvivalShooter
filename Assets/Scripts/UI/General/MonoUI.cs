
namespace UI
{
    [UnityEngine.RequireComponent(typeof(State.Substate))]
    public abstract class MonoUI<T> : UnityEngine.MonoBehaviour where T : UnityEngine.MonoBehaviour
    {
        public static T I { get; private set; }

        private State.Substate _myState;
        protected State.Substate MyState
        {
            get
            {
                if (_myState == null)
                    _myState = GetComponent<State.Substate>();
                return _myState;
            }
        }

        protected virtual void Awake()
        {
            if (I == null)
                I = this as T;
        }

        internal void EnterState() => MyState.Enter();
    }
}
