using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] public  int damage = 10;
    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Entity entity = other.GetComponent<Entity>();

            if (entity != null)
            {
                entity.TakeDamage(10);
            }

            Destroy(gameObject);
        }
    }
}
