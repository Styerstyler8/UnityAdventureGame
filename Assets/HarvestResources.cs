using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HarvestResources : MonoBehaviour {

    public int maxHarvestDistance = 3;
    private RaycastHit hit;
    private GameObject tree;
    private GameObject rock;

    public Text harvestText;

    private int choppingPower = 2;
    private int miningPower = 1;

    // Use this for initialization
    void Start () {
        harvestText.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetMouseButtonDown(0)) // TODO: add && HasAxeEquipped
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray,out hit, 30f))
            {
                if (hit.collider.gameObject.tag == "Tree")
                {
                    if (CheckIfInRange())
                    {
                        tree = hit.collider.transform.parent.gameObject;

                        tree.GetComponent<HarvestableTree>().ChopWood(choppingPower);
                        print("Tree has been hit. " + "Its current health is: " + tree.GetComponent<HarvestableTree>().GetTreeHealth());
                        Inventory.instance.Add("Wood");
                        StartCoroutine(ShowMessage("+1 Wood", 0.5f));

                        if (tree.GetComponent<HarvestableTree>().GetTreeHealth() <= 0)
                        {
                            tree.SetActive(false);
                        }
                    }
                }
                else if (hit.collider.gameObject.tag == "Rock")
                {
                    if (CheckIfInRange())
                    {
                        rock = hit.collider.gameObject;

                        rock.GetComponent<HarvestableRock>().MineRock(miningPower);
                        print("Rock has been hit. " + "Its current health is: " + rock.GetComponent<HarvestableRock>().GetRockHealth());
                        //Inventory.instance.Add("Stone");
                        StartCoroutine(ShowMessage("+1 Stone", 0.5f));

                        if (rock.GetComponent<HarvestableRock>().GetRockHealth() <= 0)
                        {
                            rock.SetActive(false);
                        }
                    }
                }


            }



        }

	}

    private bool CheckIfInRange()
    {
        if (Vector3.Distance(transform.position, hit.point) > maxHarvestDistance)
            return false;
        else
            return true;
    }

    public int GetChoppingPower() { return choppingPower; }
    public void SetChoppingPower(int newPower) { choppingPower = newPower; }
    public int GetMiningPower() { return miningPower; }
    public void SetMiningPower(int newPower) { miningPower = newPower; }

    IEnumerator ShowMessage(string message, float delay)
    {
        harvestText.text = message;
        harvestText.gameObject.transform.localPosition = new Vector3(Random.Range(-40.0f,40.0f), Random.Range(-40.0f, 40.0f));
        harvestText.enabled = true;
        yield return new WaitForSeconds(delay);
        harvestText.enabled = false;
    }
}
