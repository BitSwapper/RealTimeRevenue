namespace RealTime_Revenue.StateManagement;

public abstract class BaseState<T>
{
    public abstract void EnterState(T stateManager);
    public abstract void UpdateState(T stateManager);
    public abstract void ExitState(T stateManager);
}
