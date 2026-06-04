using UnityEngine;
using UnityEngine.UIElements;

public class SuperTank : Tank
{
    [SerializeField] private Transform enemyBase;
    [SerializeField] private float speed = 4f;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            enemyBase.position,
            speed * Time.deltaTime);
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}
