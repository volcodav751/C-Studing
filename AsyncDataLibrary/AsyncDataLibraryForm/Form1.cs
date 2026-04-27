using AsyncDataLibrary.Services;

namespace AsyncDataLibraryForm

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            await BookProcessing.PrintAllBooks;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookProcessing.CreateBook(int );
        }
    }
}
