using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] int bottom;
    [SerializeField] int width, height;
    [SerializeField] GameObject dirt, grass;


    // Start is called before the first frame update
    // TODO Generate the tiles programattically
    void Start()
    {
        Generate();
    }

    void Generate() 
    {
        int bottomScreen = -((Screen.height / 2) + 20);
        
        //int initX = pos
        for (int x = -width/2; x < width/2; x++)
        {
            int minHeight = height - 1;
            int maxHeight = height + 2;

            height = Random.Range(minHeight, maxHeight);

            for (int y = bottomScreen; y < height; y++)
            {
                SpawnObject(dirt, x, y);
            }

            // TODO add Color controller
            //grass.GetComponent<SpriteRenderer>().color = Color.blue;
            SpawnObject(grass, x, height);
        }

    }

    void SpawnObject(GameObject obj, int x, int y) 
    {
        obj = Instantiate(obj, new Vector2(x, y), Quaternion.identity);
        obj.transform.parent = this.transform; 
    }
}
