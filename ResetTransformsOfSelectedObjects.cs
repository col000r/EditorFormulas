﻿using UnityEngine;
using UnityEditor;

namespace EditorFormulas
{
	public static partial class Formulas {
	
		public static void ResetTransformsOfSelectedObjects(bool resetPosition, bool resetRotation, bool resetScale, bool useWorldSpace)
		{
			var selection = Selection.GetFiltered(typeof(Transform), SelectionMode.Editable | SelectionMode.ExcludePrefab);
			if(selection.Length == 0)
			{
				Debug.Log("No transforms found in selection.");
				return;
			}

			foreach(var obj in selection)
			{
				var t = obj as Transform;
				if(resetPosition)
				{
					if(useWorldSpace)
					{
						t.position = Vector3.zero;
					}
					else
					{
						t.localPosition = Vector3.zero;
					}
				}
				if(resetRotation)
				{
					if(useWorldSpace)
					{
						t.rotation = Quaternion.identity;
					}
					else
					{
						t.localRotation = Quaternion.identity;
					}
				}
				if(resetScale)
				{
					if(useWorldSpace)
					{
						var parent = t.parent;
						t.SetParent(null, true);
						t.localScale = Vector3.one;
						t.SetParent(parent, true);
					}
					else
					{
						t.localScale = Vector3.one;
					}
				}
			}
		}
	}
}
