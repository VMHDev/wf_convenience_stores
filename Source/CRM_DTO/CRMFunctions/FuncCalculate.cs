using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.CRMFunctions
{
    public class FuncCalculate
    {
        /// <summary>
        /// Tính giá ước tính
        /// </summary>
        /// <param name="_RateIn">Giá nhập</param>
        /// <param name="_PercentProfit">% Lợi nhuận</param>
        /// <returns>Giá ước tính</returns>
        public static decimal CalcRateEstimate(decimal _RateIn, decimal _PercentProfit)
        {
            decimal rs = _RateIn + _RateIn * _PercentProfit / 100;
            string sMessage;
            return FuncNumber.RoundingVND(rs, "3@499@0", out sMessage);            
        }

        /// <summary>
        /// Tính giá bán
        /// </summary>
        /// <param name="_RateEstimate">Giá bán ước tính</param>
        /// <param name="_DiscountTotalProduct">Tổng tiền giảm của sản phẩm</param>
        /// <returns>Giá bán</returns>
        public static decimal CalcRateSell(decimal _RateEstimate, decimal _DiscountTotalProduct)
        {
            return _RateEstimate - _DiscountTotalProduct;
        }

        /// <summary>
        /// Tính thành tiền
        /// </summary>
        /// <param name="_RateSell">Giá bán</param>
        /// <param name="_Quantity">Số lượng</param>
        /// <returns>Tổng thành tiền/returns>
        public static decimal CalcAmount(decimal _RateSell, decimal _Quantity)
        {
            return _RateSell * _Quantity;
        }


        /// <summary>
        /// Tính tiền khách trả
        /// </summary>
        /// <param name="_TotalAmount">Tổng tiền thanh toán</param>
        /// <param name="_DiscountTotalTrn">Tổng tiền giảm trên giao dịch</param>
        /// <returns>Tiền khách trả</returns>
        public static decimal CalcAmountPay(decimal _TotalAmount, decimal _DiscountTotalTrn)
        {
            return _TotalAmount - _DiscountTotalTrn;
        }

        /// <summary>
        /// Tính tiền giảm chiết khấu
        /// </summary>
        /// <param name="_RateEstimate">Giá bán ước tính</param>
        /// <param name="_DiscountPercent">% Chiếu khấu</param>
        /// <returns>Tổng tiền giảm chiết khấu</returns>
        public static decimal CalcDiscountPercentMoney(decimal _RateEstimate, decimal _DiscountPercent)
        {
            decimal rs = _RateEstimate * _DiscountPercent / 100;
            string sMessage;
            return FuncNumber.RoundingVND(rs, "3@499@0", out sMessage);
        }

        /// <summary>
        /// Tính tổng tiền giảm sản phẩm
        /// </summary>
        /// <param name="_Discount">Tiền giảm</param>
        /// <param name="_DiscountPercentMoney">Tiền giảm chiếu khấu</param>
        /// <returns>Tổng tiền giảm< sản phẩm/returns>
        public static decimal CalcDiscountTotalProduct(decimal _Discount, decimal _DiscountPercentMoney)
        {
            return _Discount + _DiscountPercentMoney;
        }

        /// <summary>
        /// Tính tổng tiền giảm giao dịch
        /// </summary>
        /// <param name="_DiscountTrn">Tiền giảm theo giao dịch</param>
        /// <param name="_DiscountProduct">Tổng tiền trên sản phẩm</param>
        /// <returns>Tổng tiền giảm giao dịch</returns>
        public static decimal CalcDiscountTotalTransaction(decimal _DiscountTrn, decimal _DiscountProduct)
        {
            return _DiscountTrn + _DiscountProduct;
        }

        /// <summary>
        /// Tính các giá trị của giao dịch
        /// </summary>
        /// <param name="_DataSource">DataSource giao dịch</param>
        /// <param name="_AmountTotalProduct">Tổng thành tiền các món hàng</param>
        /// <param name="_DiscountTotalProduct">Tổng tiền giảm các món hàng</param>
        /// <param name="_AmountPayTemp">Tiền khách trả tạm tính</param>
        public static void CalcValueTransaction(DataTable _DataSource, out decimal _AmountTotalProduct, out decimal _DiscountTotalProduct, out decimal _AmountPayTemp)
        {
            _AmountTotalProduct = 0M;
            _DiscountTotalProduct = 0M;
            _AmountPayTemp = 0M;
            foreach (DataRow dr in _DataSource.Rows)
            {
                _AmountTotalProduct += dr["Amount"] == DBNull.Value ? 0M : Convert.ToDecimal(dr["Amount"]);
                _DiscountTotalProduct += dr["DiscountTotal"] == DBNull.Value ? 0M : Convert.ToDecimal(dr["DiscountTotal"]);
            }
            _AmountPayTemp = _AmountTotalProduct - _DiscountTotalProduct;
        }
    }
}
