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
		ExecuteTimeline();
	}

	private void ExecuteTimeline()
	{
		if (currentAbility != null && !currentAbility.ability.IsUsing && timePassed >= currentAbility.timeOfExecution)
		{
			boss.Element = currentAbility.element;
			Debug.Log($"Boss' Element: {boss.Element}");
			currentAbility.ability.Execute();
			Debug.Log($"Ability' Element: {currentAbility.ability.Element}");

			if (abilityQueue.BossAbilityQueue.Count != 0)
				currentAbility = abilityQueue.BossAbilityQueue.Dequeue();
			else
				currentAbility = null;
		}
	}

}
