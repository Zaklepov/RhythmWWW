using UnityEngine;

public class SaveChange : MonoBehaviour
{
    public GameObject Enter;
    public GameObject Menu;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Save") != 1)
        {
            Enter.SetActive(true);
            Menu.SetActive(false);
        }
        else
        {
            Enter.SetActive(false);
            Menu.SetActive(true);
        }
    }
    public void Save()
    {
        PlayerPrefs.SetInt("Save", 1);
    }
}

