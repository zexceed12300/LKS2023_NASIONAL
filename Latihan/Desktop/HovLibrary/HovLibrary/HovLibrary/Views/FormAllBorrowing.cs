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
    public partial class FormAllBorrowing : Form
    {
        HovLibraryDb context = new HovLibraryDb();
        public FormAllBorrowing()
        {
            InitializeComponent();
        }

        private void queryBorrow(bool filter = false)
        {
            var query = from borrow in context.Borrowings
                        join member in context.Members on borrow.member_id equals member.id
                        join bookdetail in context.BookDetails on borrow.bookdetails_id equals bookdetail.id
                        select new
                        {
                            id = borrow.id,
                            member = member.name,
                            book_id = bookdetail.book_id,
                            book_code = bookdetail.code,
                            borrow_date = borrow.borrow_date,
                            return_date = borrow.return_date,
                            fine = borrow.fine
                        };

            var filterData = query;
            if (filter)
            {
                if (cbBorrowStatus != null)
                {
                    DateTime future = DateTime.Now.AddDays(7);
                    switch(cbBorrowStatus.Text)
                    {
                        case "Ongoing":
                            filterData = query.Where(a => a.borrow_date <= future && a.return_date == null);
                            break;
                        case "Late":
                            filterData = query.Where(a => a.borrow_date >= future && a.return_date == null);
                            break;
                        case "Returned":
                            filterData = query.Where(a => a.return_date != null);
                            break;
                        default:
                            break;
                    }
                }
                if (dtpBorrowDateFrom.Value != null && dtpBorrowDateTo.Value != null)
                {
                    filterData = filterData.Where(a => a.borrow_date >= dtpBorrowDateFrom.Value && a.borrow_date <= dtpBorrowDateTo.Value);
                }
            }

            dgvBorrow.Rows.Clear();
            foreach (var item in filterData)
            {
                dgvBorrow.Rows.Add(
                    item.id,
                    item.member,
                    context.Books.Find(item.book_id).title,
                    item.book_code,
                    item.borrow_date,
                    item.return_date,
                    item.fine
                );
            }
        }

        private void FormAllBorrowing_Load(object sender, EventArgs e)
        {
            queryBorrow();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            queryBorrow(true);
        }
    }
}
