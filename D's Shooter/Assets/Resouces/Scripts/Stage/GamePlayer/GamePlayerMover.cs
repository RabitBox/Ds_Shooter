using UnityEngine;
using System.Collections;

public class GamePlayerMover : MonoBehaviour {
	private GameManager _GameManager;
	private InputManager _InputManager;
	private GamePlayer _GamePlayer;
	[SerializeField] private float Speed = 5f;

	[SerializeField] private float XTB;
	[SerializeField] private float YTB;
	[SerializeField] private float ZT;
	[SerializeField] private float ZB;

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
				Move ();
				break;

			case PlayerState.Live:
				Move ();
				break;

			case PlayerState.Dead:
				return;
				break;
			}
		}
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
		Revise();
	}

	// 補正
	void Revise(){
		float x = this.transform.position.x;
		float y = this.transform.position.y;
		float z = this.transform.position.z;
		if(this.transform.position.x > XTB){
			x = XTB;
		}else if(this.transform.position.x < -XTB){
			x = -XTB;
		}
		if(this.transform.position.y > YTB){
			y = YTB;
		}else if(this.transform.position.y < -YTB){
			y = -YTB;
		}
		if(this.transform.position.z > ZT){
			z = ZT;
		}else if(this.transform.position.z < ZB){
			z = ZB;
		}
		this.transform.position = new Vector3(x, y, z);
	}
}
