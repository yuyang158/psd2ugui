using Ntreev.Library.Psd;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace Psd2UGUI.Editor {
	public class PsdCheckWindow : EditorWindow {
		[MenuItem("Window/Psd-Preview")]
		private static void OpenPSDConfigWindow() {
			var window = GetWindow<PsdCheckWindow>();
			window.position = new Rect(100, 100, 800, 600);
			window.titleContent = new GUIContent("预览PSD文件");
			window.Repaint();
		}

		private PsdPreviewTreeView m_treeView;
		private PsdDocument m_document;
		[SerializeField]
		private TreeViewState m_treeViewState = new TreeViewState();
		private void OnEnable() {
			m_document = PsdDocument.Create(@"E:\Git\psd2ugui\Assets\1111.psb");
			m_treeView = new PsdPreviewTreeView(m_treeViewState, m_document);
			m_treeView.Reload();
		}

		private void OnDisable() {
			m_document?.Dispose();
		}

		private void OnGUI() {
			var full = new Rect(0, 0, position.width, position.height);
			m_treeView.OnGUI(full);
		}
	}
}