﻿using System;
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
            var tours = from tr in hrm.Tours
                        select new
                        {
                            TourId = tr.TourId,
                            TourName = tr.TourName
                        };
            //Tạo nút gốc
            TreeNode root = new TreeNode("Danh mục Tour du lịch", 0, 0);
            root.Tag = 0;
            //đọc dữ liệu và đưa lên TreeView

            foreach (var dep in tours)
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

        private void trvTours_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //gọi phương thức tìm
            DisplayCustomer();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //xóa ListVIew
            lstCustomer.Items.Clear();

            //Tìm và hiển thị kết quả
            //lấy khách hàng theo tour được chọn
            var customers = from cus in hrm.Customers
                            join gen in hrm.Genders on cus.GenderId equals gen.Id
                            join add in hrm.CusAddresses on cus.CusAddressId equals add.Id
                            where  cus.CusName.Contains(txtName.Text)
                            select new
                            {
                                Id = cus.CusId,
                                FullName = cus.CusName,
                                Birthday = cus.Birthday,
                                Address = add.Name,
                                Email = cus.Email,
                                Phone = cus.Phone,
                                Sex = gen.Name
                            };
            //duyệt và hiển thị lên ListView
            foreach (var cus in customers)
            {
                ListViewItem item = new ListViewItem(new string[] { cus.Id, cus.FullName, cus.Birthday.Value.ToString("dd/MM/yyyy"), cus.Address, cus.Phone, cus.Email });

                //viết dạng switch-case
                switch (cus.Sex)
                {
                    case "Nam":
                        item.ImageIndex = 2;
                        break;
                    case "Nữ":
                        item.ImageIndex = 3;
                        break;
                    default:
                        item.ImageIndex = 4;
                        break;
                }
                lstCustomer.Items.Add(item);
            }
        }
        public void DisplayCustomer()
        {
            //xóa ListVIew
            lstCustomer.Items.Clear();

            //lấy nút được chọn
            TreeNode node = trvTour.SelectedNode;
            //Tìm và hiển thị kết quả
            //lấy khách hàng theo tour được chọn
            var customers = from cus in hrm.Customers
                            join gen in hrm.Genders on cus.GenderId equals gen.Id
                            join add in hrm.CusAddresses on cus.CusAddressId equals add.Id
                            where cus.TourId == node.Tag.ToString()
                            && cus.CusName.Contains(txtName.Text)
                            select new
                            {
                                Id = cus.CusId,
                                FullName = cus.CusName,
                                Birthday = cus.Birthday,
                                Address = add.Name,
                                Email = cus.Email,
                                Phone = cus.Phone,
                                Sex = gen.Name
                            };
            //duyệt và hiển thị lên ListView
            foreach (var cus in customers)
            {
                ListViewItem item = new ListViewItem(new string[] { cus.Id, cus.FullName, cus.Birthday.Value.ToString("dd/MM/yyyy"), cus.Address, cus.Phone, cus.Email });
                //item.ImageIndex = (cus.Sex.Value) ? 2 : 3;

                //viết dạng if
                //if (cus.Sex == "Nam")
                //{
                //    item.ImageIndex = 2;
                //}
                //if (cus.Sex == "Nữ")
                //{
                //    item.ImageIndex = 3;
                //}
                //if (cus.Sex == "LGBTQ+")
                //{
                //    item.ImageIndex = 4;
                //}

                //viết dạng switch-case
                switch (cus.Sex)
                {
                    case "Nam":
                        item.ImageIndex = 2;
                        break;
                    case "Nữ":
                        item.ImageIndex = 3;
                        break;
                    default:
                        item.ImageIndex = 4;
                        break;
                }
                lstCustomer.Items.Add(item);
            }
        }
    }
}
