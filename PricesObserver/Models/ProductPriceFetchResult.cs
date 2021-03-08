using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricesObserver.Models
{
    public class ProductPriceFetchResult
    {
        public DateTime CreatedAt { get; set; }
        public string ProductName { get; set; }

        public string ProductUrl { get; set; }

        public string Seller { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public decimal OldPrice { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorId { get; set; }


        public ProductPriceFetchResult(string errorMessage, string errorId)
        {
            IsSuccess = false;
            ErrorMessage = errorMessage;
            ErrorId = errorId;

            CreatedAt = DateTime.Today;
        }

        public ProductPriceFetchResult()
        {
            CreatedAt = DateTime.Today;
        }
    }
}
