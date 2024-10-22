using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] public int hp;
    private void Start()
    {
        hp = 2;
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
