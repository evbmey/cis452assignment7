
public interface IAttacker 
{
    float Strength { get; }
    void Attack(IDamageable target);
}
