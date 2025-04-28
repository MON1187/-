public interface InBuffe
{
    public void In_OutBuffe(int buffeIndex, float durationTime);
}
public interface IDamageball
{
    public void Damageball(float damaged);
    void Died();
}

public interface Movement
{
    public float MoveSpeed { get; set; }
    public float JumpForce { get; set; }
    public void MoveHandler(float moveSpeed);

    public void Jumping(float jumpForce);

}