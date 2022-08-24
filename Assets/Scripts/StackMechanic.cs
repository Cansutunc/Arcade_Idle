using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackMechanic : MonoBehaviour
{
    public Transform itemHolderTransform;
    public int numofitemholding=0;
    public List <Transform> listOfitems;
    private Transform currentDropArea;
    private bool isDroppable =true;

    public void AddNewItem(Transform _ItemtoAdd)
    {
        listOfitems.Add(_ItemtoAdd);
        _ItemtoAdd.DOJump(itemHolderTransform.position +new Vector3(0, 0.001f * numofitemholding, 0),1.5f,1,0.25f).OnComplete(
            () =>
            {
                _ItemtoAdd.SetParent(itemHolderTransform, true);
                _ItemtoAdd.localPosition = new Vector3(0,0.0001f*numofitemholding,0);
                _ItemtoAdd.localRotation = Quaternion.identity;
                numofitemholding++;             
            }
            );
    }   
    public void DropCollectedItem()
    {
        isDroppable = false;
        Transform itemDrop;
        //1 sn sonra callu yap
        DOVirtual.DelayedCall(1f,() =>
        {
            isDroppable = true;
        });
        if(listOfitems.Count == 0)
        {
            return;           
        }
        itemDrop = listOfitems[listOfitems.Count-1];
        listOfitems.Remove(itemDrop);
        itemDrop.SetParent(currentDropArea, true);
        itemDrop.DOMove(currentDropArea.position, 0.01f);

    }
    private void OnTriggerStay(Collider other)
    {        
        if (other.CompareTag("DropArea")&& isDroppable)
        {
            
            currentDropArea = other.GetComponent<Transform>();
            DropCollectedItem();
            Debug.Log("objeyi býraktý");
        }
        
    }
}
