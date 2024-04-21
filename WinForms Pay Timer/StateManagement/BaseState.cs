namespace WinForms_Pay_Timer.StateManagement;

public abstract class BaseState<T>
{
    public abstract void EnterState(T stateManager);
    public abstract void UpdateState(T stateManager);
    public abstract void ExitState(T stateManager);
}
