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
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }
        //khai báo biến chứa dòng hiện tại
        int position;
        //khai báo biến lưu trạng thái thêm hay sửa
        bool edit = true;
        //Khởi tạo đối tượng quản lý Database (DataContext)
        ProjectDataContext hrm = new ProjectDataContext();

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            //Hiển thị khách hàng lên lưới
            DisplayCustomer();
            //Hiển thị tour du lịch lên combobox
            DisplayTour();

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
                //tìm khách hàng cần sửa có mã như trên form
                var emp = hrm.Customers.FirstOrDefault(x => x.CusId == txtId.Text);
                //nếu tìm thấy
                if (emp != null)
                {
                    // Validate tất cả các trường nhập
                    ValidateRequiredField(errField, txtId);
                    ValidateRequiredField(errField, txtName);
                    ValidatePhoneNumber(errField, txtPhone);
                    ValidateRequiredField(errField, txtAddress);
                    ValidateEmail(errField, txtEmail);
                    // Hiển thị khi bất kỳ trường nhập nào lỗi
                    foreach (Control ctl in Controls)
                    {
                        if (errField.GetError(ctl) != "")
                        {
                            MessageBox.Show(errField.GetError(ctl));
                            return;
                        }
                    }
                    //gán lại thông tin cho khách hàng
                    emp.CusName = txtName.Text;
                    emp.Birthday = txtBirthday.Value;
                    emp.Gender = chkSex.Checked;
                    emp.Phone = txtPhone.Text;
                    emp.CusAddress = txtAddress.Text;
                    emp.Email = txtEmail.Text;
                    emp.TourId = cboTour.SelectedValue.ToString();
                    //lưu
                    hrm.SubmitChanges();
                    //hiển thị lại dữ liệu
                    DisplayCustomer();
                    //hiển thị đúng vị trí dòng đã chọn trước đó
                    dgvCustomer.Rows[0].Selected = false;
                    dgvCustomer.Rows[position].Selected = true;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                //tạo mới khách hàng
                var emp = new Customer();
                // Validate tất cả các trường nhập
                ValidateRequiredField(errField, txtId);
                ValidateRequiredField(errField, txtName);
                ValidatePhoneNumber(errField, txtPhone);
                ValidateRequiredField(errField, txtAddress);
                ValidateEmail(errField, txtEmail);
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
                emp.CusId = txtId.Text;
                emp.CusName = txtName.Text;
                emp.Birthday = txtBirthday.Value;
                emp.Gender = chkSex.Checked;
                emp.Phone = txtPhone.Text;
                emp.CusAddress = txtAddress.Text;
                emp.Email = txtEmail.Text;
                emp.TourId = cboTour.SelectedValue.ToString();
                hrm.Customers.InsertOnSubmit(emp);
                //lưu
                hrm.SubmitChanges();
                //hiển thị lại dữ liệu
                DisplayCustomer();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //xóa trắng dữ liệu trên form
            txtId.Text = txtName.Text = txtPhone.Text = txtAddress.Text = txtEmail.Text = "";
            txtId.Focus();
            edit = false;
            txtId.ReadOnly = false;
        }

        private void dgvEmployee_Click(object sender, EventArgs e)
        {
            //hiển thị chi tiết khách hàng khi kích vào lưới
            DisplayCustomerDetail();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //tìm khách hàng có mã như trên form
                    var emp = hrm.Customers.FirstOrDefault(x => x.CusId ==
                    txtId.Text);
                    if (emp != null)
                    {
                        //xóa dữ liệu
                        hrm.Customers.DeleteOnSubmit(emp);
                        //lưu
                        hrm.SubmitChanges();
                        //hiển thị lại dữ liệu
                        DisplayCustomer();
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
            //hiển thị lại chi tiết khách hàng
            DisplayCustomerDetail();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Phương thức hiển thị tour lên combo box
        private void DisplayTour()
        {
            //lấy danh sách tour
            var departments = from dep in hrm.Tours
                              select new
                              {
                                  TourId = dep.TourId,
                                  TourName = dep.TourName
                              };
            cboTour.DataSource = departments;
            cboTour.DisplayMember = "TourName";
            cboTour.ValueMember = "TourId";
        }
        //Phương thức hiển thị dữ liệu lên lưới
        private void DisplayCustomer()
        {
            //truy vấn lấy các thông tin cần thiết trong bảng Customers
            var employess = from emp in hrm.Customers
                            select new
                            {
                                Ma_khach_hang = emp.CusId,
                                Ten = emp.CusName,
                                Gioi_tinh = emp.Gender,
                                Ngay_sinh = emp.Birthday,
                                Dia_chi = emp.CusAddress,
                                Email = emp.Email,
                                Dien_thoai = emp.Phone,
                                Ma_tour = emp.TourId
                            };
            //hiển thị lên lưới
            dgvCustomer.DataSource = employess;
            DisplayCustomerDetail();
        }
        //phương thức hiển thị chi tiết khách hàng của dòng hiện tại trên lưới lên form
        private void DisplayCustomerDetail()
        {
            //nếu dòng hiện tại trên lưới khác null
            if (dgvCustomer.CurrentRow != null)
            {
                DataGridViewRow row = dgvCustomer.CurrentRow;
                txtId.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                chkSex.Checked = (bool)row.Cells[2].Value;
                txtBirthday.Value = (DateTime)row.Cells[3].Value;
                txtAddress.Text = row.Cells[4].Value.ToString();
                txtEmail.Text = row.Cells[5].Value.ToString();
                txtPhone.Text = row.Cells[6].Value.ToString();
                cboTour.SelectedValue = row.Cells[7].Value.ToString();
                position = dgvCustomer.CurrentRow.Index;
                edit = true;
                txtId.ReadOnly = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSearch fs = new frmSearch();
            fs.ShowDialog();
        }

        private void btnTours_Click(object sender, EventArgs e)
        {
            frmTour ft = new frmTour();
            ft.ShowDialog();
        }

        private void cboTour_Click(object sender, EventArgs e)
        {
            //Hiển thị tour du lịch lên combobox
            DisplayTour();
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            ValidatePhoneNumber(errField, txtPhone);
        }
        // Validate số điện thoại
        private void ValidatePhoneNumber(ErrorProvider err, TextBox txt)
        {
            // Kiểm tra trường bị trống
            if (ValidateRequiredField(err, txt)) return;

            // Kiểm tra trường có ghi đúng cú pháp hay không
            Regex regex = new Regex(@"^(\d{10})$");
            if (regex.IsMatch(txt.Text))
            {
                // Xoá lỗi
                errField.SetError(txt, "");
            }
            else
            {
                // Hiển thị lỗi
                errField.SetError(txt, "Số điện thoại phải là dãy 10 chữ số liên tiếp");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmail(errField, txtEmail);
        }
        // Validate email
        private void ValidateEmail(ErrorProvider err, TextBox txt)
        {
            // Kiểm tra trường bị trống
            if (ValidateRequiredField(err, txt)) return;

            // Kiểm tra trường có ghi đúng cú pháp hay không
            Regex regex = new Regex(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$");
            if (regex.IsMatch(txt.Text))
            {
                // Xoá lỗi
                errField.SetError(txt, "");
            }
            else
            {
                // Hiển thị lỗi
                errField.SetError(txt, "Email cần viết theo định dạng someone@somewhere.com");
            }
        }
    }
}
