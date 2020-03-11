
public class AttackCommand : Command
{
    public AttackCommand(IAttacker receiver, IDamageable target)
    {
        this.receiver = receiver;
        this.target = target;
    }

    public override void Execute()
    {
        receiver.Attack(target);
    }

    public override void Undo()
    { }

    private IAttacker receiver;
    private IDamageable target;
}
