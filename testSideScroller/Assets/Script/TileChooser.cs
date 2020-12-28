using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChooser : MonoBehaviour
{
    public float tile_x; public float tile_y; public float tile_size; public float sheet_size; private Renderer rend;
    void Start()
{
    rend = GetComponent<Renderer>();
    rend.material.mainTextureScale = (new Vector2(tile_size / sheet_size, tile_size / sheet_size));
    rend.material.SetTextureOffset("_MainTex", new Vector2(tile_x * (tile_size / sheet_size), tile_y * (tile_size / sheet_size)));

}

// Update is called once per frame
void Update()
{
}
 }