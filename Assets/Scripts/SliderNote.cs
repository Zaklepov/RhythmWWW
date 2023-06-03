using UnityEngine;

public class SliderNote : MonoBehaviour
{
    public bool canBeHold;
    public bool noteHasGone = false;

    public KeyCode keyToHold;

    public float startTime;
    public float timeToHold = 0;
    public float TimeForNormal, TimeForGood, TimeForPerfect, TimeForMiss;

    public GameObject PerfectEffect, NormalEffect, GoodEffect, MissEffect;
    void Start()
    {

    }

    void Update()
    {
        if (canBeHold)
        {
            noteHasGone = true;
            if (Input.GetKeyDown(keyToHold))
            {
                startTime = Time.time;
            }
            if (Input.GetKeyUp(keyToHold))
            {
                timeToHold += Time.time - startTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBeHold = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBeHold = false;
            if (timeToHold < TimeForMiss)
            {
                Debug.Log("Miss");
                GameManager.instance.NoteMiss();
                Instantiate(MissEffect);
            }
            else if (timeToHold < TimeForPerfect && timeToHold > TimeForGood)
            {
                Debug.Log("Perfect");
                GameManager.instance.PerfectHoldHit();
                Instantiate(PerfectEffect);
            }
            else if (timeToHold < TimeForGood && timeToHold > TimeForNormal)
            {
                Debug.Log("Good");
                GameManager.instance.GoodHoldHit();
                Instantiate(GoodEffect);
            }
            else if (timeToHold > TimeForMiss && timeToHold < TimeForNormal)
            {
                Debug.Log("Normal");
                GameManager.instance.NormalHoldHit();
                Instantiate(NormalEffect);
            }
        }
    }
}
