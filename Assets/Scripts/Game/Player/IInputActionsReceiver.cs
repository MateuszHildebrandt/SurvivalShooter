namespace Player
{
    public interface IInputActionsReceiver
    {
        public InputActions InputActions { get; }
        public void SetInputActions(InputActions inputs);
    }
}