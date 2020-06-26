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

    public float propsPerSecond;
    private float invPropsPerSecond;
    private float _invPropsPerSecond;
    public BackgroundElement[] backgroundElements;

    void Start()
    {
        invPropsPerSecond = 1 / (float)propsPerSecond; //Flips so that it's actually per second
        //print("invPropsPerSecond = " + invPropsPerSecond);
        _invPropsPerSecond = invPropsPerSecond;
    }

    void Update()
    {
        _invPropsPerSecond -= Time.deltaTime;
        if(_invPropsPerSecond <= 0)
        {
            GameObject chosenProp = ChooseProp(backgroundElements);
            GameObject spawnedProp = Instantiate(chosenProp, (Vector2)transform.position + (Vector2)Camera.main.ViewportToWorldPoint(new Vector3(1.0f, Random.value, 0.0f)), Quaternion.Euler(Vector3.zero));
            //print("Spawned " + spawnedProp.name);
            spawnedProp.GetComponent<Rigidbody2D>().AddForce(Vector2.left, ForceMode2D.Impulse);
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
