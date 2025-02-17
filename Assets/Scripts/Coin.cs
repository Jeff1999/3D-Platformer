using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue = 1; // The amount of score to add

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is tagged "Player"
        if (other.CompareTag("Player"))
        {
            // 1) Add to score in GameManager (you'll see code for GameManager below)
            GameManager.Instance.AddScore(coinValue);

            // 2) Destroy the coin object
            Destroy(gameObject);
        }
    }
}

