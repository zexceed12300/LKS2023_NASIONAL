using HovLibrary.Models;
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
    public partial class FormNewBorrowing : Form
    {
        HovLibraryDb context = new HovLibraryDb();

        int book_id;
        int member_id;

        public FormNewBorrowing()
        {
            InitializeComponent();
        }

        private void queryBookList()
        {
            var query = context.BookDetails.Where(x => x.book_id == book_id).ToList();

            dgvBookDetails.Rows.Clear();
            foreach (var item in query)
            {
                bool status = true;
                var borrowing = context.Borrowings.FirstOrDefault(x => x.bookdetails_id == book_id);
                if (borrowing != null)
                    continue;

                dgvBookDetails.Rows.Add(
                    item.id,
                    item.code,
                    item.location_id,
                    status ? "available" : "unavailable"
                );
            }
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            if (tbTitle.AutoCompleteCustomSource.Contains(tbTitle.Text))
            {
                book_id = context.Books.FirstOrDefault(a => a.title == tbTitle.Text).id;
                queryBookList();
            }
        }

        private void FormNewBorrowing_Load(object sender, EventArgs e)
        {
            var book = context.Books.ToList();
            AutoCompleteStringCollection acTitle = new AutoCompleteStringCollection();
            foreach (var item in book)
            {
                acTitle.Add(item.title);
            }
            tbTitle.AutoCompleteCustomSource = acTitle;
            tbTitle.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbTitle.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var member = context.Members.ToList();
            AutoCompleteStringCollection acMember = new AutoCompleteStringCollection();
            foreach (var item in member)
            {
                acMember.Add(item.name);
            }
            tbMember.AutoCompleteCustomSource = acMember;
            tbMember.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbMember.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvBookDetails.Rows)
                {

                    context.Borrowings.Add(new Borrowing
                    {
                        member_id = member_id,
                        bookdetails_id = Convert.ToInt32(row.Cells[0].Value),
                        borrow_date = DateTime.Now,
                    });
                }
                MessageBox.Show("Borrowing success!");
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbMember_TextChanged(object sender, EventArgs e)
        {
            if (tbMember.AutoCompleteCustomSource.Contains(tbMember.Text))
            {
                var member = context.Members.FirstOrDefault(a => a.name == tbMember.Text);
                member_id = member.id;
            }
        }
    }
}
