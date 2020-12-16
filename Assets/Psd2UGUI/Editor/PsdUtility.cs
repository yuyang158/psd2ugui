using System.Collections.Generic;
using Ntreev.Library.Psd;
using UnityEditor;
using UnityEngine;

namespace Psd2UGUI.Editor {
	public static class PsdUtility {
		private static readonly Dictionary<LayerType, Texture> DEFAULT_LAYER_TEXTURE = new Dictionary<LayerType, Texture> {
			{LayerType.Group, EditorGUIUtility.IconContent( "d_GameObject Icon" ).image},
			{LayerType.Normal, EditorGUIUtility.IconContent("Image Icon").image},
			{LayerType.Color, EditorGUIUtility.IconContent("Material Icon").image},
			{LayerType.Text, EditorGUIUtility.IconContent("Text Icon").image},
			{LayerType.Overflow, EditorGUIUtility.FindTexture( "d_console.warnicon" )},
			{LayerType.Complex, EditorGUIUtility.FindTexture( "console.erroricon" )}
		};

		private static readonly Dictionary<string, Texture> EXTEND_LAYER_TEXTURE = new Dictionary<string, Texture> {
			{"Button", EditorGUIUtility.IconContent("Button Icon").image},
			{"Toggle", EditorGUIUtility.IconContent("Toggle Icon").image}
		};

		public static Texture GetLayerTexture(PsdPreviewTreeItem item) {
			return DEFAULT_LAYER_TEXTURE[item.LayerType];
		}
	}
}