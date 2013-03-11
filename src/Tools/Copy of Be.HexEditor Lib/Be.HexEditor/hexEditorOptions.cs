/* User: Erin
 * Date: 2/12/2013
 * Time: 6:28 AM
 */
using Be.HexEditor;
using Be.Windows.Forms;
using System;

namespace Be.HexEditor
{
	/// <summary>
	/// Description of hexEditorOptions.
	/// </summary>
	public class hexEditorOptions {
		#region constructors
		public hexEditorOptions() { InitHexEditorOptions(); }
		public hexEditorOptions(IByteProvider ByteProvider, string filnam = "") {
			InitHexEditorOptions(ByteProvider, filnam);
		}
		public hexEditorOptions(string filnam) {
			InitHexEditorOptions(null, filnam);
		}
		public hexEditorOptions(
							bool ShowMnu_File              = true
						,	bool ShowMnu_Tools             = true

						,	bool ShowMnuItm_File_Exit      = true
						,	bool ShowMnuItm_File_Open      = true
						,	bool ShowMnuItm_File_Recent    = true
						,	bool ShowMnuItm_File_Save      = true
						) {
			
			InitHexEditorOptions(
				null
			,	""
			,	ShowMnu_File, ShowMnu_Tools
			,	ShowMnuItm_File_Exit
			,	ShowMnuItm_File_Open
			,	ShowMnuItm_File_Recent
			,	ShowMnuItm_File_Save
			);
		}
		
		protected virtual void InitHexEditorOptions(
							IByteProvider ByteProvider     = null
						,	string Filename                = ""
						,	bool ShowMnu_File              = true
						,	bool ShowMnu_Tools             = true

						,	bool ShowMnuItm_File_Exit      = true
						,	bool ShowMnuItm_File_Open      = true
						,	bool ShowMnuItm_File_Recent    = true
						,	bool ShowMnuItm_File_Save      = true
		
						) {
			
			byteProvider = ByteProvider;
			filename = Filename;

			showMnu_File = ShowMnu_File;
			showMnu_Tools = ShowMnu_Tools;

			showMnuItm_File_Exit = ShowMnuItm_File_Exit;
			showMnuItm_File_Open = ShowMnuItm_File_Open;
			showMnuItm_File_Recent = ShowMnuItm_File_Recent;
			showMnuItm_File_Save = ShowMnuItm_File_Save;
			
		}
		#endregion
		#region properties
		public virtual IByteProvider byteProvider    { get; set; }
		public virtual string filename               { get; set; }
		
		public virtual bool showMnu_File             { get; set; }
		public virtual bool showMnu_Tools            { get; set; }

		public virtual bool showMnuItm_File_Exit     { get; set; }
		public virtual bool showMnuItm_File_Open     { get; set; }
		public virtual bool showMnuItm_File_Recent   { get; set; }
		public virtual bool showMnuItm_File_Save     { get; set; }
		#endregion
	}
}
