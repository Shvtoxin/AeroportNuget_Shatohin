using System.Numerics;
using System.Windows.Forms;
using Aeroport.Classes;

namespace Aeroport
{
    public partial class Aero : Form
    {
        private readonly ClassLi.Func<Flight> flight;
        private readonly BindingSource bindingSource;
        private decimal sum = 0;
        public Aero()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            flight = new ClassLi.Func<Flight>();
            bindingSource = new BindingSource();
            bindingSource.DataSource = flight.Get();
            dataGridView1.DataSource = bindingSource;
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            ChangeMenu.Enabled = DeleteMenu.Enabled = Change.Enabled = Delete.Enabled = dataGridView1.SelectedRows.Count > 0;
        }
        public void CalculateStats()
        {
            var count = flight.Get().Count;
            var Res = 0.0m;
            var Pass = 0.0m;
            var ColB = 0.0m;
            toolStripStatusLabel1.Text = $"Кол-во рейсов: " + count;
            foreach (var plane in flight.Get())
            {
                Pass += plane.ColPas;
                ColB += plane.ColBuil;
                Res += (plane.ColPas * plane.Pass + plane.ColBuil * plane.Build) * ((100.0m + plane.Percent) / 100.0m);
            }
            toolStripStatusLabel2.Text = $"Кол-во пассажиров: " + Pass;
            toolStripStatusLabel3.Text = $"Кол-во экипажа: " + ColB;
            toolStripStatusLabel4.Text = $"Сумма всей выручки: " + Res;
        }

        public void dataGridView1_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Выручка")
            {
                var data = (Flight)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                sum += (data.ColPas * data.Pass + data.ColBuil * data.Build) * ((100.0m + data.Percent) / 100.0m);
                e.Value = sum;
                sum = 0;
            }
        }
        private void Add_Click(object sender, EventArgs e)
        {
            var info = new InfoAir();
            info.Text = "Информация о полёте";
            if (info.ShowDialog(this) == DialogResult.OK)
            {
                flight.Add(info.Flight);
                bindingSource.ResetBindings(false);
                CalculateStats();
            }
        }

        public void Change_Click(object sender, EventArgs e)
        {
            var data = (Flight)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
            var info = new InfoAir(data);
            info.Text = "Информация о полёте";
            if (info.ShowDialog(this) == DialogResult.OK)
            {
                data.Numfl = info.Flight.Numfl;
                data.TypeAir = info.Flight.TypeAir;
                data.ColPas = info.Flight.ColPas;
                data.ColBuil = info.Flight.ColBuil;
                data.Pass = info.Flight.Pass;
                data.Build = info.Flight.Build;
                data.Percent = info.Flight.Percent;
                data.TimeIn = info.Flight.TimeIn;
                flight.Change(dataGridView1.SelectedRows[0].Index, info.Flight);

                bindingSource.ResetBindings(false);
                CalculateStats();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var data = (Flight)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
            if (MessageBox.Show($"Вы желаете удалить информацию о полете '{data.Numfl}'?",
                "Удалить запись",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                flight.Remove(data);
                bindingSource.ResetBindings(false);
                CalculateStats();
            }
        }

        private void AddMenu_Click_1(object sender, EventArgs e)
        {
            Add_Click(sender, e);
        }

        private void ChangeMenu_Click(object sender, EventArgs e)
        {
            Change_Click(sender, e);
        }

        private void DeleteMenu_Click(object sender, EventArgs e)
        {
            Delete_Click(sender, e);
        }

        private void AboutProgrammMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("На данном ресурсе предоставлена информация о рейсах Аэропорта. \nВыполнено Шатохиным Александром Ип-20-3", "Аэропорт",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
