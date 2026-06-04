using UnityEngine;

public class AIShop : MonoBehaviour
{
    [SerializeField] private GameObject tankPrefab;
    [SerializeField] private Transform spawnPoint;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 10f)
        {
            BuyTank();
            timer = 0;
        }
    }

    private void BuyTank()
    {
        Instantiate(
            tankPrefab,
            spawnPoint.position,
            spawnPoint.rotation);
    }
}
