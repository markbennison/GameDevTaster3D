using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI scoreUI;

	int score = 0;

	void IncrementScore()
	{
		score++;
		scoreUI.text = score.ToString();
	}
}
