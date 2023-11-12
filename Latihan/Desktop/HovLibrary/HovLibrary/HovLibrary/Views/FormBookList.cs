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
    public partial class FormBookList : Form
    {
        int book_id;

        HovLibraryDb context = new HovLibraryDb();

        int bookdetail_id;
        int location_id;

        public FormBookList(int id)
        {
            InitializeComponent();
            book_id = id;

            tbTitle.Text = context.Books.FirstOrDefault(x => x.id == id).title;

            var location = context.Locations.ToList();
            foreach (var item in location)
            {
                cbLocation.Items.Add(item.name);
            }
        }

        private void queryBookList()
        {
            var query = context.BookDetails.Where(x => x.book_id == book_id).ToList();

            foreach (var item in query)
            {
                bool status = false;
                var borrowing = context.Borrowings.FirstOrDefault(x => x.bookdetails_id == book_id);
                if (borrowing == null)
                    status = true;

                dgvBookDetails.Rows.Add(
                    item.id,
                    item.code,
                    item.location_id,
                    status ? "available" : "unavailable",
                    "delete"
                );
            }
        }

        private void FormBookList_Load(object sender, EventArgs e)
        {
            queryBookList();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbLocation.Text != "" && tbCode.Text != "")
                {
                    
                    context.BookDetails.Add(new BookDetail
                    {
                        book_id = book_id,
                        location_id = location_id,
                        code = string.Format("{0}.{1}.{2}.{3}", bookdetail_id.ToString("D4"), book_id.ToString("D4"), location_id.ToString("D4"), DateTime.Now.Year.ToString("D4")),
                        created_at = DateTime.Now,
                    });
                    MessageBox.Show("Bookdetails added!");
                } else
                {
                    MessageBox.Show("Please fill form!");
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbLocation_TextChanged(object sender, EventArgs e)
        {
            bookdetail_id = context.BookDetails.Count() + 1;
            location_id = context.Locations.FirstOrDefault(x => x.name == cbLocation.Text).id;
            tbCode.Text = string.Format("{0}.{1}.{2}.{3}", bookdetail_id.ToString("D4"), book_id.ToString("D4"), location_id.ToString("D4"), DateTime.Now.Year.ToString("D4"));
        }

        private void dgvBookDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBookDetails.Columns[e.ColumnIndex].Name == "delete")
            {
                try
                {
                    var bookdetail = context.BookDetails.Find(dgvBookDetails.SelectedCells[0].OwningRow.Cells[0].Value);
                    if (bookdetail != null)
                    {
                        bookdetail.deleted_at = DateTime.Now;
                        context.SaveChanges();
                        MessageBox.Show("deleted!");
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
