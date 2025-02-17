using UnityEngine;

public class CoinRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;  // You can tweak this in Inspector

    void Update()
    {
        // Rotate around the Y axis, in world space, at rotationSpeed degrees/second
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }
}

