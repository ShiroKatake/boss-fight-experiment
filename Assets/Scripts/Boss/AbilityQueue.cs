using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AbilityExecutionData
{
	public Ability ability;
	public EElement element;

	public AbilityExecutionData(Ability ability, EElement element)
	{
		this.ability = ability;
		this.element = element;
	}
}

public class AbilityQueue : MonoBehaviour
{

	//Private Fields---------------------------------------------------------------------------------------------------------------------------------

	//Serialized Fields----------------------------------------------------------------------------
	private Queue<KeyValuePair<float, AbilityExecutionData>> abilityQueue = new Queue<KeyValuePair<float, AbilityExecutionData>>();
	private Dictionary<string, Ability> abilityDictionary = new Dictionary<string, Ability>();

	private ElementalCharge elementalCharge;
	private ElementalRelease elementalRelease;

	private const string CSV_PATH = "Assets/CSV/BossTimeline.csv";

	public Queue<KeyValuePair<float, AbilityExecutionData>> BossAbilityQueue { get => abilityQueue; set => abilityQueue = value; }
	
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
		abilityQueue.Enqueue(new KeyValuePair<float, AbilityExecutionData>(float.Parse(dataValues[0]), GetExecutionData(dataValues[1], dataValues[2])));
	}

	//TODO: Check to see if you can assign different elements to the same abilities, only executed at different times
	private AbilityExecutionData GetExecutionData(string abilityName, string aElement)
	{
		EElement element = EElement.None;

		if (aElement != "")
		{
			element = (EElement)System.Enum.Parse(typeof(EElement), aElement);
			abilityDictionary[abilityName].Element = element;
		}

		return new AbilityExecutionData(abilityDictionary[abilityName], element);
	}
}
