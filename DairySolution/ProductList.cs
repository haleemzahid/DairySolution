using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DairySolution
{
    class ProductList
    {
        public string productName { get; set; }
        public string productImg { get; set; }
        public int productQty { get; set; }
        public string productCode { get; set; }
        public string productCategory { get; set; }
        public float productPrice { get; set; }


        public ObservableCollection<ProductList> fillProductList()
        {
            ObservableCollection<ProductList> prodList = new ObservableCollection<ProductList>();
            prodList.Add(new ProductList()
            {
                productName = "STABILIZER PCB PCB of AVR-5008A",
                productImg = "C:/Users/Zuhaib/source/repos/HousePartyComputers/HousePartyComputers/HousePartyComputers/Assets/Images/productImage.png",
                productQty = 3,
                productCode = "COD123",
                productCategory = "Main Warehouse",
                productPrice = 550
            });

            prodList.Add(new ProductList()
            {
                productName = "UPS PCB PCB of VP-600-LED",
                productImg = "C:/Users/Zuhaib/source/repos/HousePartyComputers/HousePartyComputers/HousePartyComputers/Assets/Images/productImage.png",
                productQty = 4,
                productCode = "COD123",
                productCategory = "Main Warehouse",
                productPrice = 250
            });

            prodList.Add(new ProductList()
            {
                productName = "12V 7AH Allways battery:12V 7AH",
                productImg = "C:/Users/Zuhaib/source/repos/HousePartyComputers/HousePartyComputers/HousePartyComputers/Assets/Images/productImage.png",
                productQty = 50,
                productCode = "COD123",
                productCategory = "Main Warehouse",
                productPrice = 100
            });

            prodList.Add(new ProductList()
            {
                productName = "STABILIZER PCB PCB of AVR-5008A",
                productImg = "C:/Users/Zuhaib/source/repos/HousePartyComputers/HousePartyComputers/HousePartyComputers/Assets/Images/productImage.png",
                productQty = 50,
                productCode = "COD123",
                productCategory = "Main Warehouse",
                productPrice = 250
            });

            prodList.Add(new ProductList()
            {
                productName = "AVR-5008A AVR, Standard model, White, 5000VA/5000W Single phase OEM inner carto",
                productImg = "C:/Users/Zuhaib/source/repos/HousePartyComputers/HousePartyComputers/HousePartyComputers/Assets/Images/productImage.png",
                productQty = 130,
                productCode = "COD123",
                productCategory = "Main Warehouse",
                productPrice = 550
            });

            prodList.Add(new ProductList()
            {
                productName = "UPS VP-600-LCD 600VA/360W battery:1 pc*12V7Ah PWM (DC Mode) LCD Display univers",
                productImg = "C:/Users/Zuhaib/source/repos/HousePartyComputers/HousePartyComputers/HousePartyComputers/Assets/Images/productImage.png",
                productQty = 150,
                productCode = "COD123",
                productCategory = "Main Warehouse",
                productPrice = 250
            });

            prodList.Add(new ProductList()
            {
                productName = "Product A",
                productImg = "C:/Users/Zuhaib/source/repos/HousePartyComputers/HousePartyComputers/HousePartyComputers/Assets/Images/productImage.png",
                productQty = 0,
                productCode = "CODE-7",
                productCategory = "Main Warehouse",
                productPrice = 0
            });

            prodList.Add(new ProductList()
            {
                productName = "stock t shirt",
                productImg = "C:/Users/Zuhaib/source/repos/HousePartyComputers/HousePartyComputers/HousePartyComputers/Assets/Images/productImage.png",
                productQty = 300,
                productCode = "COD123",
                productCategory = "Main Warehouse",
                productPrice = 30
            });

            prodList.Add(new ProductList()
            {
                productName = "paper bag Brown 42x231cm",
                productImg = "C:/Users/Zuhaib/source/repos/HousePartyComputers/HousePartyComputers/HousePartyComputers/Assets/Images/productImage.png",
                productQty = 1000,
                productCode = "COD123",
                productCategory = "Main Warehouse",
                productPrice = 1.5F
            });

            prodList.Add(new ProductList()
            {
                productName = "paper bag white 42x231cm",
                productImg = "C:/Users/Zuhaib/source/repos/HousePartyComputers/HousePartyComputers/HousePartyComputers/Assets/Images/productImage.png",
                productQty = 1000,
                productCode = "COD123",
                productCategory = "Main Warehouse",
                productPrice = 1.5F
            });

            prodList.Add(new ProductList()
            {
                productName = " paper bag Brown 33x26cm",
                productImg = "C:/Users/Zuhaib/source/repos/HousePartyComputers/HousePartyComputers/HousePartyComputers/Assets/Images/productImage.png",
                productQty = 1000,
                productCode = "COD123",
                productCategory = "Main Warehouse",
                productPrice = 1.2F
            });



            return prodList;
        }
    }
}
