using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] public int maxHp;
    private int curHp;
    private void Start()
    {
        curHp = maxHp;
    }

    public void TakeDamage(int damage)
    {
        curHp -= damage;
        if (curHp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
