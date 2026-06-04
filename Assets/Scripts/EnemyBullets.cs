using UnityEngine;

public class EnemyBullets : Bullets
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Entity entity = other.GetComponent<Entity>();

            if (entity != null)
            {
                entity.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
