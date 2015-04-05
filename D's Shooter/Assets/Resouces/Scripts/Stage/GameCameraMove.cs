using UnityEngine;
using System.Collections;

public class GameCameraMove : MonoBehaviour {
	private GameManager _GameManager;
	private DimensionMode _BeforeMode;
	private GameObject _LookTarget;
	private int Counter = 0;			// カウントダウンタイマー
	private int SET_COUNT = 30;
	private Vector3 TargetPos2D = new Vector3(0, 9, 0);
	private Vector3 TargetPos3D = new Vector3(0, 0, -7);

	public DimensionMode BeforeMode{get{return _BeforeMode;}}

	// Use this for initialization
	void Start () {
		_GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		_LookTarget = GameObject.Find("CameraTarget");
		_BeforeMode = _GameManager.Dimension;
	}
	
	// Update is called once per frame
	void Update () {
		DimensionMode NowMode = _GameManager.Dimension;

		if(NowMode != _BeforeMode){NowMode = Move (NowMode);}
		//this.transform.LookAt (_LookTarget.transform.position);

		_BeforeMode = NowMode;
	}


	DimensionMode Move(DimensionMode mode){
		if(Counter <= 0){Counter = SET_COUNT;}
		if(Counter > 0)Counter--;
		switch(mode){
		case DimensionMode.Mode2D:
			this.transform.localPosition = QuadOut((float)SET_COUNT, (float)(SET_COUNT-Counter),TargetPos2D, TargetPos3D);
			this.transform.localEulerAngles = new Vector3((float)Easing.QuadOut(SET_COUNT,SET_COUNT-Counter,90f,0f),0,0);
			if(Counter > 0){return DimensionMode.Mode3D;}
			return DimensionMode.Mode2D;
			break;

		case DimensionMode.Mode3D:
			this.transform.localPosition = QuadOut((float)SET_COUNT, (float)(SET_COUNT-Counter),TargetPos3D, TargetPos2D);
			this.transform.localEulerAngles = new Vector3((float)Easing.QuadOut(SET_COUNT,SET_COUNT-Counter,0f,90f),0,0);
			if(Counter > 0){return DimensionMode.Mode2D;}
			return DimensionMode.Mode3D;
			break;
		}

		// エラー回避
		return mode;
	}

	private Vector3 QuadOut(float endTime, float nowTime, Vector3 endPosition, Vector3 firstPosition){
		Vector3 pos = new Vector3(Easing.QuadOut(endTime, nowTime, endPosition.x, firstPosition.x),
		                          Easing.QuadOut(endTime, nowTime, endPosition.y, firstPosition.y),
		                          Easing.QuadOut(endTime, nowTime, endPosition.z, firstPosition.z));
		return pos;
	}
}
