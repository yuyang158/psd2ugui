using Ntreev.Library.Psd;
using UnityEditor.IMGUI.Controls;

namespace Psd2UGUI.Editor {
	public class PsdPreviewTreeItem : TreeViewItem {
		public IPsdLayer Layer { get; }
		public LayerType LayerType => Layer is PsdDocument ? LayerType.Group : ( Layer as PsdLayer ).LayerType;

		public PsdPreviewTreeItem(int id, int depth, IPsdLayer layer) : base(id, depth, layer.Name) {
			Layer = layer;
		}
	}
}