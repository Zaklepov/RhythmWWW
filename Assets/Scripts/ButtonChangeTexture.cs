using UnityEngine;

public class ButtonChangeTexture : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite defImage;
    public Sprite changedImage;

    public KeyCode keyToPress;

    public AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            sr.sprite = changedImage;
            audioPlayer.Play();
        }

        if (Input.GetKeyUp(keyToPress))
        {
            sr.sprite = defImage;
        }
    }
}
