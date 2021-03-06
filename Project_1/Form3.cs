using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private void DisplayTour()
        {
            //truy vấn lấy các thông tin cần thiết trong bảng Tours
            var tours = from tr in hrm.Tours
                            select new
                            {
                                Ma_Tour = tr.TourId,
                                Ten = tr.TourName,
                                Diem_den = tr.Destinations,
                                Gia_tien = tr.Price,
                                Mo_ta = tr.Describle,
                                Thoi_gian = tr.TourTime,
                                Phuong_tien_di_chuyen = tr.Vehicle,
                                Loai_Tour = tr.TourType,
                                Huong_dan_vien = tr.TourGuide
                            };
            //hiển thị lên lưới
            dgvTour.DataSource = tours;
            DisplayTourDetail();
        }
        //phương thức hiển thị chi tiết tour du lịch của dòng hiện tại trên lưới lên form
        private void DisplayTourDetail()
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
            DisplayTour();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //xóa trắng dữ liệu trên form
            txtId.Text = txtName.Text = txtPrice.Text = txtDestinations.Text = txtDescrible.Text = txtTourTime.Text = txtVehicle.Text = txtTourType.Text = txtTourGuide.Text = "";
            txtId.Focus();
            edit = false;
            txtId.ReadOnly = false;
        }
        // Validate trường nhập được yêu cầu. Trả về true khi trường nhập hợp lệ
        private bool ValidateRequiredField(ErrorProvider err, TextBox txt)
        {
            if (txt.Text.Length > 0)
            {
                // Xóa lỗi
                err.SetError(txt, "");
                return false;
            }
            else
            {
                // Thông báo lỗi
                err.SetError(txt, CamelCaseToWords(txt.Name) + " không được để trống.");
                return true;
            }
        }

        // Validate các trường nhập
        private void txtRequiredField_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = sender as TextBox;
            ValidateRequiredField(errField, txt);
        }

        // Tách một chuỗi trong camelCase, xóa tiền tố
        private string CamelCaseToWords(string input)
        {
            // Chèn một khoảng trắng trước mỗi chữ cái viết hoa
            string result = "";
            foreach (char ch in input.ToCharArray())
            {
                if (char.IsUpper(ch)) result += " ";
                result += ch;
            }

            // Tìm khoảng trống đầu tiên và xóa mọi thứ trước nó
            return result.Substring(result.IndexOf(" ") + 1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                //tìm tour du lịch cần sửa có mã như trên form
                var tr = hrm.Tours.FirstOrDefault(x => x.TourId == txtId.Text);
                //nếu tìm thấy
                if (tr != null)
                {
                    // Validate tất cả các trường nhập
                    ValidateRequiredField(errField, txtId);
                    ValidateRequiredField(errField, txtName);
                    ValidateRequiredField(errField, txtDestinations);
                    ValidatePrice(errField, txtPrice);
                    ValidateRequiredField(errField, txtDescrible);
                    ValidateRequiredField(errField, txtTourTime);
                    ValidateRequiredField(errField, txtVehicle);
                    ValidateRequiredField(errField, txtTourType);
                    ValidateRequiredField(errField, txtTourGuide);
                    // Hiển thị khi bất kỳ trường nhập nào lỗi
                    foreach (Control ctl in Controls)
                    {
                        if (errField.GetError(ctl) != "")
                        {
                            MessageBox.Show(errField.GetError(ctl));
                            return;
                        }
                    }
                    //gán lại thông tin cho tour du lịch
                    tr.TourName = txtName.Text;
                    tr.Destinations = txtDestinations.Text;
                    tr.Price = Double.Parse(txtPrice.Text);
                    tr.Describle = txtDescrible.Text;
                    tr.TourTime = txtTourTime.Text;
                    tr.Vehicle = txtVehicle.Text;
                    tr.TourType = txtTourType.Text;
                    tr.TourGuide = txtTourGuide.Text;
                    //lưu
                    hrm.SubmitChanges();
                    //hiển thị lại dữ liệu
                    DisplayTour();
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
                var tr = new Tour();
                // Validate tất cả các trường nhập
                ValidateRequiredField(errField, txtId);
                ValidateRequiredField(errField, txtName);
                ValidateRequiredField(errField, txtDestinations);
                ValidatePrice(errField, txtPrice);
                ValidateRequiredField(errField, txtDescrible);
                ValidateRequiredField(errField, txtTourTime);
                ValidateRequiredField(errField, txtVehicle);
                ValidateRequiredField(errField, txtTourType);
                ValidateRequiredField(errField, txtTourGuide);
                // Hiển thị khi bất kỳ trường nhập nào lỗi
                foreach (Control ctl in Controls)
                {
                    if (errField.GetError(ctl) != "")
                    {
                        MessageBox.Show(errField.GetError(ctl));
                        return;
                    }
                }
                //gán giá trị
                tr.TourId = txtId.Text;
                tr.TourName = txtName.Text;
                tr.Destinations = txtDestinations.Text;
                tr.Price = Double.Parse(txtPrice.Text);
                tr.Describle = txtDescrible.Text;
                tr.TourTime = txtTourTime.Text;
                tr.Vehicle = txtVehicle.Text;
                tr.TourType = txtTourType.Text;
                tr.TourGuide = txtTourGuide.Text;
                hrm.Tours.InsertOnSubmit(tr);
                //lưu
                hrm.SubmitChanges();
                //hiển thị lại dữ liệu
                DisplayTour();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTour.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //tìm tour du lịch có mã như trên form
                    var tr = hrm.Tours.FirstOrDefault(x => x.TourId == txtId.Text);
                    if (tr != null)
                    {
                        //xóa dữ liệu
                        hrm.Tours.DeleteOnSubmit(tr);
                        //lưu
                        hrm.SubmitChanges();
                        //hiển thị lại dữ liệu
                        DisplayTour();
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
            DisplayTourDetail();
        }

        private void dgvTour_Click(object sender, EventArgs e)
        {
            //hiển thị chi tiết tour du lịch khi kích vào lưới
            DisplayTourDetail();
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            ValidatePrice(errField, txtPrice);
        }
        // Validate Price
        private void ValidatePrice(ErrorProvider err, TextBox txt)
        {
            // Kiểm tra trường bị trống
            if (ValidateRequiredField(err, txt)) return;

            // Kiểm tra trường có ghi đúng cú pháp hay không
            Regex regex = new Regex(@"^[0-9]*$");
            if (regex.IsMatch(txt.Text))
            {
                // Xoá lỗi
                errField.SetError(txt, "");
            }
            else
            {
                // Hiển thị lỗi
                errField.SetError(txt, "Giá tiền phải là số.");
            }
        }
    }
}
