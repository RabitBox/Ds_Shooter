using UnityEngine;
using System.Collections;

public class GamePlayerDChanger : MonoBehaviour {
	private GameManager _GameManager;
	private InputManager _InputManager;
	private GamePlayer _GamePlayer;
	private GameCameraMove _GameCameraMove;

	// Use this for initialization
	void Start () {
		_GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		_InputManager = GameObject.Find("GameManager").GetComponent<InputManager>();
		_GamePlayer = this.gameObject.GetComponent<GamePlayer>();
		_GameCameraMove = GameObject.Find("Main Camera").GetComponent<GameCameraMove>();
	}
	
	// Update is called once per frame
	void Update () {
		if(_GamePlayer.State != PlayerState.Dead && _GameManager.NowMode == NowPlayMode.Play)
		{
			switch(_GamePlayer.State)
			{
			case PlayerState.Phantom:
				ChangeDimension("C");
				break;
				
			case PlayerState.Live:
				ChangeDimension("C");
				break;
			}
		}
	}

	void ChangeDimension(string InputString){
		if(_GameCameraMove.BeforeMode == _GameManager.Dimension){
			if(_InputManager.InputDown(InputString)){
				_GameManager.ChangeDimension();
			}
		}
	}
}
