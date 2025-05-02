using Den.Tools;
using MapMagic.Core;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    [SerializeField] MapMagicObject mapMagicObject;
    [SerializeField] MatrixAsset heightMap;

    private void Start()
    {
        Crashes();
    }

    public void Crashes()
    {
        heightMap.source = MatrixAsset.Source.Texture;
        heightMap.channelSource = MatrixAsset.Channel.Grayscale;

        heightMap.textureSource = new Texture2D(50, 250, TextureFormat.RGBA32, false);
        heightMap.textureSource.filterMode = FilterMode.Point;
        heightMap.textureSource.wrapMode = TextureWrapMode.Clamp;

        heightMap.Reload();

        mapMagicObject.tileSize = new Vector2D(50, 250);

        foreach (var tile in mapMagicObject.tiles.Tiles())
        {
            mapMagicObject.tiles.UnpinCustom(tile);
        }

        mapMagicObject.tiles.Pin(new Coord(0, 0), false, mapMagicObject);
    }

    public void Works()
    {
        heightMap.source = MatrixAsset.Source.Texture;
        heightMap.channelSource = MatrixAsset.Channel.Grayscale;

        heightMap.textureSource = new Texture2D(250, 250, TextureFormat.RGBA32, false);
        heightMap.textureSource.filterMode = FilterMode.Point;
        heightMap.textureSource.wrapMode = TextureWrapMode.Clamp;

        heightMap.Reload();

        mapMagicObject.tileSize = new Vector2D(250, 250);

        foreach (var tile in mapMagicObject.tiles.Tiles())
        {
            mapMagicObject.tiles.UnpinCustom(tile);
        }

        mapMagicObject.tiles.Pin(new Coord(0, 0), false, mapMagicObject);
    }
}
