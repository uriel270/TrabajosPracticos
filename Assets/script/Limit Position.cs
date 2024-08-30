using UnityEngine;

public class LimitarPosicion : MonoBehaviour
{
    public float xMin = -8.0f;
    public float xMax = 8.0f;
    public float yMin = -4.0f;
    public float yMax = 4.0f;

    void Update()
    {
        Vector3 posicion = transform.position;

        posicion.x = Mathf.Clamp(posicion.x, xMin, xMax);
        posicion.y = Mathf.Clamp(posicion.y, yMin, yMax);

        transform.position = posicion;
    }
}