using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSuctionHandler : MonoBehaviour
{
    [SerializeField]
    private List<Transform> slimeParts;
    [SerializeField]
    private SlimeMovement slimeMovement;
    [SerializeField]
    private GameObject icosphere;
    [SerializeField]
    private Renderer rend;

    private bool getClosestPoint;
    private Transform closestPoint;
    private Transform target;
    private bool moveSlimePart;
    private bool moveSlime;
    private bool addSlime;

    private void Start()
    {
        getClosestPoint = true;
        addSlime = true;
        target = GameManager.Instance.SlimePickupHandler.vacuum;
    }

    private void Update()
    {
        if (moveSlimePart)
        {
            closestPoint.transform.position = Vector3.MoveTowards(closestPoint.transform.position, target.position, Time.deltaTime * 5);
        }

        if (moveSlime)
        {
            icosphere.transform.localScale = Vector3.MoveTowards(icosphere.transform.localScale, Vector3.zero, Time.deltaTime * 2);
            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, Time.deltaTime * 5);

            foreach (Transform trans in slimeParts)
            {
                trans.position = Vector3.MoveTowards(trans.position, target.position, Time.deltaTime * 2);
                trans.localScale = Vector3.MoveTowards(trans.localScale, Vector3.zero, Time.deltaTime * 2);
                //icosphere.transform.localScale = Vector3.MoveTowards(icosphere.transform.localScale, Vector3.zero, Time.deltaTime * 2);
                //transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, Time.deltaTime * 5);

                if (trans.localScale == Vector3.zero && addSlime)
                {
                    GameManager.Instance.SlimePickupHandler.AddSlime(rend.material);
                    Debug.LogError("Adding");
                    Destroy(icosphere.transform.parent.gameObject);
                    addSlime = false;
                    moveSlime = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && getClosestPoint)
        {
            Debug.LogError(GetClosestPoint().name);
            closestPoint = GetClosestPoint();
            closestPoint.GetComponent<Rigidbody>().isKinematic = true;
            slimeMovement.StopMovement();
            StartCoroutine(MoveSlime());
            moveSlimePart = true;
            getClosestPoint = false;
        }
    }

    IEnumerator MoveSlime()
    {
        yield return new WaitForSeconds(0.5f);
        moveSlime = true;
    }

    private Transform GetClosestPoint()
    {
        Transform closestCharacter = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPosition = target.position;
        foreach (Transform t in slimeParts)
        {
            float dist = Vector3.Distance(t.position, currentPosition);

            if (dist < minDist)
            {
                closestCharacter = t;
                minDist = dist;
            }
        }

        return closestCharacter;
    }
}
