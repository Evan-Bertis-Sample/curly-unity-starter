using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

using CurlyUtility;

namespace CurlyEditor.Utility
{
    [CustomPropertyDrawer(typeof(DirectoryPath))]
    public class DirectoryPathDrawer : SearchBarDrawer
    {
        protected override void ButtonClicked(Rect buttonPosition)
        {
            string absolute = EditorUtility.OpenFolderPanel("Choose Directory", "", "");
            _propertyValue = FileUtil.GetProjectRelativePath(absolute);
        }
    }

    [CustomPropertyDrawer(typeof(FilePath))]
    public class FilePathDrawer : SearchBarDrawer
    {
        protected override void ButtonClicked(Rect buttonPosition)
        {
            string absolute = EditorUtility.OpenFilePanel("Choose File", "", "");
            _propertyValue = FileUtil.GetProjectRelativePath(absolute);
        }
    }
}
