using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AbilityQueue : MonoBehaviour
{
	//Private Fields---------------------------------------------------------------------------------------------------------------------------------

	//Serialized Fields----------------------------------------------------------------------------
	private Queue<KeyValuePair<float, Ability>> abilityQueue;
	private Ability lastAbility;
	private Ability currentAbility;

	private const string CSV_PATH = "Assets/CSV/BossTimeline.csv";

	private void Awake()
	{

	}

	void Start()
    {
		//abilityQueue.Enqueue(new KeyValuePair<float, Ability>(10f, elementalCharge));
		ReadCSV();
	}

	// Update is called once per frame
	void Update()
    {
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
			Debug.Log(data_values[0].ToString() + " " + data_values[1].ToString());
		}
	}
}
