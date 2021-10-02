using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipSensor : MonoBehaviour
{
    private ObjectOfInterest _Interest;

    public UnityEvent OnStartedScanning;
    public UnityEvent OnScanSuccessful;
    public UnityEvent OnEndedScanning;

    private void OnTriggerEnter(Collider other)
    {
        if (_Interest == null)
        {
            var ofInterest = other.gameObject.GetComponent<ObjectOfInterest>();
            if (ofInterest && ofInterest.Mystery >= 0)
            {
                _Interest = ofInterest;
                OnStartedScanning.Invoke();
                Debug.Log("STARTING");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_Interest != null)
        {
            _Interest = null;
            OnEndedScanning.Invoke();
            Debug.Log("STOPPED");
        }
    }

    private void FixedUpdate()
    {
        if (_Interest != null)
        {
            Debug.Log(_Interest.Mystery);
            if (_Interest.Mystery > 0)
            {
                _Interest.Mystery--;
            }
            else
            {
                OnScanSuccessful.Invoke();
                OnEndedScanning.Invoke();
                DestroyImmediate(_Interest.gameObject);
                _Interest = null;
            }
        }
    }
}
