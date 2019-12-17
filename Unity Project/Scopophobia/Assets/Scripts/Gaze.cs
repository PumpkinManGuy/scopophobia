using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
public class Gaze : MonoBehaviour
{
    public Camera _cam;
    public float maxRange;

    public Image redEye;
    public Image blueEye;
    public Image greenEye;

    public bool blueKey;
    public bool greenKey;
    public bool redKey;
    public void Start()
    {
        if (!_cam)
        {
            _cam = GameObject.Find("CenterEyeAnchor").GetComponent<Camera>();
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

        if (blueKey)
        {
            blueEye.gameObject.SetActive(true);
        }
        else
        {
            blueEye.gameObject.SetActive(false);
        }
        if (greenKey)
        {
            greenEye.gameObject.SetActive(true);
        }
        else
        {
            greenEye.gameObject.SetActive(false);
        }
        if (redKey)
        {
            redEye.gameObject.SetActive(true);
        }
        else
        {
            redEye.gameObject.SetActive(false);
        }
    }
}