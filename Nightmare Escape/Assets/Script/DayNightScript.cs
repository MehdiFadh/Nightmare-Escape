using UnityEngine;

public class DayNightScript : MonoBehaviour
{
    
    public float rotationSpeed = 10f;

    void Update()
    {
        
        float rotationThisFrame = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector2.right, rotationThisFrame);
    }
}
