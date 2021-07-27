using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour
{
    public Transform Slime;
    public Transform NewSlimePos;
    public float Speed = 1f;
    public bool suck = false;
   
    public Vector3 minScale;
    public Vector3 maxScale;
    public bool repeatable;
    public float speed = 2f;
    public float duration = 5f;
    public GameObject isVisible;


    void Start()
    {
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            Debug.Log("True");
            suck = true;
            yield return RepeatLerp(maxScale, minScale, duration);
        }

        if (other.tag == ("Vacuum"))
        {
            Destroy(isVisible, 0.5f);

            gameObject.SetActive(false);

        }
    }
    // Update is called once per frame
    void Update()
    {

        if (suck)
        {
            PositionChanging();
        }
        
    }
    void PositionChanging()
    {

        Slime.transform.position = Vector3.Lerp(Slime.position, NewSlimePos.position, Time.deltaTime * Speed);
        Slime.transform.rotation = Quaternion.Lerp(Slime.rotation, NewSlimePos.rotation, Time.deltaTime * Speed);

    }

    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i<1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = (Vector3.Lerp(a, b, i));
            yield return null;
        }
    }
}
