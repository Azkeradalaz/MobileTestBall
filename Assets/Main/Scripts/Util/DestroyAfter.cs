using UnityEngine;

public class DestroyAfter: MonoBehaviour {
	[SerializeField]
	private float timer = 2f;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, timer);
	}
	

}
