using UnityEngine;
using System.Collections;

public class TestRPGEntity : MonoBehaviour {
	public RPGEntity entity;


	// Use this for initialization
	void Start () {
		entity = this.gameObject.GetComponent<RPGEntity> ();
		if (entity == null) {
			Debug.LogWarning("[TestRPGEntity] No RPGEntity Component attachted to GameObject \"" + this.gameObject.name + "\"");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
