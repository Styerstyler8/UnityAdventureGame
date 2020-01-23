using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WeaponsList : MonoBehaviour {

    public List<Item> weapons = new List<Item>();

    [SerializeField] GameObject itemSlotPrefab;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < weapons.Capacity; i++)
        {
            GameObject itemSlot = Instantiate(itemSlotPrefab);
        }
	}
}
