using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI countdownUI;

    public float countdownTotal = 20f;

    float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        time = countdownTotal;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= 1 * Time.deltaTime;
            countdownUI.text = SecondsToTimeString(time);
		}
		else
		{
            Debug.Log("End Game.");
            Time.timeScale = 0f;
        }
    }

    string SecondsToTimeString(float secondsOnly)
	{
        int minutes = (int) secondsOnly / 60;
        int seconds = (int) (secondsOnly % 60);

        return minutes + ":" + seconds.ToString("00");
    }
}
