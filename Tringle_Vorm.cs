using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tringle
{
    public partial class Tringle_Vorm : Form
    {

        private Triangle triangle;
        public Tringle_Vorm()
        {
            InitializeComponent();
            InitializeCustomComponents();
            Side();

            triangle = new Triangle(3, 4, 5);
            DisplayTriangleInfo();
        }
        //Testig

        private void InitializeCustomComponents()
        {
            Button startButton = new Button();
            startButton.Text = "Start";
            startButton.Font = new Font("Arial", 28, FontStyle.Regular);
            startButton.Size = new Size(150, 80);
            startButton.BackColor = Color.Pink;
            startButton.ForeColor = Color.White;
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.FlatAppearance.BorderColor = Color.Black;
            startButton.Location = new Point(550, 50);

            startButton.Click += StartButton_Click;

            Controls.Add(startButton);
        }

        private void DisplayTriangleInfo()
        {
            DataGridView dataGridView = new DataGridView
            {
                ColumnCount = 2,
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                ColumnHeadersVisible = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                ScrollBars = ScrollBars.None
            };

            dataGridView.Size = new System.Drawing.Size(400, 250);
            dataGridView.Location = new System.Drawing.Point(10, 10);

            dataGridView.Columns[0].Name = "Поле";
            dataGridView.Columns[1].Name = "Значение";
            dataGridView.DefaultCellStyle.Padding = new Padding(5);

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
            {
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = Color.LightGray,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            dataGridView.ColumnHeadersDefaultCellStyle = headerStyle;
            dataGridView.ColumnHeadersHeight = 40;

            dataGridView.Rows.Add("Сторона a", " ");
            dataGridView.Rows.Add("Сторона b", " ");
            dataGridView.Rows.Add("Сторона c", " ");
            dataGridView.Rows.Add("Периметр", " ");
            dataGridView.Rows.Add("Площадь", " ");
            dataGridView.Rows.Add("Существует?", " ");
            dataGridView.Rows.Add("Спецификатор", "");

            Controls.Add(dataGridView);
        }

        private void Side()
        {
            Button startButton = new Button
            {
                Text = "Start",
                Font = new Font("Arial", 28, FontStyle.Regular),
                Size = new Size(150, 80),
                BackColor = Color.Pink,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(550, 50)
            };
            startButton.FlatAppearance.BorderColor = Color.Black;
            startButton.Click += StartButton_Click;
            Controls.Add(startButton);

            Label labelA = new Label
            {
                Text = "Сторона A:",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Blue,
                Location = new Point(10, 270),
                AutoSize = true
            };
            Controls.Add(labelA);

            TextBox textBoxA = new TextBox
            {
                Name = "textBoxA",
                Font = new Font("Arial", 12, FontStyle.Regular),
                Location = new Point(150, 270),
                Size = new Size(100, 30)
            };
            Controls.Add(textBoxA);

            Label labelB = new Label
            {
                Text = "Сторона B:",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Blue,
                Location = new Point(10, 310),
                AutoSize = true
            };
            Controls.Add(labelB);

            TextBox textBoxB = new TextBox
            {
                Name = "textBoxB",
                Font = new Font("Arial", 12, FontStyle.Regular),
                Location = new Point(150, 310),
                Size = new Size(100, 30)
            };
            Controls.Add(textBoxB);

            Label labelC = new Label
            {
                Text = "Сторона C:",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Blue,
                Location = new Point(10, 350),
                AutoSize = true
            };
            Controls.Add(labelC);

            TextBox textBoxC = new TextBox
            {
                Name = "textBoxC",
                Font = new Font("Arial", 12, FontStyle.Regular),
                Location = new Point(150, 350),
                Size = new Size(100, 30)
            };
            Controls.Add(textBoxC);
        }

        private void StartButton_Click(object? sender, EventArgs e)
        {
            double a, b, c;

            if (double.TryParse(Controls["textBoxA"].Text, out a) &&
                double.TryParse(Controls["textBoxB"].Text, out b) &&
                double.TryParse(Controls["textBoxC"].Text, out c) )
            {
                triangle = new Triangle(a, b, c);

                Controls.OfType<DataGridView>().FirstOrDefault()?.Rows.Clear();

                DataGridView dataGridView = Controls.OfType<DataGridView>().FirstOrDefault();
                if (dataGridView != null)
                {
                    dataGridView.Rows.Add("Сторона a", triangle.GetSetA);
                    dataGridView.Rows.Add("Сторона b", triangle.GetSetB);
                    dataGridView.Rows.Add("Сторона c", triangle.GetSetC);
                    dataGridView.Rows.Add("Периметр", triangle.Perimeter());
                    dataGridView.Rows.Add("Площадь", triangle.Area());
                    dataGridView.Rows.Add("Существует?", triangle.ExistTriangle ? "Существует" : "Не существует");
                    dataGridView.Rows.Add("Спецификатор", triangle.TriangleType);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные значения для сторон треугольника.");
            }
        }              
    }
}
