public abstract class BaseState
{
    public Enemy enemy;
    public Gun gun;
    public StateMachine stateMachine;
    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();
}