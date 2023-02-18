public class PlayerStateFactory
{
    PlayerStateManager _contex;

    public PlayerStateFactory(PlayerStateManager currentContex)
    {
        _contex = currentContex;
    }

    public PlayerRunState Run()
    {
        return new PlayerRunState(_contex, this);
    }

    public PlayerJumpState Jump()
    {
        return new PlayerJumpState(_contex, this);
    }

    
}
