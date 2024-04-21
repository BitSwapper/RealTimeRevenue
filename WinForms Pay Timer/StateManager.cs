namespace WinForms_Pay_Timer;

public class StateManager
{
    public enum States { Started, Paused, Completed, Reset }
    States currentState = States.Completed;

    Dictionary<States, BaseState<StateManager>> concreteStates = new()
    {
        {States.Started, new State_Started() },
        {States.Paused, new State_Paused() },
        {States.Completed, new State_Completed() },
        {States.Reset, new State_Reset()}
    };

    public void Initialize() => concreteStates[currentState].EnterState(this);
}

public class State_Started : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager) { }
    public override void ExitState(StateManager stateManager) { }
    public override void FixedUpdateState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}

public class State_Paused : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager) { }
    public override void ExitState(StateManager stateManager) { }
    public override void FixedUpdateState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}

public class State_Completed : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager) { }
    public override void ExitState(StateManager stateManager) { }
    public override void FixedUpdateState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}

public class State_Reset : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager) { }
    public override void ExitState(StateManager stateManager) { }
    public override void FixedUpdateState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}