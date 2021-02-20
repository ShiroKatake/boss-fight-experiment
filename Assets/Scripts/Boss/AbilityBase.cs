using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityBase : MonoBehaviour
{
	[SerializeField] private float abilityDuration;

	protected bool isUsing;
	protected abstract void Ability();

	float timePassed;

	// Update is called once per frame
	private void Update()
    {
		if (timePassed < abilityDuration)
			timePassed += Time.deltaTime;
		else
			isUsing = false;

		if (isUsing)
		{
			Ability();
		}
	}

	public void Execute()
	{
		isUsing = true;
		timePassed = 0f;
	}
}
