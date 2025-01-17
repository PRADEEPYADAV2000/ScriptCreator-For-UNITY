using UnityEngine;
using TMPro;
public class SpriteRotator : MonoBehaviour
{
    public float rotationSpeed = 360f; // Degrees per second

    void Update()
    {
        // Rotate the sprite around its own Z-axis
        float rotationStep = rotationSpeed * Time.deltaTime;
        transform.Rotate(0f, rotationStep, 0f);
    }
}
