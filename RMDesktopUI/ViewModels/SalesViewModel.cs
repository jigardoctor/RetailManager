using Caliburn.Micro;
using RMDesktopUI.Library.Api;
using RMDesktopUI.Library.Model;
using System;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMDesktopUI.Library.Helper;

namespace RMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private readonly IConfigHelper _configHelper;
        private IProductEndpoint _productEndpoint;
        public SalesViewModel(IProductEndpoint productEndpoint , IConfigHelper config)
        {
            _configHelper = config;
            _productEndpoint = productEndpoint;


        }
        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadProducts();
        }
        private async Task LoadProducts()
        {
            var productLists = await _productEndpoint.GetAll();
            // var products = _mapper.Map<List<ProductDisplayModel>>(productLists);
            Products = new BindingList<ProductModel>(productLists);
        }

        private BindingList<ProductModel> _products;

        public BindingList<ProductModel> Products
        {
            get { return _products; }
            set {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }


        private ProductModel _selectedProduct;


        public ProductModel SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                NotifyOfPropertyChange(() => SelectedProduct);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }


        private BindingList<CartItemModel> _cart = new BindingList<CartItemModel>();

        public BindingList<CartItemModel> Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }
        private int _itemQuantity = 1;
        public int ItemQuantity
        {
            get { return _itemQuantity; }
            set { _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }

        private decimal CalculateSubTotal()
        {
            decimal subTotal = 0;

            foreach (var item in Cart)
            {
                subTotal += (item.Product.RetailPrice * item.QuantityInCart);
            }

            return subTotal;
        }
        public string SubTotal
        {
            get
            {
                return CalculateSubTotal().ToString("C");
            }
        }
        private decimal CalculateTax()
        {
            //decimal taxAmount = 0;
            //decimal taxRate = _configHelper.GetTaxRate();

            //taxAmount = Cart
            //    .Where(x => x.Product.IsTaxable)
            //    .Sum(x => x.Product.RetailPrice * x.QuantityInCart * taxRate);

            decimal taxAmount = 0;
            decimal taxRate = (decimal)_configHelper.GetTaxRate()/100;
            foreach (var item in Cart)
            {
                if (item.Product.IsTaxable)
                {
                    taxAmount += (item.Product.RetailPrice * item.QuantityInCart * taxRate);
                }
            }

            return taxAmount;
        }
        public string Tax
        {
            get
            {
                
                return CalculateTax().ToString("C");
            }

        }
        public string Total
        {
            get
            {
                decimal total = CalculateSubTotal() + CalculateTax();
                return total.ToString("C");
            }

        }

        public bool CanAddToCart
        {
            get
            {
                bool output = false;
                if (Convert.ToInt32(ItemQuantity) > 0 && SelectedProduct?.QuantityInStock >= Convert.ToInt32(ItemQuantity))
                {
                    output = true;
                }
                return output;
            }
        }
        public void   AddToCart()
        {
            CartItemModel existingItem = Cart.FirstOrDefault(x => x.Product == SelectedProduct);
            if(existingItem != null)
            {
                existingItem.QuantityInCart += ItemQuantity;
                Cart.Remove(existingItem);
                Cart.Add(existingItem);
            }
            else
            {
                CartItemModel item = new CartItemModel
                {
                    Product = SelectedProduct,
                    QuantityInCart = ItemQuantity
                };
                Cart.Add(item);
            }
            SelectedProduct.QuantityInStock -= ItemQuantity;
            ItemQuantity = 1;
            NotifyOfPropertyChange(() => SubTotal);
            NotifyOfPropertyChange(() => Tax);
            NotifyOfPropertyChange(() => Total);
        }
        public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;

                return output;

            }
        }
        public void RemoveFromCart()
        {
            NotifyOfPropertyChange(() => SubTotal);
            NotifyOfPropertyChange(() => Tax);
            NotifyOfPropertyChange(() => Total);
        }
        public bool CanCheckOut
        {
            get
            {
                bool output = false;

                return output;

            }
        }
        public void CheckOut()
        {

        }
    }
}
