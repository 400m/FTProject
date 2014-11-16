using UnityEngine;
using System.Collections;

public class ButtonEvent : MonoBehaviour {

	// Use this for initialization
	public void changeScene(string scene)
	{
		Application.LoadLevel (scene);
	}
}
