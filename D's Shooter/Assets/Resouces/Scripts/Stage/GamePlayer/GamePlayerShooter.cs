using UnityEngine;
using System.Collections;

public class GamePlayerShooter : MonoBehaviour {
	private GameManager _GameManager;
	private InputManager _InputManager;
	private GamePlayer _GamePlayer;

	// Use this for initialization
	void Start () {
		_GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		_InputManager = GameObject.Find("GameManager").GetComponent<InputManager>();
		_GamePlayer = this.gameObject.GetComponent<GamePlayer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(_GamePlayer.State != PlayerState.Dead && _GameManager.NowMode == NowPlayMode.Play)
		{
			switch(_GamePlayer.State)
			{
			case PlayerState.Phantom:
				CreateShot("A");
				break;
				
			case PlayerState.Live:
				CreateShot("A");
				break;
			}
		}
	}

	void CreateShot(string InputString){
		if(_InputManager.InputStay(InputString)){
			Debug.Log("Shot Criating!");
		}
	}

	/*void CreateBomb(string InputString){
		if(_InputManager.InputStay(InputString)){
		}
	}//*/
}
