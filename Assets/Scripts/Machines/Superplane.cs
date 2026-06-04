using UnityEngine;

public class Superplane : Entity
{
    protected override void Die()
    {
        Destroy(gameObject);
    }
}
