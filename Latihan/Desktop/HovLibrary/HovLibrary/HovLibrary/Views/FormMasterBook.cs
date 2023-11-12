using HovLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HovLibrary.Views
{
    public partial class FormMasterBook : Form
    {
        HovLibraryDb context = new HovLibraryDb();

        int selectedId;

        public FormMasterBook()
        {
            InitializeComponent();
        }

        private void queryBook(bool filter = false)
        {
            var books = from book in context.Books
                    join language in context.Languages on book.language_id equals language.id
                    join publisher in context.Publishers on book.publisher_id equals publisher.id
                    where book.deleted_at == null
                    select new { 
                        id = book.id, 
                        language = language.long_text, 
                        title = book.title, 
                        isbn = book.isbn, 
                        isbn13 = book.isbn13, 
                        authors = book.authors, 
                        publisher = publisher.name, 
                        publication_date = book.publication_date, 
                        number_of_pages = book.number_of_pages, 
                        average_rating = book.average_rating,
                        ratings_count = book.ratings_count,
                    };

            var search = books;
            if (tbKeyword.Text != "")
            {
                switch(cbSearchBy.Text) {
                    case "title":
                        search = books.Where(e => e.title.Contains(tbKeyword.Text));
                        break;
                    case "author":
                        search = books.Where(e => e.authors.Contains(tbKeyword.Text));
                        break;
                    case "publisher":
                        search = books.Where(e => e.publisher.Contains(tbKeyword.Text));
                        break;
                    default:
                        break;
                };
            }

            var filterData = search;
            if (filter)
            {
                if (cbFilterLanguage.Text != "")
                {
                    filterData = filterData.Where(e => e.language.Contains(cbFilterLanguage.Text));
                }
                if (dtpFilterPublishDateFrom.Text != "" && dtpFilterPublishDateTo.Text != "")
                {
                    filterData = filterData.Where(e => e.publication_date >= dtpFilterPublishDateFrom.Value && e.publication_date <= dtpFilterPublishDateTo.Value);
                }
                if (tbPageCountFrom.Text != "" && tbPageCountTo.Text != "")
                {
                    filterData = filterData.Where(e => e.number_of_pages >= Convert.ToInt32(tbPageCountFrom.Text) && e.number_of_pages <= Convert.ToInt32(tbPageCountTo.Text));
                }
                if (tbRatingsFrom.Text != "" && tbRatingsTo.Text != "")
                {
                    filterData = filterData.Where(e => e.average_rating >= Convert.ToDouble(tbRatingsFrom.Text) && e.average_rating <= Convert.ToDouble(tbRatingsTo.Text));
                }
            }

            dgvBook.Rows.Clear();
            foreach (var book in filterData)
            {
                dgvBook.Rows.Add(
                    book.id,
                    book.language,
                    book.title,
                    book.isbn,
                    book.isbn13,
                    book.authors,
                    book.publisher,
                    book.publication_date,
                    book.number_of_pages,
                    string.Format("{0} ({1})", book.average_rating, book.ratings_count),
                    "show",
                    "edit",
                    "delete"
                );
            }
        }

        private void FormMasterBook_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hovLibraryDataSet1.Book' table. You can move, or remove it, as needed.
            //this.bookTableAdapter.Fill(this.hovLibraryDataSet1.Book);

            queryBook();

            var language = context.Languages.ToList();
            foreach (var lang in language)
            {
                cbFilterLanguage.Items.Add(lang.long_text);
                cbLanguage.Items.Add(lang.long_text);
            }

            var publisher = context.Publishers.ToList();
            foreach (var pub in publisher)
            {
                cbPublisher.Items.Add(pub.name);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            queryBook();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            queryBook(true);
        }

        private void dgvBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedId = Convert.ToInt32(dgvBook.SelectedCells[0].OwningRow.Cells[0].Value);
                var book = context.Books.Find(selectedId);

                if (dgvBook.Columns[e.ColumnIndex].Name == "edit")
                {
                    panelInput.Enabled = true;
                    btnSave.Enabled = true;
                    cbLanguage.Text = context.Languages.FirstOrDefault(x => x.id == book.language_id).long_text;
                    tbTitle.Text = book.title;
                    tbIsbn.Text = book.isbn;
                    tbIsbn13.Text = book.isbn13;
                    tbAuthors.Text = book.authors;
                    cbPublisher.Text = context.Publishers.FirstOrDefault(x => x.id == book.publisher_id).name;
                    dtpPublishDate.Value = book.publication_date;
                    tbPageCount.Text = book.number_of_pages.ToString();
                    tbRatingCount.Text = book.ratings_count.ToString();
                    tbRatingAverage.Text = book.average_rating.ToString();
                }
                else if (dgvBook.Columns[e.ColumnIndex].Name == "show")
                {
                    FormBookList form = new FormBookList(selectedId);
                    form.MdiParent = FormMain.ActiveForm;
                    form.Show();
                }
                else if (dgvBook.Columns[e.ColumnIndex].Name == "delete")
                {
                    book.deleted_at = DateTime.Now;
                    context.SaveChanges();
                    MessageBox.Show("Book deleted!");
                    queryBook();
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbLanguage.Text != "" && tbTitle.Text != "" && tbIsbn.Text != "" && tbIsbn13.Text != "" && tbAuthors.Text != "" && cbPublisher.Text != "" && dtpPublishDate.Text != "" && tbPageCount.Text != "" && tbRatingAverage.Text != "" & tbRatingCount.Text != "")
                {
                    var book = context.Books.Find(selectedId);
                    book.language_id = context.Languages.FirstOrDefault(x => x.long_text == cbLanguage.Text).id;
                    book.title = tbTitle.Text;
                    book.isbn = tbIsbn.Text;
                    book.isbn13 = tbIsbn13.Text;
                    book.authors = tbAuthors.Text;
                    book.publisher_id = context.Publishers.FirstOrDefault(x => x.name == cbPublisher.Text).id;
                    book.publication_date = dtpPublishDate.Value;
                    book.number_of_pages = Convert.ToInt32(tbPageCount.Text);
                    book.ratings_count = Convert.ToInt32(tbRatingCount.Text);
                    book.average_rating = Convert.ToDouble(tbRatingAverage.Text);
                    book.last_updated_at = DateTime.Now;
                    context.SaveChanges();
                    MessageBox.Show("Book edited!");
                } else
                {
                    MessageBox.Show("Please fill form!");
                }
                queryBook();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
