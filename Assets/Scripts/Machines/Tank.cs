using UnityEngine;
using UnityEngine.SceneManagement;

public class Tank : Entity
{
    [SerializeField] private Transform enemyBase;
    [SerializeField] private float speed = 3f;

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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerFortress"))
        {
            GetComponent<ChangeScenes>();
            SceneManager.LoadScene("Victory");
        }
    }
}
