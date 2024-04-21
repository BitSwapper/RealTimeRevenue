namespace WinForms_Pay_Timer;

public class StateManager
{
    public enum States { InitialzingProgram, Started, InitNewJob, Paused, Completed, Reset }
    States currentState = States.InitialzingProgram;

    public FormMain Form { get; }

    public StateManager(FormMain form) => this.Form = form;

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
        concreteStates[currentState].ExitState(this);
        currentState = state;
        concreteStates[currentState].EnterState(this);
    }

    public void UpdateState() => concreteStates[currentState].UpdateState(this);
}
