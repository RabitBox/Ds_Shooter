using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	// 十字入力を取得
	public Vector2 Direction(){
		return new Vector2(Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical")).normalized;
	}

	// ボタンが押された瞬間を取得
	public bool InputDown(string input){
		return Input.GetButtonDown(input);
	}

	// ボタンが押されている時を取得
	public bool InputStay(string input){
		return Input.GetButton(input);
	}

	// ボタンが離れた瞬間を取得
	public bool InputUp(string input){
		return Input.GetButtonUp(input);
	}
}
