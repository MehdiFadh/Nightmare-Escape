using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipSystem : MonoBehaviour
{
    public static EquipSystem Instance { get; set; }
    public GameObject quickSlotsPanel;
    public List<GameObject> quickSlotsList = new List<GameObject>();
    

    public GameObject numbersHolder;

    public int selectedNumber = -1;
    public GameObject selectedItem;

    public GameObject weaponHolder;
    public GameObject selectedItemModel;

    public TextMeshProUGUI numberOfSoin;
 
   
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
 
 
    private void Start()
    {
        PopulateSlotList();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectQuickSlot(1);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectQuickSlot(2);
        }
    }

    void SelectQuickSlot(int number)
    {
        if(CheckIfSlotIsFull(number) == true)
        {
            if(selectedNumber != number)
            {
                selectedNumber = number;
                selectedItem = GetSelectedItem(number);

                SetEquippedModel(selectedItem);

                //change color
                foreach(Transform child in numbersHolder.transform)
                {
                    child.transform.Find("Text").GetComponent<Text>().color =Color.gray;
                }
                Text toBeChange = numbersHolder.transform.Find("number"+number).transform.Find("Text").GetComponent<Text>();
                toBeChange.color = Color.white;
            }
            else // select meme slot
            {
                selectedNumber = -1; //-1 = null



                if(selectedItemModel != null)
                {
                    DestroyImmediate(selectedItemModel.gameObject);
                    selectedItemModel = null;
                }

                foreach(Transform child in numbersHolder.transform)
                {
                    child.transform.Find("Text").GetComponent<Text>().color =Color.gray;
                }
            }
        }
    }

    private void SetEquippedModel(GameObject selectedItem)
    {
        if(selectedItemModel != null)
        {
            DestroyImmediate(selectedItemModel.gameObject);
            selectedItemModel = null;
        }

        string selectItemName = selectedItem.name.Replace("(Clone)", "");
        if(selectItemName == "Gun")
        {
            selectedItemModel = Instantiate(Resources.Load<GameObject>(selectItemName + "_Model"),
                new Vector3(-0.06601435f,0.2941864f,0.6827524f), Quaternion.Euler(-3.156f, -5.874f, -8.534f));
        }

        if(selectItemName == "Soin")
        {
            selectedItemModel = Instantiate(Resources.Load<GameObject>(selectItemName + "_Model"),
                new Vector3(-0.3f,0.6f,0.4f), Quaternion.Euler(80.191f, -89.751f, 6.245f));
        }
        selectedItemModel.transform.SetParent(weaponHolder.transform, false);
        
        

    }


    GameObject GetSelectedItem(int slotNumber)
    {
        return quickSlotsList[slotNumber-1].transform.GetChild(0).gameObject;
    }

    bool CheckIfSlotIsFull(int slotNumber)
    {
        if(quickSlotsList[slotNumber-1].transform.childCount > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

 
    private void PopulateSlotList()
    {
        foreach (Transform child in quickSlotsPanel.transform)
        {
            if (child.CompareTag("QuickSlot"))
            {
                quickSlotsList.Add(child.gameObject);
            }
        }
    }
 
    public void AddToQuickSlots(GameObject itemToEquip)
    {

        GameObject availableSlot = FindNextEmptySlot();
        itemToEquip.transform.SetParent(availableSlot.transform, false);
 
 
    }
 
 
    public GameObject FindNextEmptySlot()
    {
        foreach (GameObject slot in quickSlotsList)
        {
            if (slot.transform.childCount == 0)
            {
                return slot;
            }
        }
        return new GameObject();
    }
 
    public bool CheckIfFull()
    {
 
        int counter = 0;
 
        foreach (GameObject slot in quickSlotsList)
        {
            if (slot.transform.childCount > 0)
            {
                counter += 1;
            }
        }
 
        if (counter == 7)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool AddSoin()
    {
        if(int.Parse(numberOfSoin.text) < 3)
        {
            numberOfSoin.text = $"{int.Parse(numberOfSoin.text)+1}";
            return true;
        }
        else
        {
            return false;
        }
    }
}
