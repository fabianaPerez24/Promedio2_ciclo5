using UnityEngine;

 public class ShopManager : MonoBehaviour
 {
        [SerializeField] private GameObject tankPrefab;
        [SerializeField] private Transform spawnPoint;

        public void BuyTank()
        {
            int cost = 100;

            if (GameManager.Instance.playerMoney >= cost)
            {
                GameManager.Instance.playerMoney -= cost;

                Instantiate(
                    tankPrefab,
                    spawnPoint.position,
                    spawnPoint.rotation);
            }
        }
 }

