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
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
        }

        //Khai báo biến DataContext
        ProjectDataContext hrm = new ProjectDataContext();

        private void frmSearch_Load(object sender, EventArgs e)
        {
            //lấy thông tin tour du lịch
            var departments = from dep in hrm.Tours
                              select new
                              {
                                  TourId = dep.TourId,
                                  TourName = dep.TourName
                              };
            //Tạo nút gốc
            TreeNode root = new TreeNode("Danh mục Tour du lịch", 0, 0);
            root.Tag = 0;
            //đọc dữ liệu và đưa lên TreeView

            foreach (var dep in departments)
            {
                //tạo nút con
                TreeNode depnode = new TreeNode(dep.TourName, 1, 1);
                depnode.Tag = dep.TourId;
                //đưa nút con vào nút gốc
                root.Nodes.Add(depnode);
            }
            //đưa nút gốc vào treeview
            trvTour.Nodes.Add(root);
            //mở hết các nút trên cây
            trvTour.ExpandAll();
        }

        private void trvDepartment_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //gọi phương thức tìm
            SearchEmployee();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //gọi phương thức tìm
            SearchEmployee();
        }
        public void SearchEmployee()
        {
            //xóa ListVIew
            lstCustomer.Items.Clear();

            //lấy nút được chọn
            TreeNode node = trvTour.SelectedNode;
            //Tìm và hiển thị kết quả
            //lấy khách hàng theo tour được chọn
            var employees = from emp in hrm.Customers
                            where emp.TourId == node.Tag.ToString()
                            && emp.CusName.Contains(txtName.Text)
                            select new
                            {
                                Id = emp.CusId,
                                FullName = emp.CusName,
                                Birthday = emp.Birthday,
                                Address = emp.CusAddress,
                                Email = emp.Email,
                                Phone = emp.Phone,
                                Sex = emp.Gender
                            };
            //duyệt và hiển thị lên ListView
            foreach (var emp in employees)
            {
                ListViewItem item = new ListViewItem(new string[] { emp.Id, emp.FullName, emp.Birthday.Value.ToString("dd/MM/yyyy"), emp.Address, emp.Phone, emp.Email });
                item.ImageIndex = (emp.Sex.Value) ? 2 : 3;
                lstCustomer.Items.Add(item);
            }
        }
    }
}
