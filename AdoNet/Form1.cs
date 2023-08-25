using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNet
{
    public partial class frmAdoNet : Form
    {
        public frmAdoNet()
        {
            InitializeComponent();
        }

        ProductDal _productDal = new ProductDal();
        private void frmAdoNet_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            dgwProduct.DataSource = _productDal.GetAll2();
        }

        private void dgwProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product 
            { 
                Name=tbxName.Text,
                UnitPrice=Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount=Convert.ToInt32(tbxStockAmount.Text)
            
            });
            LoadProducts();
            MessageBox.Show("Product added!");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwProduct.CurrentRow.Cells[1].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProduct.CurrentRow.Cells[2].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProduct.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product{

                Id = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                Name = tbxNameUpdate.Text,
                UnitPrice= Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text),

            };
            _productDal.Update(product);
            LoadProducts();
            MessageBox.Show("Product Updated!");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value);
            _productDal.Delete(id);
            LoadProducts();
            MessageBox.Show("Product Deleted!");
        }
    }
}
