using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Tools
{
    public class SpriteSlicer : EditorWindow
    {
        private int cellWidth = 16;
        private int cellHeight = 16;
        private FilterMode filterMode;

        [MenuItem("Window/Sprite Slicer")]
        public static void ShowWindow()
        {
            GetWindow<SpriteSlicer>("Sprite Slicer");
        }

        private void OnGUI()
        {
            cellWidth = EditorGUILayout.IntField("Cell Width:", cellWidth);
            cellHeight = EditorGUILayout.IntField("Cell Height:", cellHeight);
            filterMode = (FilterMode)EditorGUILayout.EnumPopup("Filter Mode:", filterMode);
            if (GUILayout.Button("Reset"))
                ClearSpritesheet();
            if (GUILayout.Button("Slice"))
                SliceSprites();
        }

        private void ClearSpritesheet()
        {
            if (Selection.objects.Length == 0)
                Debug.Log("No textures selected!");

            foreach (Object o in Selection.objects)
            {
                if (o.GetType() != typeof(Texture2D))
                    return;

                string path = AssetDatabase.GetAssetPath(o);
                Texture2D myTexture = AssetDatabase.LoadAssetAtPath<Texture2D>(path);
                TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
                textureImporter.isReadable = true;
                textureImporter.spriteImportMode = SpriteImportMode.Single;

                SpriteMetaData smd = new SpriteMetaData();
                smd.pivot = new Vector2(0.5f, 0.5f);
                smd.alignment = 0;
                smd.name = "Single";
                smd.rect = new Rect(0, 0, myTexture.width, myTexture.height);

                textureImporter.spritesheet = new SpriteMetaData[] { smd };
                AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
            }
        }

        private void SliceSprites()
        {
            if (Selection.objects.Length == 0)
                Debug.Log("No textures selected!");

            if (cellHeight == 0 || cellWidth == 0)
                return;

            foreach (Object o in Selection.objects)
            {
                if (o.GetType() != typeof(Texture2D))
                    return;

                string path = AssetDatabase.GetAssetPath(o);
                Texture2D myTexture = AssetDatabase.LoadAssetAtPath<Texture2D>(path);
                TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
                textureImporter.isReadable = true;
                textureImporter.filterMode = filterMode;
                textureImporter.spritePixelsPerUnit = Mathf.Max(cellHeight, cellWidth);
                textureImporter.spriteImportMode = SpriteImportMode.Multiple;

                textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
                List<SpriteMetaData> newData = new List<SpriteMetaData>();

                for (int i = 0; i < myTexture.width; i += cellWidth)
                {
                    for (int j = myTexture.height; j > 0; j -= cellHeight)
                    {
                        SpriteMetaData smd = new SpriteMetaData();
                        smd.pivot = new Vector2(0.5f, 0.5f);
                        smd.alignment = 9;
                        smd.name = $"{i},{j}";
                        smd.rect = new Rect(i, j - cellHeight, cellWidth, cellHeight);

                        newData.Add(smd);
                    }
                }

                textureImporter.spritesheet = newData.ToArray();
                AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
            }
        }
    }
}