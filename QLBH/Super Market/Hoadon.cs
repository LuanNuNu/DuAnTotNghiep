using System;
using System.Collections.Generic;
using System.Text;

namespace Super_Market
{
    class clsCacBienChung
    { 
        public static string tenDonVi=" Cửa hàng giày ";
    }

    class ThongKeHoaDonNhap // mẫu thống kê hóa đơn nhập
    {
        private String InDate;   // ngày nhập 
        private String ProviderID;  // mã nhà cung cấp
        private String NameProviderID;  // tên nhà cung cấp
        private String Note;  // ghi chú
        private int EmployeeID ;   // nhân viên tạo phiếu nhập
        private String NameEmployee;  // tên nhân viên
        private float Total;  // tổng giá trị hóa đơn nhập
    }

    class Cart
    {
        private String productId;   // mã sản phẩm
        private String productName;  // khỏi truy vấn từ tbl sản phẩm, hiển thị ra lưới luôn cho nhanh
        private String unitProduct;  // đơn vị tính
        private int quantity;        // số lượng
        private float productPrice;  // giá bán
        private float totalProducts;  // tổng tiền = số lượng * giá bán - lưu luôn cho nhanh
        public Cart(String productId,String productName,int quantity,float productPrice)
        {
            this.productId = productId;
            this.productName = productName;
            this.productPrice = productPrice;
            this.quantity = quantity;
            this.totalProducts = quantity * productPrice; // tổng tiền = số lượng * giá bán - lưu luôn cho nhanh
        }
        public String _ProductId
        {
            get { return this.productId; }
            set { this.productId= value; }
        }
        public String _unitProduct
        {
            get { return this.unitProduct; }
            set { this.unitProduct = value; }
        }

        public String _ProductName
        {
            get { return this.productName; }
            set { this.productName = value; }
        }
        public int _Quantity {
            get { return this.quantity; }
            set { this.quantity = value; }
        }
        public float _totalProducts
        {
            get { return this.totalProducts; }
            set { this.totalProducts = value; }
        }
        public float _ProductPrice
        {
            get { return this.productPrice; }
            set { this.productPrice = value; }
        }
    }
    class HoaDon {
        private List<Cart> cart;
        public HoaDon()
        {  // khởi tạo danh sách 
            if (this.cart == null)
                this.cart = new List<Cart>();
        }
        public List<Cart> _Cart {
            get { return this.cart; } // trả về danh sách
            set { this.cart = value; }
        }
        public int search_item_incart(String productid)
        { // tìm 1 sản phẩm trong danh sách (giỏ hàng)
            int index = 0;
            foreach (Cart item in cart)
            {
                if (item._ProductId.Equals(productid))
                    return index;
                index += 1;
            }
            return -1;
        }
        public void insert_item_toCart(String productid, String productName, int quantity, float productPrice)
        { //insert 1 san pham vao: nếu sản phẩm chưa có thì thêm vào danh sách, nếu sản phẩm đã có thì chỉ tăng số lượng
            if (search_item_incart(productid) == -1)
            { // chưa có trong danh sách thì thêm mới
                Cart items = new Cart(productid, productName, quantity, productPrice);
                this.cart.Add(items);
            }
            else
            {
                int indexSP= search_item_incart(productid); // số thứ tự của sản phẩm trong danh sách
                cart[indexSP]._Quantity += quantity;  // tăng số lượng 
                cart[indexSP]._totalProducts = cart[indexSP]._Quantity * productPrice; // tính lại tổng
            }
        }
        public void remove_item(String Productid)
        { // xóa 1 sản phẩm khỏi danh sách
            try
            {
                int index = search_item_incart(Productid);
                cart.RemoveAt(index);
            }
            catch (IndexOutOfRangeException) { }
        }
        public float tong_HoaDon
        {
            get {
                float tempt = 0;
                if (cart == null)
                    return 0;
                else
                    foreach (Cart items in cart)
                    {
                        tempt += items._totalProducts;
                    }
                return tempt;
            }
            
        }


    }
   
}
