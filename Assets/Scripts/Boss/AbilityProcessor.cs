using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityProcessor : MonoBehaviour
{
	private Boss boss;
	private AbilityQueue abilityQueue;
	private float timePassed;
	private AbilityExecutionData currentAbility;
	private AbilityExecutionData nextAbility;

	private void Awake()
	{
		abilityQueue = GetComponent<AbilityQueue>();
		boss = GetComponent<Boss>();
	}

	private void Start()
	{
		currentAbility = abilityQueue.BossAbilityQueue.Dequeue();
	}

	// Update is called once per frame
	void Update()
    {
		timePassed += Time.deltaTime;
		ExecuteAbility();
	}

	/// <summary>
	/// Gets a random element for an attack.
	/// </summary>
	private void GetRandomElement()
	{
		boss.Element = (EElement)Random.Range(0, 2);
	}

	private void ExecuteAbility()
	{
		if (!currentAbility.ability.IsUsing && timePassed >= currentAbility.timeOfExecution)
		{
			currentAbility.ability.Execute(currentAbility.element);

			if (abilityQueue.BossAbilityQueue.Count != 0)
				currentAbility = abilityQueue.BossAbilityQueue.Dequeue();
		}
	}

}
