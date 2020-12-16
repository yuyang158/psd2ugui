using System.Collections.Generic;
using Ntreev.Library.Psd;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace Psd2UGUI.Editor {
	public class PsdPreviewTreeView : TreeView {
		private readonly PsdDocument m_document;
		private readonly List<PsdPreviewTreeItem> m_rows = new List<PsdPreviewTreeItem>();
		private const float TOGGLE_WIDTH = 18;

		private const float ROW_HEIGHT = 20f;
		private static int m_globalId;

		public PsdPreviewTreeView(TreeViewState state, PsdDocument document) : base(state) {
			m_document = document;
			multiColumnHeader = new MultiColumnHeader(BuildHeader());
			rowHeight = ROW_HEIGHT;
			columnIndexForTreeFoldouts = 1;
			showAlternatingRowBackgrounds = true;
			showBorder = true;
			customFoldoutYOffset = ( ROW_HEIGHT - EditorGUIUtility.singleLineHeight ) * 0.5f;
		}

		protected override TreeViewItem BuildRoot() {
			var root = new PsdPreviewTreeItem(m_globalId, -1, m_document);
			GenerateRowsRecursive(root, 0);
			return root;
		}

		protected override IList<TreeViewItem> BuildRows(TreeViewItem root) {
			if( root == null ) {
				Debug.LogError("tree model root is null. did you call SetData()?");
			}

			m_rows.Clear();
			if( root.hasChildren ) {
				AddChildrenRecursive(root as PsdPreviewTreeItem, 0);
			}

			return m_rows.ConvertAll<TreeViewItem>(x => x);
		}

		protected override void RowGUI(RowGUIArgs args) {
			var item = (PsdPreviewTreeItem)args.item;
			if( Event.current.type == EventType.MouseDown && args.rowRect.Contains(Event.current.mousePosition) ) {
				SelectionClick(args.item, false);
			}

			for( int i = 0; i < args.GetNumVisibleColumns(); i++ ) {
				var rect = args.GetCellRect(i);
				CenterRectUsingSingleLineHeight(ref rect);

				var column = args.GetColumn(i);
				if( column == 0 ) {
					GUI.Label(rect, args.row.ToString());
				}
				else {
					var toggleRect = rect;
					toggleRect.x += GetContentIndent(item);
					toggleRect.width = TOGGLE_WIDTH;

					var texture = PsdUtility.GetLayerTexture(item);
					GUI.DrawTexture(toggleRect, texture);
					rect.x += TOGGLE_WIDTH;
					args.rowRect = rect;
					base.RowGUI(args);
				}
			}

		}

		private void AddChildrenRecursive(PsdPreviewTreeItem parent, int depth) {
			if( parent.Layer.Childs == null || parent.Layer.Childs.Length == 0 )
				return;

			foreach( var treeViewItem in parent.children ) {
				var child = (PsdPreviewTreeItem)treeViewItem;
				var item = new PsdPreviewTreeItem(child.id, depth, child.Layer);
				m_rows.Add(child);
				if( child.hasChildren ) {
					if( IsExpanded(child.id) ) {
						AddChildrenRecursive(child, depth + 1);
					}
					else {
						item.children = CreateChildListForCollapsedParent();
					}
				}
			}
		}

		private void GenerateRowsRecursive(PsdPreviewTreeItem parent, int depth) {
			if( parent.Layer.Childs == null || parent.Layer.Childs.Length == 0 )
				return;

			foreach( var layerChild in parent.Layer.Childs ) {
				var child = new PsdPreviewTreeItem(++m_globalId, depth, layerChild);
				parent.AddChild(child);
				GenerateRowsRecursive(child, depth + 1);
			}
		}

		private static MultiColumnHeaderState BuildHeader() {
			var columns = new[] {
				new MultiColumnHeaderState.Column {
					headerContent = new GUIContent(EditorGUIUtility.FindTexture("FilterByLabel")),
					headerTextAlignment = TextAlignment.Center,
					width = 30,
					minWidth = 30,
					maxWidth = 60,
					autoResize = false,
					allowToggleVisibility = false
				},
				new MultiColumnHeaderState.Column {
					headerContent = new GUIContent("Layer Name"),
					headerTextAlignment = TextAlignment.Left,
					width = 300,
					minWidth = 100,
					autoResize = false,
					allowToggleVisibility = false
				}
			};

			return new MultiColumnHeaderState(columns);
		}
	}
}