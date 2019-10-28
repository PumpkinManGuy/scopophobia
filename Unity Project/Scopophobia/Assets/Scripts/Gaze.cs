using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
public class Gaze : MonoBehaviour
{
    public Camera _cam;
    public float maxRange;

    public Text uiText;

    public bool blueKey;
    public bool greenKey;
    public bool redKey;
    public void Start()
    {
        if (!_cam)
        {
            _cam = GameObject.Find("CenterEyeAnchor").GetComponent<Camera>();
        }
        if (!uiText)
        {
            uiText = GameObject.Find("UITEXT").GetComponent<Text>();
        }
    }
    public void Update()
    {
        var bcastHits = Physics.SphereCastAll(_cam.transform.position, 2f, _cam.transform.forward, maxRange);
        if(bcastHits.Length != 1)
        {
            var hitOrdered = bcastHits.OrderBy(h => h.distance).ToArray();
            for(int i = 0; i < hitOrdered.Length; i++)
            {
                if (hitOrdered[i].transform.GetComponent<OVRPlayerController>())
                {
                    continue;
                }
                if (hitOrdered[i].transform.GetComponent<EnemyController>())
                {
                    RaycastHit hit;
                    if (Physics.Raycast(_cam.transform.position, (hitOrdered[i].transform.position - _cam.transform.position), out hit, maxRange, ~LayerMask.GetMask("Ignore Raycast")))
                    {
                        if (hit.collider.GetComponent<EnemyController>())
                        {
                            hit.collider.GetComponent<EnemyController>().seen = true;
                        }
                    }
                }
            }
        }

        var sText = "Keys: ";
        if (blueKey)
        {
            sText += "Blue";
        }
        if (greenKey)
        {
            sText += ", Green";
        }
        if (redKey)
        {
            sText += ", Red";
        }
        uiText.text = sText;
    }
}