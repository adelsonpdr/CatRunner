using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;
	public float leftMargin;
	public float rightMargin;
	public float topMargin;
	public float bottomMargin;
	public float topLimit;
	public float bottomLimit;
	public Renderer backgroundRenderer;
	public Transform backgroundTransform;
	public float backgroundSpeed;

	void Update () {

		Vector3 newPosition;

		newPosition = transform.position;

		if ( target.position.x > transform.position.x + rightMargin )
			newPosition.x = target.position.x - rightMargin;

		if ( target.position.x < transform.position.x - leftMargin )
			newPosition.x = target.position.x + leftMargin;

		if ( target.position.y > transform.position.y + topMargin )
			newPosition.y = target.position.y - topMargin;

		if ( target.position.y < transform.position.y - bottomMargin )
			newPosition.y = target.position.y + bottomMargin;

		newPosition.y = Mathf.Clamp(newPosition.y, bottomLimit, topLimit);

		backgroundTransform.position = new Vector2(newPosition.x, backgroundTransform.position.y);

		backgroundRenderer.material.mainTextureOffset = new Vector2(newPosition.x * backgroundSpeed, 0);

		transform.position = newPosition;

	}

}
