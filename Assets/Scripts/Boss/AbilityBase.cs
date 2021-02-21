using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityBase : MonoBehaviour
{
	[SerializeField] protected float abilityDuration;

	protected bool isUsing;
	protected float timePassed;

	public virtual void Execute(int element = 0)
	{
		isUsing = true;
		timePassed = 0f;
	}
}
