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
	[SerializeField] private int PhantomTime = 120;
	[SerializeField] private float Speed = 5f;

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
				Action();
				break;

			case PlayerState.Live:		// 生存
				if(PhantomTimer > 0) _State = PlayerState.Phantom;
				Action();
				break;

			case PlayerState.Dead:		// 死亡
				// 未実装
				break;
			}
		}
	}

	//--------------------------------------------------
	//--------------------------------------------------
	// 行動系管理
	void Action(){
		Move ();
		Revise();
		Shot ();
	}

	// 移動
	void Move(){
		Vector2 dir = _InputManager.Direction() * Speed;
		switch(_GameManager.Dimension){
		case DimensionMode.Mode2D:
			this.rigidbody.velocity = new Vector3(dir.x, 0f, dir.y);
			break;

		case DimensionMode.Mode3D:
			this.rigidbody.velocity = new Vector3(dir.x, dir.y, 0f);
			break;
		}
	}

	// 補正
	void Revise(){
		
	}

	// ショット
	void Shot(){
		
	}
	//--------------------------------------------------
	//--------------------------------------------------
}
