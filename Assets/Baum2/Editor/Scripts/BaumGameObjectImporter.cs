using System.IO;
using UnityEditor.AssetImporters;

namespace Baum2.Editor {
	[ScriptedImporter(1, "layout")]
	public class BaumGameObjectImporter : ScriptedImporter {
		public override void OnImportAsset(AssetImportContext ctx) {
			var assetName = Path.GetFileName(ctx.assetPath).Replace(".layout", "");
			var spriteRootPath = EditorUtil.ToUnityPath(Path.Combine(EditorUtil.GetBaumSpritesPath(), assetName));
			var fontRootPath = EditorUtil.ToUnityPath(EditorUtil.GetBaumFontsPath());
			var creator = new PrefabCreator(spriteRootPath, fontRootPath, ctx.assetPath);
			var go = creator.Create();

			ctx.AddObjectToAsset("main obj", go);
			ctx.SetMainObject(go);
		}
	}
}