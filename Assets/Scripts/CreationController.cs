using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationController : MonoBehaviour
{ 
    [SerializeField] private Transform[] ItemPlace = new Transform[10];
    [SerializeField] private GameObject item;
    public List<GameObject> listOfitems;
    public float ItemDeliveryTime, YAxis;
    public int CountItems;
    void Start()
    {
        for (int i = 0; i < ItemPlace.Length; i++)
        {
            ItemPlace[i] = transform.GetChild(0).GetChild(i);
        }        
        StartCoroutine(GenerateItem(ItemDeliveryTime)); //finally wrote coroutine and call function.
    }
    public IEnumerator GenerateItem(float Time)
    {
        var item_index = 0;// the item_index will make the loop or period and let the items get distributed in order in each place.(10)

        while (CountItems < 100)    //CountItem determines the items that should produce
        {
                                    // -3f because i wanted item comes out of middle of generator
            GameObject NewItem = Instantiate(item, new Vector3(transform.position.x, -3f, transform.position.z),
                Quaternion.identity, transform.GetChild(1)); //each items parent will be table game object, which is second child of generator.
            listOfitems.Add(NewItem);
            //YAxis variable will make the stack of items growed.
            NewItem.transform.DOJump(new Vector3(ItemPlace[item_index].position.x, ItemPlace[item_index].position.y + YAxis,
                ItemPlace[item_index].position.z), 2f, 1, 0.5f).SetEase(Ease.OutQuad);
            
            //each time item_index get 9 value it will get zero value, and YAxis varible will increase.
            if (item_index < 9)
                item_index++;
            else
            {
                item_index = 0;
                YAxis += 0.05f;
            }
            yield return new WaitForSecondsRealtime(Time);//each new item will produced in specific periof based on ItemDeliveryTime.
            
        } 
    }
    public GameObject GetLastItem()
    {
        //listenin eleman sayýsý 0 sa o method null dönsün 
        if (listOfitems.Count == 0)
        {
            return null;
        }
        else
        {
            return listOfitems[listOfitems.Count - 1];
        }
        
    }
}