#if UNITY_EDITOR

using System.IO;
using System.Linq;
using Data.Libraries;
using Game.Scripts.Components;
using Game.Scripts.Data;
using Game.Scripts.Enums;
using Game.Scripts.System;
using Game.Scripts.System.Logger;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace Game.Scripts.Libraries
{
    public class GameLibraryWindow : OdinMenuEditorWindow
    {
        [SerializeField]
        private LibrariesContainer _librariesContainer;

        [MenuItem("Game/Game Library Window")]
        public static void OpenWindow()
        {
            GetWindow<GameLibraryWindow>("Game Library Window").Show();
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            InitLibrariesContainer();

            var tree = new OdinMenuTree(supportsMultiSelect: true);

            tree.Add("Settings/Libraries Container", _librariesContainer);

            string dataPath = Constants.DATAPATH;
            string[] guids = AssetDatabase.FindAssets("t:ScriptableObject", new[] { dataPath });

            foreach (var guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                var asset = AssetDatabase.LoadAssetAtPath(path, typeof(ScriptableObject));

                if (asset != null)
                {
                    string menuPath = path.Replace(Constants.DATAPATH + "/", "");
                    menuPath = Path.ChangeExtension(menuPath, null);
                    tree.Add(menuPath, asset);
                }
            }

            return tree;
        }

        protected override void OnBeginDrawEditors()
        {
            var selected = MenuTree.Selection.FirstOrDefault();

            SirenixEditorGUI.BeginHorizontalToolbar();
            {
                if (SirenixEditorGUI.ToolbarButton("+ Unit"))
                {
                    CreateNewAsset<UnitData>("Units");
                    _librariesContainer.GetLibrary<UnitDataLibrary>().Refresh();
                }

                if (SirenixEditorGUI.ToolbarButton("+ Building"))
                {
                    CreateNewAsset<BuildingData>("Buildings");
                    _librariesContainer.GetLibrary<BuildingDataLibrary>().Refresh();
                }

                if (SirenixEditorGUI.ToolbarButton("+ Scene"))
                {
                    CreateNewAsset<SceneData>("Scenes");
                    _librariesContainer.GetLibrary<SceneDataLibrary>().Refresh();
                }

                if (SirenixEditorGUI.ToolbarButton("— Delete"))
                {
                    if (selected != null)
                        DeleteAsset(selected.Value);
                }

                if (SirenixEditorGUI.ToolbarButton("Refresh"))
                {
                    FindLibraries();

                    foreach (var library in _librariesContainer.GetLibraries())
                    {
                        library.Refresh();
                    }

                    GameLogger.Log(ELogChannel.System, "Libraries Refreshed!");
                }
            }

            SirenixEditorGUI.EndHorizontalToolbar();
        }

        private void CreateNewAsset<T>(string subFolder) where T : ScriptableObject
        {
            string folderPath = Path.Combine(Constants.DATAPATH, subFolder);
            Directory.CreateDirectory(folderPath);

            string assetName = EditorUtility.SaveFilePanelInProject(
                "Create new asset",
                $"New{typeof(T).Name}",
                "asset",
                "Create new asset name",
                folderPath
            );

            if (string.IsNullOrEmpty(assetName)) return;

            var asset = CreateInstance<T>();
            asset.name = Path.GetFileNameWithoutExtension(assetName);
            AssetDatabase.CreateAsset(asset, assetName);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            ForceMenuTreeRebuild();
        }

        private void DeleteAsset(object obj)
        {
            if (obj is not ScriptableObject asset)
                return;

            string path = AssetDatabase.GetAssetPath(asset);
            if (string.IsNullOrEmpty(path))
                return;

            if (!EditorUtility.DisplayDialog(
                    "Delete Asset",
                    $"Delete {asset.name}?",
                    "Delete",
                    "Cancel"))
                return;

            AssetDatabase.DeleteAsset(path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            ForceMenuTreeRebuild();
            MenuTree.Selection.Clear();
        }

        public void FindLibraries()
        {
            _librariesContainer.ClearLibraries();

            string datapath = Constants.LIBRARIESPATH;
            string[] guids = AssetDatabase.FindAssets("t:ScriptableObject", new[] { datapath });

            foreach (var guid in guids)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var asset = AssetDatabase.LoadAssetAtPath(assetPath, typeof(ScriptableObject));

                if (asset != null && asset is IDataLibrary)
                {
                    _librariesContainer.AddLibrary((ScriptableObject)asset);
                }
            }
        }

        private void InitLibrariesContainer()
        {
            string[] guids = AssetDatabase.FindAssets($"t:{nameof(LibrariesContainer)}");
            if (guids.Length > 0)
            {
                _librariesContainer = AssetDatabase.LoadAssetAtPath<LibrariesContainer>(
                    AssetDatabase.GUIDToAssetPath(guids[0]));
            }
        }
    }
}

#endif