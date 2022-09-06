using DataAccess.ConcrateRepository;
using DataAccess.Context;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class Form1 : Form
    {
        private CodeFirstDbContext _codeFirstDbContext;
        private SchoolRepository _schoolRepository;
        private TeacherRepository _teacherRepository;
        public Form1()
        {
            _codeFirstDbContext = new CodeFirstDbContext();
            _schoolRepository = new SchoolRepository(_codeFirstDbContext);
            _teacherRepository = new TeacherRepository(_codeFirstDbContext);

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            School eklenecekOkul = new School();
            eklenecekOkul.Name = txt_okulAdi.Text;
            eklenecekOkul.NumberofEmployee = Convert.ToInt32(txt_calisanSayisi.Text);
            eklenecekOkul.NumberOfStudent = Convert.ToInt32(txt_ogrenciSayisi.Text);

            _schoolRepository.Add(eklenecekOkul);
        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _schoolRepository.GetAll();
        }

        int aranacakOkulID;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            aranacakOkulID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            var silinecekOkul = _schoolRepository.GetById(aranacakOkulID);
            silinecekOkul.DeletedDate = DateTime.Now;
            _schoolRepository.Delete(silinecekOkul);
            dataGridView1.DataSource = _schoolRepository.GetAll();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            var guncellenecekOkul = _schoolRepository.GetById(aranacakOkulID);

            guncellenecekOkul.Name = txt_okulAdi.Text;
            guncellenecekOkul.NumberOfStudent = Convert.ToInt32(txt_ogrenciSayisi.Text);
            guncellenecekOkul.NumberofEmployee = Convert.ToInt32(txt_calisanSayisi.Text);
            guncellenecekOkul.ModifiedDate = DateTime.Now;
            guncellenecekOkul.ModifiedBy = "Şahin Uzun";
            _schoolRepository.Update(guncellenecekOkul);

            dataGridView1.DataSource = _schoolRepository.GetAll();
            Clear();

        }

        private void Clear()
        {
            foreach (var item in this.groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = " ";

                    }
            }
        }
    }
}
