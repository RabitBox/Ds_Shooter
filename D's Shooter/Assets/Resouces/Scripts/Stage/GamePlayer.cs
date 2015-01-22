using UnityEngine;
using System.Collections;

// プレイヤーのステイト
enum PlayerState{
	Live,		// 生
	Dead,		// 死
	Phantom,	// ゴースト
};

public class GamePlayer : MonoBehaviour {
	private GameManager _GameManager;
	private InputManager _InputManager;
	private PlayerState _State = PlayerState.Phantom;

	// Use this for initialization
	void Start () {
		_GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		_InputManager = GameObject.Find("GameManager").GetComponent<InputManager>();
	}
	
	// Update is called once per frame
	void Update () {
		// プレイモードで死亡していない場合
		if(_GameManager.NowMode == NowPlayMode.Play && _State != PlayerState.Dead){

		}
	}
}
