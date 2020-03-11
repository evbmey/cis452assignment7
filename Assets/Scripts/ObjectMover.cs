using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ObjectMover : MonoBehaviour, IMoveable
{

    public void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 movement)
    {
        rigidbody.MovePosition(Position + movement);
    }

    private new Rigidbody2D rigidbody;
    [SerializeField] private float speed;
    public float Speed => speed;
    public Vector2 Position => gameObject.transform.position;

}
