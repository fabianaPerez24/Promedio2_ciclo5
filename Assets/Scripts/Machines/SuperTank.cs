using UnityEngine;
using UnityEngine.UIElements;

public class SuperTank : Tank
{

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
