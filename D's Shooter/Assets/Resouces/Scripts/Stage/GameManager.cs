using UnityEngine;
using System.Collections;

// ゲームの次元モード
public enum DimensionMode{
	Mode2D,		// 2Dモード
	Mode3D,		// 3Dモード
};

// ステージのプレイモード
public enum NowPlayMode{
	Play,		// プレイ
	Pouse,		// ポーズ
	Continue,	// To Be Continue?
};

public class GameManager : MonoBehaviour {
	[SerializeField] private int Framelate = 60;
	[SerializeField] private DimensionMode _Dimension = DimensionMode.Mode2D;
	[SerializeField] private NowPlayMode _NowMode = NowPlayMode.Play;

	public DimensionMode Dimension{get {return _Dimension;}}
	public NowPlayMode NowMode{get {return _NowMode;}}

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = Framelate;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
