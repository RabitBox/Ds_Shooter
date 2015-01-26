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
	private int PhantomTimer = 0;
	[SerializeField] int PhantomTime = 120;

	// Use this for initialization
	void Start () {
		_GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		_InputManager = GameObject.Find("GameManager").GetComponent<InputManager>();
	}
	
	// Update is called once per frame
	void Update () {
		// プレイモードで死亡していない場合
		if(_GameManager.NowMode == NowPlayMode.Play && _State != PlayerState.Dead){
			switch(_State)
			{
			case PlayerState.Phantom:	// ゴースト
				if(PhantomTimer > 0){
					PhantomTimer--;
				}else{
					_State = PlayerState.Live;
				}
			case PlayerState.Live:		// 生存
				if(PhantomTimer > 0) _State = PlayerState.Phantom;
				Move ();
				Shot ();
				break;

			case PlayerState.Dead:		// 死亡
				// 未実装
				break;
			}
		}
	}

	void Move(){

	}

	void Shot(){

	}
}
