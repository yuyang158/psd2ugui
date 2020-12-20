using UnityEditor.AssetImporters;
using UnityEngine;

namespace Baum2.Editor {
	[ScriptedImporter(1, "ui")]
	public class BaumGameObjectImporter : ScriptedImporter {
		public override void OnImportAsset(AssetImportContext ctx) {
			var go = new GameObject();
			ctx.AddObjectToAsset("main obj", go);
			ctx.SetMainObject(go);
		}
	}
}