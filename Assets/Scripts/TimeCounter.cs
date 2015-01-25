using UnityEngine;
using System.Collections;

public class TimeCounter : MonoBehaviour {

	private GUIText text;

	void Start () {
		text = GetComponent<GUIText>();
		//text.pixelOffset = Vector2.zero;
		//text.pixelOffset = new Vector2(Screen.width, Screen.height);
	}
	
	void Update () {
		text.text = formatTime(Time.time);
	}

	private string formatTime(float timeInSeconds, bool showMS = false)
	{
		int playTime = (int)timeInSeconds;
		//int hrs = playTime / 3600;
		//int mins = (playTime % 3600) / 60;
		int mins = playTime / 60;
		int secs = playTime % 60;
		int ms = 0;
		if (showMS)
		{
			playTime = (int)(timeInSeconds * 1000);
			ms = playTime % 1000;
		}

		string fTime = string.Format("{0:00}:{1:00}", mins, secs);
		/*if (hrs != 0)
		{
			fTime = string.Format("{0:00}:{1:00}:{2:00}", hrs, mins, secs);
		}
		else if (mins != 0)
		{
			fTime = string.Format("{0:00}:{1:00}", mins, secs);
		}*/
		if (showMS)
		{
			fTime = string.Format("{0}:{1:000}", fTime, ms);
		}

		return fTime;
	}
}
