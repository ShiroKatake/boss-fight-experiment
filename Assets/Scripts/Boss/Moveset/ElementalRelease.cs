using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalRelease : Ability
{
	[SerializeField] private float moveSpeed;
	[SerializeField] private float radius;

	private float angleT;
	private float posX, posY, posZ;
	private float currentMoveSpeed;
	private float direction = 1f;

	// Start is called before the first frame update
	void Start()
    {
		currentMoveSpeed = moveSpeed;
		abilityName = "Elemental Release";
	}

	protected override void Update()
	{
		base.Update();
		if (timePassed >= abilityDuration)
			isUsing = false;
		if (isUsing)
			Release();
	}

	private void Release()
	{
		angleT += Mathf.Deg2Rad * moveSpeed * direction * Time.deltaTime;

		posX = radius * Mathf.Cos(angleT);
		posY = transform.localPosition.y;
		posZ = radius * Mathf.Sin(angleT);

		transform.localPosition = new Vector3(posX, posY, posZ);
	}
}
