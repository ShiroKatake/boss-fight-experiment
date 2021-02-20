using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalCharge : AbilityBase
{
	[SerializeField] private GameObject fireFX;
	[SerializeField] private GameObject thunderFX;

	[SerializeField] private float moveSpeed;
	[SerializeField] private float radius;
	[SerializeField] private float pitch;
	[SerializeField] private float maxHeight;

	private Boss boss;

	private float currentMoveSpeed;
	private float startHeight;

	private float direction = 1f;
	private float posX, posY, posZ;
	private float angleT;

	private void Awake()
	{
		boss = GetComponent<Boss>();
	}

	// Start is called before the first frame update
	private void Start()
    {
		currentMoveSpeed = moveSpeed;
		startHeight = transform.position.y;
	}

	protected override void Ability()
	{
		EnableFX(boss.Element);
		Orbit();
	}

	private void Orbit()
	{
		angleT += Mathf.Deg2Rad * moveSpeed * direction * Time.deltaTime;

		posX = radius * Mathf.Cos(angleT);
		posY = transform.position.y < maxHeight ? pitch * angleT : transform.localPosition.y;
		posZ = radius * Mathf.Sin(angleT);

		transform.localPosition = new Vector3(posX, posY, posZ);
	}

	private void EnableFX(EElement element)
	{
		if (element == EElement.Fire)
		{
			fireFX.SetActive(true);
			thunderFX.SetActive(false);
		}

		else if (element == EElement.Thunder)
		{
			fireFX.SetActive(false);
			thunderFX.SetActive(true);
		}
	}
}
