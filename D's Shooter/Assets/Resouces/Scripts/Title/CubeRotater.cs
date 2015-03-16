using UnityEngine;
using System.Collections;

public class CubeRotater : MonoBehaviour {
	[SerializeField]
	float x = 0,y = 0,z = 0,rot = 0;

	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(x, y, z), rot * Time.deltaTime);
	}
}
