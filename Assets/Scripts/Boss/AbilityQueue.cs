using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AbilityExecutionData
{
	public float timeOfExecution;
	public Ability ability;
	public EElement element;

	public AbilityExecutionData(float timeOfExecution, Ability ability, EElement element)
	{
		this.timeOfExecution = timeOfExecution;
		this.ability = ability;
		this.element = element;
	}
}

public class AbilityQueue : MonoBehaviour
{

	//Private Fields---------------------------------------------------------------------------------------------------------------------------------

	//Serialized Fields----------------------------------------------------------------------------
	private Queue<AbilityExecutionData> abilityQueue = new Queue<AbilityExecutionData>();
	private Dictionary<string, Ability> abilityDictionary = new Dictionary<string, Ability>();

	private ElementalCharge elementalCharge;
	private ElementalRelease elementalRelease;

	private const string CSV_PATH = "Assets/CSV/BossTimeline.csv";

	private EElement firstElement;

	public Queue<AbilityExecutionData> BossAbilityQueue { get => abilityQueue; set => abilityQueue = value; }
	
	private void Awake()
	{
		InitializeAbility(elementalCharge);
		InitializeAbility(elementalRelease);
		ReadCSV();
	}

	private void ReadCSV()
	{
		StreamReader streamReader = new StreamReader(CSV_PATH);
		bool endOfFile = false;
		while (!endOfFile)
		{
			string data_string = streamReader.ReadLine();
			if (data_string == null)
			{
				endOfFile = true;
				break;
			}
			var data_values = data_string.Split(',');
			//Debug.Log($"{data_values[0]}, {data_values[1]}, {data_values[2]}");
			EnqueueAbilities(data_values);
		}
	}

	private void InitializeAbility<T>(T abilityType)
	{
		abilityType = GetComponent<T>();
		Ability ability = abilityType as Ability;
		abilityDictionary.Add(ability.AbilityName, ability);
	}
	
	private void EnqueueAbilities(string[] dataValues)
	{
		abilityQueue.Enqueue(GenerateExecutionData(float.Parse(dataValues[0]), dataValues[1], dataValues[2]));
	}

	private AbilityExecutionData GenerateExecutionData(float executionTime, string abilityName, string aElement)
	{
		EElement element = EElement.None;

		switch (aElement)
		{
			case "Random":
				element = GetRandomElement();
				firstElement = element;
				break;
			case "Other":
				element = firstElement == EElement.Fire ? EElement.Thunder : EElement.Fire;
				break;
			case "":
				break;
			default:
				element = (EElement)System.Enum.Parse(typeof(EElement), aElement);
				break;
		}

		return new AbilityExecutionData(executionTime, abilityDictionary[abilityName], element);
	}

	/// <summary>
	/// Gets a random element for an attack.
	/// </summary>
	private EElement GetRandomElement()
	{
		return (EElement)Random.Range((int)EElement.Fire, (int)EElement.Thunder + 1);
	}
}
