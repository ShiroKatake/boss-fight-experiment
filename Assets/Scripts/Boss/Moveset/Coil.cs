using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coil : AbilityBase
{
	[SerializeField] private float moveSpeed;

	[SerializeField] private float radius;
	[SerializeField] private float pitch;
	[SerializeField] private float maxHeight;

	float currentMoveSpeed;
	float startHeight;

	float direction = 1f;
	float posX, posY, posZ;
	float angleT;

	// Start is called before the first frame update
	void Start()
    {
		currentMoveSpeed = moveSpeed;
		startHeight = transform.position.y;
	}

	protected override void Ability()
	{
		Orbit();
	}

	void Orbit()
	{
		angleT += Mathf.Deg2Rad * moveSpeed * direction * Time.deltaTime;

		posX = radius * Mathf.Cos(angleT);
		posY = transform.position.y < maxHeight ? pitch * angleT : transform.localPosition.y;
		posZ = radius * Mathf.Sin(angleT);

		transform.localPosition = new Vector3(posX, posY, posZ);
	}
}
