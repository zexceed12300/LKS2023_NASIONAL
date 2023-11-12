using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HovLibrary.Views
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void memberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMasterMember member = new FormMasterMember();
            member.MdiParent = FormMain.ActiveForm;
            member.Show();
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMasterBook book = new FormMasterBook();
            book.MdiParent = FormMain.ActiveForm;
            book.Show();
        }

        private void newBorrowingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNewBorrowing form = new FormNewBorrowing();
            form.MdiParent = FormMain.ActiveForm;
            form.Show();
        }

        private void allBorrowingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAllBorrowing form = new FormAllBorrowing();
            form.MdiParent= FormMain.ActiveForm;
            form.Show();
        }
    }
}
