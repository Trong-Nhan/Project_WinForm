using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_1
{
    public partial class frmTour : Form
    {
        public frmTour()
        {
            InitializeComponent();
        }
        //khai báo biến chứa dòng hiện tại
        int position;
        //khai báo biến lưu trạng thái thêm hay sửa
        bool edit = true;
        //Khởi tạo đối tượng quản lý Database (DataContext)
        ProjectDataContext hrm = new ProjectDataContext();
        private void DisplayEmployee()
        {
            //truy vấn lấy các thông tin cần thiết trong bảng Tours
            var employess = from emp in hrm.Tours
                            select new
                            {
                                Ma_Tour = emp.TourId,
                                Ten = emp.TourName,
                                Diem_den = emp.Destinations,
                                Gia_tien = emp.Price,
                                Mo_ta = emp.Describle,
                                Thoi_gian = emp.TourTime,
                                Phuong_tien_di_chuyen = emp.Vehicle,
                                Loai_Tour = emp.TourType,
                                Huong_dan_vien = emp.TourGuide
                            };
            //hiển thị lên lưới
            dgvTour.DataSource = employess;
            DisplayEmployeeDetail();
        }
        //phương thức hiển thị chi tiết tour du lịch của dòng hiện tại trên lưới lên form
        private void DisplayEmployeeDetail()
        {
            //nếu dòng hiện tại trên lưới khác null
            if (dgvTour.CurrentRow != null)
            {
                DataGridViewRow row = dgvTour.CurrentRow;
                txtId.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtDestinations.Text = row.Cells[2].Value.ToString();
                txtPrice.Text = row.Cells[3].Value.ToString();
                txtDescrible.Text = row.Cells[4].Value.ToString();
                txtTourTime.Text = row.Cells[5].Value.ToString();
                txtVehicle.Text = row.Cells[6].Value.ToString();
                txtTourType.Text = row.Cells[7].Value.ToString();
                txtTourGuide.Text = row.Cells[8].Value.ToString();
                position = dgvTour.CurrentRow.Index;
                edit = true;
                txtId.ReadOnly = true;
            }
        }
        private void frmTour_Load(object sender, EventArgs e)
        {
            //Hiển thị tour du lịch lên lưới
            DisplayEmployee();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //xóa trắng dữ liệu trên form
            txtId.Text = txtName.Text = txtPrice.Text = txtDestinations.Text = txtDescrible.Text = txtTourTime.Text = txtVehicle.Text = txtTourType.Text = txtTourGuide.Text = "";
            txtId.Focus();
            edit = false;
            txtId.ReadOnly = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                //tìm tour du lịch cần sửa có mã như trên form
                var emp = hrm.Tours.FirstOrDefault(x => x.TourId == txtId.Text);
                //nếu tìm thấy
                if (emp != null)
                {
                    //gán lại thông tin cho tour du lịch
                    emp.TourName = txtName.Text;
                    emp.Destinations = txtDestinations.Text;
                    emp.Price = Double.Parse(txtPrice.Text);
                    emp.Describle = txtDescrible.Text;
                    emp.TourTime = txtTourTime.Text;
                    emp.Vehicle = txtVehicle.Text;
                    emp.TourType = txtTourType.Text;
                    emp.TourGuide = txtTourGuide.Text;
                    //lưu
                    hrm.SubmitChanges();
                    //hiển thị lại dữ liệu
                    DisplayEmployee();
                    //hiển thị đúng vị trí dòng đã chọn trước đó
                    dgvTour.Rows[0].Selected = false;
                    dgvTour.Rows[position].Selected = true;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                //tạo mới tour du lịch
                var emp = new Tour();
                //gán giá trị
                emp.TourId = txtId.Text;
                emp.TourName = txtName.Text;
                emp.Destinations = txtDestinations.Text;
                emp.Price = Double.Parse(txtPrice.Text);
                emp.Describle = txtDescrible.Text;
                emp.TourTime = txtTourTime.Text;
                emp.Vehicle = txtVehicle.Text;
                emp.TourType = txtTourType.Text;
                emp.TourGuide = txtTourGuide.Text;
                hrm.Tours.InsertOnSubmit(emp);
                //lưu
                hrm.SubmitChanges();
                //hiển thị lại dữ liệu
                DisplayEmployee();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTour.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //tìm tour du lịch có mã như trên form
                    var emp = hrm.Tours.FirstOrDefault(x => x.TourId == txtId.Text);
                    if (emp != null)
                    {
                        //xóa dữ liệu
                        hrm.Tours.DeleteOnSubmit(emp);
                        //lưu
                        hrm.SubmitChanges();
                        //hiển thị lại dữ liệu
                        DisplayEmployee();
                    }
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //hiển thị lại chi tiết tour du lịch
            DisplayEmployeeDetail();
        }

        private void dgvTour_Click(object sender, EventArgs e)
        {
            //hiển thị chi tiết tour du lịch khi kích vào lưới
            DisplayEmployeeDetail();
        }

    }
}
