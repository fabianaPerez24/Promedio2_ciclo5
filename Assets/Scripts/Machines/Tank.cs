using UnityEngine;
using UnityEngine.SceneManagement;

public class Tank : Entity
{
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
