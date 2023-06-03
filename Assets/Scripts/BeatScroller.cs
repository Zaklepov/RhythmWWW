using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float speed;

    public bool hasStarted;

    void Start()
    {
        speed /= 60f;
    }

    void Update()
    {
        if (hasStarted)
        {
            transform.position -= new Vector3(0f, speed * Time.deltaTime, 0f);
        }
    }
}
