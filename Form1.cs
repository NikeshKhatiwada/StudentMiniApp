using MySql.Data.MySqlClient;

namespace StudentMiniApp
{
    public partial class Form1 : Form
    {
        List<Student> studentList;
        public Form0 form0;
        public Form1()
        {
            InitializeComponent();
            studentList = (new StudentController()).GetStudents();
            studentDataGrid.DataSource = studentList;
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Text = "Details";
            buttonColumn.Name = "Details";
            buttonColumn.UseColumnTextForButtonValue = true;
            studentDataGrid.Columns.Add(buttonColumn);
            studentDataGrid.CellContentClick += studentDataGrid_CellContentClick;
            form0 = new Form0();
            form0.MdiParent = this;
            form0.StartPosition = FormStartPosition.Manual;
            form0.Location = new Point(760, 10);
            form0.Show();
        }

        private void studentDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var currentRow = studentDataGrid.CurrentRow;
            (new StudentController()).SetStudentInfo((Student)currentRow.DataBoundItem);
            form0.ShowStudentInfo();
        }

        public void UpdateStudentList()
        {
            studentList = (new StudentController()).GetStudents();
            studentDataGrid.DataSource = studentList;
            studentDataGrid.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddEditForm addEditForm = new AddEditForm();
            addEditForm.ShowInsertFeatures();
            Student student = new Student();
            (new StudentController()).SetStudentInfo(student);
            addEditForm.ShowDialog();
        }
    }
}