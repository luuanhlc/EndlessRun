public abstract class PlayerBaseState
{
    protected bool _isRootState = false;

    private PlayerStateManager _ctx;
    private PlayerStateFactory _factory;

    private PlayerBaseState _currentState;
    private PlayerBaseState _subState;

    public bool IsRootState { get { return _isRootState; } set { _isRootState = value; } }
    public PlayerStateManager Ctx;
    public PlayerStateFactory Factory;

    public PlayerBaseState(PlayerStateManager currentContex, PlayerStateFactory stateFactory)
    {
        _ctx = currentContex;
        _factory = stateFactory;
    }

    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract void CheckSwitchState();
    public abstract void InitSubState();
    protected void SwitchState()
    {

    }
}
