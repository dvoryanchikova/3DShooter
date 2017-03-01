using UnityEngine;
using System.Collections;

public class WanderingAI : MonoBehaviour {

	public float speed = 3.0f;
	public float obstacleRange = 5.0f;

	[SerializeField]private GameObject fireBallPrefab;
	private GameObject _fareball;

	private bool _alive;
		void Start () {
	
		_alive = true;
	}
	
	void Update () {
	
		if(_alive){
			transform.Translate (0, 0, speed * Time.deltaTime);

		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;

		if(Physics.SphereCast(ray, 0.75f, out hit)){
				GameObject hitObject = hit.transform.gameObject;
				if(hitObject.GetComponent<PlayerCharacter>()){
					if(_fareball == null){
						_fareball = Instantiate (fireBallPrefab) as GameObject;

						_fareball.transform.position = transform.TransformPoint (Vector3.forward * 1.5f);
						_fareball.transform.rotation = transform.rotation;
					}
				}
			if(hit.distance < obstacleRange){
				float angle = Random.Range (-110, 110);
				transform.Rotate (0, angle, 0);

				}
			}
		}
	}
	public void SetAlive(bool alive){
		_alive = alive;
	}
}
