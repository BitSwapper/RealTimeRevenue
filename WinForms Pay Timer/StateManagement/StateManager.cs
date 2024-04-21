namespace RealTime_Revenue.StateManagement;

public class StateManager
{
    public enum States { InitialzingProgram, Started, InitNewJob, Paused, Completed, Reset }
    public States CurrentState { get; private set; } = States.InitialzingProgram;

    public FormMain Form { get; }

    public StateManager(FormMain form) => Form = form;

    Dictionary<States, BaseState<StateManager>> concreteStates = new()
    {
        {States.Started, new State_Started() },
        {States.InitialzingProgram, new State_InitProgram() },
        {States.InitNewJob, new State_InitNewJob() },
        {States.Paused, new State_Paused() },
        {States.Completed, new State_Completed() },
        {States.Reset, new State_Reset()}
    };

    public void SwapState(States state)
    {
        concreteStates[CurrentState].ExitState(this);
        CurrentState = state;
        concreteStates[CurrentState].EnterState(this);
    }

    public void UpdateState() => concreteStates[CurrentState].UpdateState(this);
}
