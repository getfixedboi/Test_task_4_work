using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TruckTrigger : MonoBehaviour
{
    private int _grabbableObjectsInside = 0;
    [SerializeField] private Text _winText;
    private void OnTriggerEnter(Collider other)
    {
        Grabbable grabbable = other.GetComponent<Grabbable>();
        if (grabbable != null)
        {
            _grabbableObjectsInside++;

            if (_grabbableObjectsInside == 9)
            {
                _winText.text = "U win!";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Grabbable grabbable = other.GetComponent<Grabbable>();
        if (grabbable != null)
        {
            _grabbableObjectsInside--;
        }
    }

}
