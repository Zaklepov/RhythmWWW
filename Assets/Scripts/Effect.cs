using UnityEngine;

public class Effect : MonoBehaviour
{
    public float lifetime = 1f;

    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
