using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CustomizeCamera : MonoBehaviour {

	public Slider speedSlider, RSpeedSlider;
	public GameObject player;
	Camera myCamera;
	GameObject cameraGameObject;
	public Text speedReadout, RSpeedReadout;
	public Toggle _isOrthographic;

	void Start () 
	{
		myCamera = Camera.main.GetComponent<Camera>();
		cameraGameObject = myCamera.gameObject;

		player.SendMessage("SpeedEdit", speedSlider.value);
		player.SendMessage("RSpeedEdit", RSpeedSlider.value);
	}

	void Update () 
	{

		speedReadout.text = "SPEED : " + speedSlider.value.ToString("0.0");
		RSpeedReadout.text = "ROTATION SPEED : " + RSpeedSlider.value.ToString("0.00000");

		if(Input.GetKeyDown(KeyCode.R))
			Application.LoadLevel(Application.loadedLevel);
	}

	public void SetSpeed()
	{
		player.SendMessage("SpeedEdit", speedSlider.value);
	}

	public void SetRSpeed()
	{
		player.SendMessage("RSpeedEdit", RSpeedSlider.value);
	}

	public void Load(int num)
	{
		Application.LoadLevel(num);
	}

	public void OrthographicChange()
	{
		myCamera.orthographic = !myCamera.orthographic;
	}
}
