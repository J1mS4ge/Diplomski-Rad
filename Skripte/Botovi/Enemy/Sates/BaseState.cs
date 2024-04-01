public abstract class BaseState
{
    public Enemy enemy;
    public StateMachine stateMasina;
    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();

}