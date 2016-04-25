using System;
using System.Collections.Generic; 
using System.Linq; 
using System.Windows.Forms;

namespace SharedReferenceFileAdder
{
    public partial class MainForm : Form
    {
        private string _path;
        private string _sharedReferenceFolderPath; 
        private List<string> _csprojList;

        private readonly IUserFileHelper _iUserFileHelper;

        public MainForm(IUserFileHelper iUserFileHelper)
        {
            _iUserFileHelper = iUserFileHelper;
            InitializeComponent();
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSharedFolderPath.Text))
            {
                MessageBox.Show(@"Enter Shared reference Folder");
                return;
            } 

            if (fbdMain.ShowDialog() != DialogResult.OK)
                return;

            _path = fbdMain.SelectedPath;

            _csprojList = _iUserFileHelper.DirSearch(_path).Where(p => p.EndsWith(".csproj")).ToList();

            MessageBox.Show(_iUserFileHelper.UserFileCreator(_csprojList, _sharedReferenceFolderPath)
                ? @"User Files Has been Created Successfully"
                : @"Shared Folder Doesn't Exist Or Typed Several Times");
        } 

        private void txtSharedFolderPath_TextChanged(object sender, EventArgs e)
        {
            _sharedReferenceFolderPath = txtSharedFolderPath.Text;
        }
    }
}
