using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackMechanic : MonoBehaviour
{
    public Transform Itemholdertransform;
    public int numofitemholding=0;
    List<int> ItemlistNum = new List<int>();
    public void AddNewItem(Transform _ItemtoAdd)
    {
        _ItemtoAdd.DOJump(Itemholdertransform.position +new Vector3(0, 0.025f * numofitemholding, 0),1.5f,1,0.25f).OnComplete(
            () =>
            {
                _ItemtoAdd.SetParent(Itemholdertransform, true);
                _ItemtoAdd.localPosition = new Vector3(0,0.25f*numofitemholding,0);
                _ItemtoAdd.localRotation = Quaternion.identity;
                numofitemholding++;
                if (numofitemholding > 9)
                {
                    
                    
                }

            }

            );
    }   
}
