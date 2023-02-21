using UnityEngine;

public class SimpleSpin : MonoBehaviour
{
    public Vector3 spinAxis = Vector3.up;
    public float spinSpeed = 1f;

    private void Update()
    {
        transform.Rotate(spinAxis, spinSpeed);
    }
}
