using UnityEngine;

public class MovementCommand : Command
{
    public MovementCommand(IMoveable receiver, Vector2 movement)
    {
        this.receiver = receiver;
        this.movement = movement;
    }

    public override void Execute()
    {
        receiver.Move(movement);
    }

    public override void Undo()
    {
        receiver.Move(-movement);
    }

    private IMoveable receiver;
    private Vector2 movement;
}
