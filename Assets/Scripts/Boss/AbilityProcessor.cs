using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityProcessor : MonoBehaviour
{
	private Boss boss;
	private AbilityQueue abilityQueue;
	private float timePassed;
	private KeyValuePair<float, AbilityExecutionData> currentAbility = new KeyValuePair<float, AbilityExecutionData>();
	private KeyValuePair<float, AbilityExecutionData> nextAbility = new KeyValuePair<float, AbilityExecutionData>();

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
		if (abilityQueue.BossAbilityQueue.Count != 0)
			nextAbility = abilityQueue.BossAbilityQueue.Dequeue();

		if (!currentAbility.Value.ability.IsUsing && timePassed >= currentAbility.Key)
		{
			currentAbility.Value.ability.Execute(currentAbility.Value.element);
			Debug.Log(currentAbility.Value.ability.Element.ToString());
			currentAbility = nextAbility;
		}
	}

}
