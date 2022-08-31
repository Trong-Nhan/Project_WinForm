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
                        join vh in hrm.Vehicles on tr.VehicleId equals vh.Id
                        join tt in hrm.TourTypes on tr.TourTypeId equals tt.Id
                        join tg in hrm.TourGuides on tr.TourGuideId equals tg.Id
                        select new
                        {
                            Ma_Tour = tr.TourId,
                            Ten = tr.TourName,
                            Diem_den = tr.Destinations,
                            Gia_tien = tr.Price,
                            Mo_ta = tr.Describle,
                            Thoi_gian = tr.TourTime,
                            Ma_phuong_tien_di_chuyen = tr.VehicleId,
                            Ma_loai_tour = tr.TourTypeId,
                            Ma_huong_dan_vien = tr.TourGuideId,
                            Phuong_tien_di_chuyen = vh.Name,
                            Loai_Tour = tt.Name,
                            Huong_dan_vien = tg.Name
                        };
            //hiển thị lên lưới
            dgvTour.DataSource = tours;
            this.dgvTour.Columns["Ma_Tour"].HeaderText = "Mã tour";
            this.dgvTour.Columns["Ten"].HeaderText = "Tên tour";
            this.dgvTour.Columns["Diem_den"].HeaderText = "Điểm đến";
            this.dgvTour.Columns["Gia_tien"].HeaderText = "Giá tiền";
            this.dgvTour.Columns["Mo_ta"].HeaderText = "Mô tả";
            this.dgvTour.Columns["Thoi_gian"].HeaderText = "Thời gian";
            this.dgvTour.Columns["Phuong_tien_di_chuyen"].HeaderText = "Phương tiện di chuyển";
            this.dgvTour.Columns["Loai_Tour"].HeaderText = "Loại tour";
            this.dgvTour.Columns["Huong_dan_vien"].HeaderText = "Hướng dẫn viên";

            this.dgvTour.Columns["Ma_phuong_tien_di_chuyen"].Visible = false;
            this.dgvTour.Columns["Ma_loai_tour"].Visible = false;
            this.dgvTour.Columns["Ma_huong_dan_vien"].Visible = false;
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
                cboVehicle.SelectedValue = int.Parse(row.Cells[6].Value.ToString());
                cboTourType.SelectedValue = int.Parse(row.Cells[7].Value.ToString());
                cboTourGuide.SelectedValue = int.Parse(row.Cells[8].Value.ToString());
                position = dgvTour.CurrentRow.Index;
                edit = true;
                txtId.ReadOnly = true;
            }
        }
        private void frmTour_Load(object sender, EventArgs e)
        {
            //Hiển thị tour du lịch lên lưới
            DisplayTour();
            //Hiển thị vehicle lên combobox
            DisplayVehicle();
            //Hiển thị tourtype lên combobox
            DisplayTourType();
            //Hiển thị tourguide lên combobox
            DisplayTourGuide();
        }

        //Phương thức hiển thị phương tiện di chuyển lên combo box
        private void DisplayVehicle()
        {
            //lấy danh sách vehicle
            var vehicles = from vh in hrm.Vehicles
                           select new
                           {
                               VehiclesId = vh.Id,
                               VehiclesName = vh.Name
                           };
            cboVehicle.DataSource = vehicles;
            cboVehicle.DisplayMember = "VehiclesName";
            cboVehicle.ValueMember = "VehiclesId";
        }

        //Phương thức hiển thị tourtype lên combo box
        private void DisplayTourType()
        {
            //lấy danh sách tourtype
            var tourtypes = from tt in hrm.TourTypes
                            select new
                            {
                                TourTypesId = tt.Id,
                                TourTypesName = tt.Name
                            };
            cboTourType.DataSource = tourtypes;
            cboTourType.DisplayMember = "TourTypesName";
            cboTourType.ValueMember = "TourTypesId";
        }

        //Phương thức hiển thị tourguide lên combo box
        private void DisplayTourGuide()
        {
            //lấy danh sách tourguide
            var tourguides = from vh in hrm.TourGuides
                             select new
                             {
                                 TourGuidesId = vh.Id,
                                 TourGuidesName = vh.Name
                             };
            cboTourGuide.DataSource = tourguides;
            cboTourGuide.DisplayMember = "TourGuidesName";
            cboTourGuide.ValueMember = "TourGuidesId";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //xóa trắng dữ liệu trên form
            txtId.Text = txtName.Text = txtPrice.Text = txtDestinations.Text = txtDescrible.Text = txtTourTime.Text = "";
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
                    tr.VehicleId = int.Parse(cboVehicle.SelectedValue.ToString());
                    tr.TourTypeId = int.Parse(cboTourType.SelectedValue.ToString());
                    tr.TourGuideId = int.Parse(cboTourGuide.SelectedValue.ToString());
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
                tr.VehicleId = int.Parse(cboVehicle.SelectedValue.ToString());
                tr.TourTypeId = int.Parse(cboTourType.SelectedValue.ToString());
                tr.TourGuideId = int.Parse(cboTourGuide.SelectedValue.ToString());
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

                    //check khóa ngoại
                    if (hrm.Customers.FirstOrDefault(x => x.TourId == tr.TourId) != null)
                    {
                        MessageBox.Show("Có khách hàng đang sử dụng tour này", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (tr != null)
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

        private void cboVehicle_Click(object sender, EventArgs e)
        {
            //Hiển thị tour du lịch lên combobox
            DisplayVehicle();
        }

        private void cboTourType_Click(object sender, EventArgs e)
        {
            //Hiển thị tour du lịch lên combobox
            DisplayTourType();
        }

        private void cboTourGuide_Click(object sender, EventArgs e)
        {
            //Hiển thị tour du lịch lên combobox
            DisplayTourGuide();
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
