using UnityEngine;

public class ObjectSorting : MonoBehaviour
{
    public int numberOfObjects = 10; // я добавил 10 обьектов, можно менять их в самом unity
    public GameObject objectPrefab; // выбираете модель
    public float minSize = 0.5f; // мин scale
    public float maxSize = 2f; // макс scale

    private GameObject[] objects;
    private float[] sizes; 

    void Start()
    {
  
        objects = new GameObject[numberOfObjects];
        sizes = new float[numberOfObjects];

        for (int i = 0; i < numberOfObjects; i++)
        {
            float size = Random.Range(minSize, maxSize);
            Color randomColor = new Color(Random.value, Random.value, Random.value);

            objects[i] = Instantiate(objectPrefab, new Vector3(i * 2, 0, 0), Quaternion.identity);
            objects[i].transform.localScale = new Vector3(size, size, size);
            objects[i].GetComponent<Renderer>().material.color = randomColor;

            sizes[i] = size;
        }

        for (int i = 0; i < numberOfObjects - 1; i++)
        {
            for (int j = 0; j < numberOfObjects - i - 1; j++)
            {
                if (sizes[j] > sizes[j + 1])
                {
                    GameObject tempObject = objects[j];
                    objects[j] = objects[j + 1];
                    objects[j + 1] = tempObject;

                    float tempSize = sizes[j];
                    sizes[j] = sizes[j + 1];
                    sizes[j + 1] = tempSize;
                }
            }
        }

        for (int i = 0; i < numberOfObjects; i++)
        {
            objects[i].transform.position = new Vector3(i * 2, sizes[i] / 2, 0);
        }
    }
}