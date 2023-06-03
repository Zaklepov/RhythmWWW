using UnityEngine;

public class NotePress : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;
    public GameObject PerfectEffect, NormalEffect, GoodEffect, MissEffect;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)

            {
                gameObject.SetActive(false);

                if (transform.position.y > 0.6 || transform.position.y < -0.34)
                {
                    Debug.Log("Normal");
                    GameManager.instance.NormalHit();
                    Instantiate(NormalEffect);
                }
                else if (transform.position.y > 0.5 || transform.position.y < -0.24)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(GoodEffect);
                }
                else
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    Instantiate(PerfectEffect);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
            if (gameObject.activeSelf)
            {
                GameManager.instance.NoteMiss();
                Instantiate(MissEffect);
            }
        }
    }
}
