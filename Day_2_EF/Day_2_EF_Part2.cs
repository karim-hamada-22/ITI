public partial class MainForm : Form
{
    private readonly Repository<Student> _studentRepo;
    private Student _selectedStudent;

    public MainForm()
    {
        InitializeComponent();
        _studentRepo = new Repository<Student>(new UniversityContext());
        LoadData();
    }

    private void LoadData()
    {
        dataGridView1.DataSource = _studentRepo.GetAll().ToList();
        ResetForm();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        var student = new Student { Name = txtName.Text, Age = int.Parse(txtAge.Text) };
        _studentRepo.Add(student);
        LoadData();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (_selectedStudent != null)
        {
            _selectedStudent.Name = txtName.Text;
            _selectedStudent.Age = int.Parse(txtAge.Text);
            _studentRepo.Update(_selectedStudent);
            LoadData();
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (_selectedStudent != null)
        {
            _studentRepo.Delete(_selectedStudent);
            LoadData();
        }
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            _selectedStudent = (Student)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            txtName.Text = _selectedStudent.Name;
            txtAge.Text = _selectedStudent.Age.ToString();

            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnReset.Enabled = true;
        }
    }

    private void btnReset_Click(object sender, EventArgs e) => ResetForm();

    private void ResetForm()
    {
        txtName.Clear();
        txtAge.Clear();
        _selectedStudent = null;

        btnAdd.Enabled = true;
        btnUpdate.Enabled = false;
        btnDelete.Enabled = false;
        btnReset.Enabled = false;
    }
}
