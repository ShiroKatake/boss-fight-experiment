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

	private void Update()
	{
		if (timePassed < abilityDuration)
			timePassed += Time.deltaTime;
		else
			isUsing = false;

		if (isUsing)
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
		switch (element)
		{
			case EElement.Fire:
				fireFX.SetActive(true);
				thunderFX.SetActive(false);
				break;
			case EElement.Thunder:
				fireFX.SetActive(false);
				thunderFX.SetActive(true);
				break;
			default:
				Debug.Log("Element number went out of range.");
				break;
		}
	}

	public override void Execute(int element = 0)
	{
		//EnableFX((EElement)element);
		base.Execute(element);
	}
}
