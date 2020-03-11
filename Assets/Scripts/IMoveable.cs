using UnityEngine;

public interface IMoveable
{
    float Speed { get; }
    Vector2 Position { get; }
    void Move(Vector2 movement);
}
