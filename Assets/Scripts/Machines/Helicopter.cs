using UnityEngine;

public class Helicopter : Entity
{
    protected override void Die()
    {
        Destroy(gameObject);
    }
}
