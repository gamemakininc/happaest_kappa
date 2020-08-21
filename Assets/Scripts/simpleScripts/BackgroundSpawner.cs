using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    [System.Serializable]
    public class BackgroundElement
    {
        public string name;
        public GameObject[] props;
        public float weight;
    }

    public GameObject backgroundParent;
    public float propsPerSecond;
    [HideInInspector]
    public float speedMultiplier = 1;
    private float invPropsPerSecond;
    private float _invPropsPerSecond;
    public BackgroundElement[] backgroundElements;

    void Start()
    {
        if (!backgroundParent)
        {
            backgroundParent = new GameObject("Background", typeof(InstantVelocity));
        }
        invPropsPerSecond = 1 / (float)propsPerSecond; //Flips so that it's actually per second
        //print("invPropsPerSecond = " + invPropsPerSecond);
        _invPropsPerSecond = invPropsPerSecond;
    }

    void Update()
    {
        _invPropsPerSecond -= Time.deltaTime * speedMultiplier;
        if(_invPropsPerSecond <= 0)
        {
            GameObject chosenProp = ChooseProp(backgroundElements);
            GameObject spawnedProp = Instantiate(chosenProp, (Vector2)transform.position + (Vector2)Camera.main.ViewportToWorldPoint(new Vector3(1.0f, Random.Range(0.05f, 0.95f), 0.0f)), Quaternion.Euler(Vector3.zero), backgroundParent.transform);
            //print("Spawned " + spawnedProp.name);
            //spawnedProp.GetComponent<Rigidbody2D>().AddForce(Vector2.left, ForceMode2D.Impulse);
            _invPropsPerSecond = invPropsPerSecond;
        }
    }

    GameObject ChooseProp (BackgroundElement[] elements) //Chooses a prop to spawn
    {
        float total = 0;

        foreach(BackgroundElement element in elements)
        {
            total += element.weight;
        }

        float randomPoint = Random.value * total;

        for(int i = 0; i < elements.Length; i++)
        {
            if (randomPoint <= elements[i].weight)
                return elements[i].props[Random.Range(0, elements[i].props.Length)];
            else
            {
                randomPoint -= elements[i].weight;
            }
        }
        return elements[elements.Length - 1].props[Random.Range(0, elements[elements.Length - 1].props.Length)];
    }
}
