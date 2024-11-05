using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    
    private Item _itemInHand;
    private Item _item;

    private void Update()
    {

        TryPickup();

        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     if (_itemInHand == null)
        //     else
        //         Drop();
        // }
    }

    private void TryPickup()
    {
        if (_item != null)
        {
            _item.SetDefaultMaterial();
            _item = null;
        }

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hitInfo, 3) == false) 
            return;

        if (hitInfo.transform.TryGetComponent(out Item item) == false) 
            return;
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            _itemInHand = item;
            _itemInHand.transform.parent = transform;
        }
        else
        {
            _item = item;
            item.SetOutlineMaterial();
        }
    }

    private void Drop()
    {
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hitInfo, 3))
        {
            if (hitInfo.transform.TryGetComponent(out PickupTruck pickupTruck))
            {
                _itemInHand.transform.parent = null;
                _itemInHand.transform.position = pickupTruck.transform.position;
            }
        }
    }
}
