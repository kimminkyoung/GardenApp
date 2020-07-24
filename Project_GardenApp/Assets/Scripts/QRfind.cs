using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class QRfind : MonoBehaviour
{
    //static QRfind QRinstant;
    TrackableBehaviour insTrack;
    TrackableBehaviour.Status previous;

    public GameObject targetOBJ;

    // Start is called before the first frame update
    void Start()
    {
        insTrack = GetComponent<TrackableBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckStatus(previous);
        previous = insTrack.CurrentStatus;
    }

    public void CheckStatus(TrackableBehaviour.Status previousStatus)
    {
        if (insTrack.CurrentStatus == TrackableBehaviour.Status.TRACKED ||
            insTrack.CurrentStatus == TrackableBehaviour.Status.DETECTED)
            TrackFound();
        if (previousStatus == TrackableBehaviour.Status.TRACKED &&
            insTrack.CurrentStatus == TrackableBehaviour.Status.NO_POSE)
            TrackLost();
    }

    public void TrackFound()
    {
        print("my custom track found!");
    }
    public void TrackLost()
    {
        print("my custom track lost!");
    }

    public void SizeCalculation()
    {

    }
}

