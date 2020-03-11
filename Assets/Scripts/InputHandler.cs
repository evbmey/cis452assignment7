using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public void Awake()
    {
        commands = new LimitedSizeStack<Command>(stackSize);
    }

    void Update()
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            MovementCommand command = new MovementCommand(receiver, movement * receiver.Speed * Time.deltaTime);
            command.Execute();

            commands.Push(command);
        }
        else
        {
            if (commands.Count > 0) commands.Pop()?.Undo();
        }
    }

    [SerializeField] private ObjectMover receiver;
    [SerializeField] private int stackSize;
    private LimitedSizeStack<Command> commands;

}

public class LimitedSizeStack<T> : LinkedList<T>
{
    public LimitedSizeStack(int maxSize)
    {
        this.maxSize = maxSize;
    }

    public void Push(T item)
    {
        this.AddFirst(item);

        if (this.Count > maxSize)
        {
            this.RemoveLast();
        }
    }

    public T Pop()
    {
        var item = this.First.Value;
        this.RemoveFirst();
        return item;
    }

    private readonly int maxSize;
}

