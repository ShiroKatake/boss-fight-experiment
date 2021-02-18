using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coil : AbilityBase
{
	[SerializeField] private float moveSpeed;
	[SerializeField] private float rotateSpeed;
	[SerializeField] private float pitchSpeed;
	[SerializeField] private float maxHeight;

	float currentMoveSpeed;
	float currentRotateSpeed;
	float currentPitchSpeed;
	float startHeight;

	float moving = 1f;

    // Start is called before the first frame update
    void Start()
    {
		currentMoveSpeed = moveSpeed;
		currentRotateSpeed = rotateSpeed;
		currentPitchSpeed = pitchSpeed;
		startHeight = transform.position.y;
	}

	protected override void Ability()
	{
		Orbit();
		Move();

		if (transform.position.y > maxHeight)
			moving = -1;

		if (transform.position.y < startHeight)
		{
			moving = 0;
			canUse = false;
		}
	}

	void Orbit()
	{
		transform.Rotate(Vector3.up, currentRotateSpeed * Time.deltaTime);
		transform.Translate(Vector3.forward * currentMoveSpeed * Time.deltaTime);
	}

	void Move()
	{
		switch (moving)
		{
			case 1:
				transform.Translate(Vector3.up * currentPitchSpeed * Time.deltaTime);
				break;
			case -1:
				transform.Translate(Vector3.up * -currentPitchSpeed * Time.deltaTime);
				break;
			default:
				break;
		}		
	}
}
