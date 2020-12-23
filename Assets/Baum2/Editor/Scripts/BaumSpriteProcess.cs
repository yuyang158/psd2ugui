using UnityEditor;
using UnityEngine;

namespace Baum2.Editor {
	public class BaumSpriteProcess : AssetPostprocessor {
		private void OnPostprocessTexture(Texture2D texture) {
			if( !assetPath.Contains("Assets/Art/UI/Sprites") ) {
				return;
			}
			var importer = assetImporter as TextureImporter;
			importer.textureType = TextureImporterType.Sprite;
			importer.mipmapEnabled = false;
		}
	}
}