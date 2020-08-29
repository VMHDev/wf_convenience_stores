using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.CRMFunctions
{
    public static class FuncNumber
    {
        #region Thuật toán 1: Chỉ đọc được số nguyên dương
        /*
         * Đọc từ 0 đến 999 999 999 999 999
         */

        /// <summary>
        /// Đọc chữ số theo phiên âm Tiếng Việt
        /// </summary>
        /// <param name="_Digit">Chữ số</param>
        /// <returns>Cách đọc</returns>
        public static string ReadDigit(string _Digit)
        {
            string sResult = "";
            switch (_Digit)
            {
                case "0":
                    sResult = "không";
                    break;
                case "1":
                    sResult = "một";
                    break;
                case "2":
                    sResult = "hai";
                    break;
                case "3":
                    sResult = "ba";
                    break;
                case "4":
                    sResult = "bốn";
                    break;
                case "5":
                    sResult = "năm";
                    break;
                case "6":
                    sResult = "sáu";
                    break;
                case "7":
                    sResult = "bảy";
                    break;
                case "8":
                    sResult = "tám";
                    break;
                case "9":
                    sResult = "chín";
                    break;
            }
            return sResult;
        }

        /// <summary>
        /// Đọc từng phần của số theo 3 chữ số (nghìn - triệu - tỷ)
        /// </summary>
        /// <param name="_NumPart">Số lượng chữ số</param>
        /// <returns>Cách đọc</returns>
        private static string ReadPartThreeDigit(string _NumPart)
        {
            string sResult = "";
            if (_NumPart.Equals("1"))
                sResult = "";
            if (_NumPart.Equals("2"))
                sResult = "nghìn";
            if (_NumPart.Equals("3"))
                sResult = "triệu";
            if (_NumPart.Equals("4"))
                sResult = "tỷ";
            if (_NumPart.Equals("5"))
                sResult = "nghìn tỷ";
            if (_NumPart.Equals("6"))
                sResult = "triệu tỷ";
            if (_NumPart.Equals("7"))
                sResult = "tỷ tỷ";
            return sResult;
        }

        /// <summary>
        /// Tách chuỗi số
        /// </summary>
        /// <param name="_Split">Chuỗi số cần tách</param>
        /// <returns>Chuỗi số sau tách</returns>
        private static string SplitNumber(string _Split)
        {
            string vResult = "";
            if (_Split.Equals("000"))
                return "";
            if (_Split.Length == 3)
            {
                string tr = _Split.Trim().Substring(0, 1).ToString().Trim();
                string ch = _Split.Trim().Substring(1, 1).ToString().Trim();
                string dv = _Split.Trim().Substring(2, 1).ToString().Trim();
                if (tr.Equals("0") && ch.Equals("0"))
                    vResult = " không trăm lẻ " + ReadDigit(dv.ToString().Trim()) + " ";
                if (!tr.Equals("0") && ch.Equals("0") && dv.Equals("0"))
                    vResult = ReadDigit(tr.ToString().Trim()).Trim() + " trăm ";
                if (!tr.Equals("0") && ch.Equals("0") && !dv.Equals("0"))
                    vResult = ReadDigit(tr.ToString().Trim()).Trim() + " trăm lẻ " + ReadDigit(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    vResult = " không trăm " + ReadDigit(ch.Trim()).Trim() + " mươi " + ReadDigit(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    vResult = " không trăm " + ReadDigit(ch.Trim()).Trim() + " mươi ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    vResult = " không trăm " + ReadDigit(ch.Trim()).Trim() + " mươi lăm ";
                if (tr.Equals("0") && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    vResult = " không trăm mười " + ReadDigit(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("0"))
                    vResult = " không trăm mười ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("5"))
                    vResult = " không trăm mười lăm ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    vResult = ReadDigit(tr.Trim()).Trim() + " trăm " + ReadDigit(ch.Trim()).Trim() + " mươi " + ReadDigit(dv.Trim()).Trim() + " ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    vResult = ReadDigit(tr.Trim()).Trim() + " trăm " + ReadDigit(ch.Trim()).Trim() + " mươi ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    vResult = ReadDigit(tr.Trim()).Trim() + " trăm " + ReadDigit(ch.Trim()).Trim() + " mươi lăm ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    vResult = ReadDigit(tr.Trim()).Trim() + " trăm mười " + ReadDigit(dv.Trim()).Trim() + " ";

                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("0"))
                    vResult = ReadDigit(tr.Trim()).Trim() + " trăm mười ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("5"))
                    vResult = ReadDigit(tr.Trim()).Trim() + " trăm mười lăm ";
            }
            return vResult;
        }

        /// <summary>
        /// Đọc số nguyên dương
        /// </summary>
        /// <param name="_Number">Số nguyên dương</param>
        /// <returns>Text đọc số theo phát âm Việt Nam</returns>
        public static string ReadNumberIntegerPositive(double _Number)
        {
            if (_Number < 0)
            {
                return "Không đọc được";
            }

            if (_Number > 999999999999999)
            {
                return "Không đọc được";
            }

            if (_Number == 0)
            {
                return "Không";
            }

            string sResult = "";
            string tach_mod = "";
            string tach_conlai = "";
            //ulong Num = Math.Round(vNumber, 0);
            double Num = _Number;
            string gN = Convert.ToString(Num);
            int m = Convert.ToInt32(gN.Length / 3);
            int mod = gN.Length - m * 3;
            string dau = "[+]";

            // Dau [+ , - ]
            if (_Number < 0)
                dau = "[-]";
            dau = "";

            // Tach hang lon nhat
            if (mod.Equals(1))
                tach_mod = "00" + Convert.ToString(Num.ToString().Trim().Substring(0, 1)).Trim();
            if (mod.Equals(2))
                tach_mod = "0" + Convert.ToString(Num.ToString().Trim().Substring(0, 2)).Trim();
            if (mod.Equals(0))
                tach_mod = "000";
            // Tach hang con lai sau mod :
            if (Num.ToString().Length > 2)
                tach_conlai = Convert.ToString(Num.ToString().Trim().Substring(mod, Num.ToString().Length - mod)).Trim();

            ///don vi hang mod
            int im = m + 1;
            if (mod > 0)
                sResult = SplitNumber(tach_mod).ToString().Trim() + " " + ReadPartThreeDigit(im.ToString().Trim());
            /// Tach 3 trong tach_conlai

            int i = m;
            int _m = m;
            int j = 1;
            string tach3 = "";
            string tach3_ = "";

            while (i > 0)
            {
                tach3 = tach_conlai.Trim().Substring(0, 3).Trim();
                tach3_ = tach3;
                sResult = sResult.Trim() + " " + SplitNumber(tach3.Trim()).Trim();
                m = _m + 1 - j;
                if (!tach3_.Equals("000"))
                    sResult = sResult.Trim() + " " + ReadPartThreeDigit(m.ToString().Trim()).Trim();
                tach_conlai = tach_conlai.Trim().Substring(3, tach_conlai.Trim().Length - 3);

                i = i - 1;
                j = j + 1;
            }
            if (sResult.Trim().Substring(0, 1).Equals("k"))
                sResult = sResult.Trim().Substring(10, sResult.Trim().Length - 10).Trim();
            if (sResult.Trim().Substring(0, 1).Equals("l"))
                sResult = sResult.Trim().Substring(2, sResult.Trim().Length - 2).Trim();
            if (sResult.Trim().Length > 0)
                sResult = dau.Trim() + " " + sResult.Trim().Substring(0, 1).Trim().ToUpper() + sResult.Trim().Substring(1, sResult.Trim().Length - 1).Trim();

            return sResult.ToString().Trim();
        }
        #endregion

        #region Thuật toán 2:
        /*
         * Đọc được đến 999 999 999 999 999 999  do kiểu long tràn  
         * Chưa tối ưu được số âm mới đọc đến 99 999 999 999 999 999      
        */

        /// <summary>
        /// Đọc chữ số
        /// </summary>
        /// <param name="_Digit">Chữ số</param>
        /// <param name="_Position">Vị trí</param>
        /// <returns>Cách đọc</returns>
        private static string ReadDigit(string _Digit, int _Position)
        {
            switch (_Digit)
            {
                case "1": return "Một ";
                case "2": return "Hai ";
                case "3": return "Ba ";
                case "4": return "Bốn ";
                case "5": return "Năm ";
                case "6": return "Sáu ";
                case "7": return "Bảy ";
                case "8": return "Tám ";
                case "9": return "Chín ";
                case "10": return "Mười ";
            }
            return string.Empty;
        }

        /// <summary>
        /// Đọc phần ba số
        /// </summary>
        /// <param name="_Len">???</param>
        /// <returns>???</returns>
        private static string ReadPartDigit(int _Len)
        {
            switch (_Len)
            {
                case 1: return "Mươi ";
                case 2: return "Trăm ";
                case 3: return "Nghìn ";
                case 6: return "Triệu ";
                case 9: return "Tỷ ";
            }
            return string.Empty;
        }

        /// <summary>
        /// Phân tích
        /// </summary>
        /// <param name="_Number">Chuỗi số</param>
        /// <returns>Kết quả</returns>
        private static string Analyze(string _Number)
        {
            string _strReturn = string.Empty;
            string _temp = string.Empty;
            while (_Number != string.Empty)
            {
                _temp = _Number.Substring(0, 3);
                _Number = _Number.Remove(0, 3);

                string _t = _temp;
                for (int i = 0; i < _temp.Length; i++)
                {
                    if (i == 1 && Convert.ToInt32(_t.Substring(1, 2)) / 10 == 1)
                    {
                        _strReturn += "Mười ";
                    }
                    else
                    {
                        if (i == 2 && _t[2] == '1' && Convert.ToInt32(_t.Substring(1, 2)) / 10 >= 2)
                        {
                            _strReturn += "Mốt ";
                        }
                        else
                        {
                            if (_t[i] != '0' && i == 2 && _t[1] == '0' && _strReturn != string.Empty)
                            {
                                _strReturn += "Lẻ ";
                            }

                            if (i == 2 && _t[1] != '0' && _t[2] == '5' && _strReturn != string.Empty)
                            {
                                _strReturn += "Lăm ";
                            }
                            else
                            {
                                _strReturn += ReadDigit(_t[i].ToString(), i);
                            }

                            if (_t[i] != '0')
                            {
                                _strReturn += ReadPartDigit(_t.Length - i - 1);
                            }
                        }

                    }

                }
                if (Convert.ToInt32(_temp) != 0)
                {
                    _strReturn += ReadPartDigit(_Number.Length);
                }
            }
            return _strReturn;
        }

        /// <summary>
        /// Đọc số nguyên
        /// </summary>
        /// <param name="_Number">Chuỗi Số nguyên</param>
        /// <returns>Cách đọc</returns>
        public static string ReadNumberInteger(string _Number)
        {
            if (_Number.Length > 18)
            {
                return "Không đọc được";
            }

            long moneyTemp = Int64.Parse(_Number == "" ? "0" : _Number);
            string _temp = string.Empty;
            string _strReturn = string.Empty;
            string _bilionGroup = string.Empty;
            string _milionGroup = string.Empty;

            if (moneyTemp < 0)
            {
                _strReturn = "Âm: ";
            }

            _Number = Math.Abs(moneyTemp).ToString();
            while (_Number.Length % 3 != 0)
            {
                _Number = "0" + _Number;
            }

            if (_Number.Length > 9)
            {
                _bilionGroup = _Number.Substring(0, _Number.Length - 9);
                _strReturn += Analyze(_bilionGroup);
                _strReturn += "Tỷ ";
            }

            _milionGroup = _Number.Substring(_bilionGroup.Length);
            _strReturn += Analyze(_milionGroup);

            return _strReturn;
        }
        #endregion

        /// <summary>
        /// Làm tròn tiền VND 
        /// </summary>
        /// <param name="_Money">Giá trị muốn làm tròn</param>
        /// <param name="_RoundValue">(Số ký tự đơn vị muốn làm tròn)@(Giá trị so sánh làm tròn)@(So sánh >= Giá trị muốn làm tròn)</param>
        /// VD: 3@499@0 => Làm tròn 3 chữ số, 
        /// <returns></returns>
        public static decimal RoundingVND(decimal _Money, string _RoundValue, out string _Error)
        {
            _Error = string.Empty;
            if (_RoundValue == "0@0@0")
            {
                return Math.Round(_Money, MidpointRounding.AwayFromZero);
            }

            decimal checkNegative = _Money;
            _Money = Math.Abs(_Money);
            int sRound = 3, sValue = 499, sLamTron = 0;
            try
            {
                try
                {
                    string[] lst = _RoundValue.Split('@');
                    if (lst.Length >= 3)
                    {
                        sRound = int.Parse(lst[0].ToString());
                        sValue = int.Parse(lst[1].ToString());
                        sLamTron = int.Parse(lst[2].ToString());
                    }
                }
                catch
                {
                    sRound = 3; sValue = 499; sLamTron = 0;
                }
                decimal result = _Money;

                string aMoney = ((long)_Money).ToString();

                if (aMoney.Length < sRound)
                {
                    return decimal.Parse(aMoney.ToString());
                }                    

                string _PhanNguyen = aMoney.Substring(0, aMoney.Length - sRound);
                string _PhanLamTron = aMoney.Substring(aMoney.Length - sRound);
                long iPhanLamTron = long.Parse(_PhanLamTron == "" ? "0" : _PhanLamTron);
                long iPhanNguyen = long.Parse(_PhanNguyen == "" ? "0" : _PhanNguyen);

                if (sLamTron == 0)
                {
                    if (iPhanLamTron > sValue)
                    {
                        iPhanNguyen++;
                    }
                    _PhanNguyen = iPhanNguyen.ToString();
                    _PhanNguyen = _PhanNguyen.PadRight(sRound + _PhanNguyen.Length, '0');
                    result = decimal.Parse(_PhanNguyen);
                }
                else if (sLamTron == 1)
                {
                    if (iPhanLamTron <= sValue)
                    {
                        _PhanNguyen = _PhanNguyen.PadRight(sRound + _PhanNguyen.Length, '0');
                        result = decimal.Parse(_PhanNguyen) + (decimal)sValue;
                    }
                    if (iPhanLamTron > sValue)
                    {
                        iPhanNguyen++;
                        _PhanNguyen = iPhanNguyen.ToString();
                        _PhanNguyen = _PhanNguyen.PadRight(sRound + _PhanNguyen.Length, '0');
                        result = decimal.Parse(_PhanNguyen);
                    }
                }
                else if (sLamTron == 2)
                {
                    if (iPhanLamTron < sValue)
                    {
                        _PhanNguyen = iPhanNguyen.ToString();
                        _PhanNguyen = _PhanNguyen.PadRight(sRound + _PhanNguyen.Length, '0');
                        result = decimal.Parse(_PhanNguyen);
                    }
                    if (iPhanLamTron == sValue)
                    {
                        _PhanNguyen = _PhanNguyen.PadRight(sRound + _PhanNguyen.Length, '0');
                        result = decimal.Parse(_PhanNguyen) + (decimal)sValue;
                    }
                    if (iPhanLamTron > sValue)
                    {
                        iPhanNguyen++;
                        _PhanNguyen = iPhanNguyen.ToString();
                        _PhanNguyen = _PhanNguyen.PadRight(sRound + _PhanNguyen.Length, '0');
                        result = decimal.Parse(_PhanNguyen);

                    }
                }
                if (checkNegative < 0)
                {
                    result = -result;
                }                
                return result;
            }
            catch (Exception ex)
            {
                _Error = FuncException.GetDetailsException(ex);
                return _Money;
            }
        }

        /// <summary>
        /// Làm tròn giá mua bán
        /// </summary>
        /// <param name="_Money"></param>
        /// <param name="_RoundOption"></param>
        /// <param name="_PriceCcy"></param>
        /// <returns></returns>
        public static decimal LamTronGiaMuaBan(decimal _Money, string _RoundOption, string _PriceCcy, out string _Error)
        {
            _Error = string.Empty;
            decimal result = _Money;
            if (_PriceCcy != "VND")
            {
                result = _Money;
                return result;
            }
            int sRound = 1;

            try
            {
                if (_RoundOption == "K")
                {
                    result = _Money;
                }
                else if (_RoundOption == "L")
                {

                    string amoney = ((Int32)_Money).ToString();
                    if (amoney.Length <= sRound)
                    {
                        result = _Money;
                        return result;
                    }
                    string _PhanNguyen = amoney.Substring(0, amoney.Length - sRound);
                    string _PhanLamTron = amoney.Substring(amoney.Length - sRound);
                    int iPhanLamTron = int.Parse(_PhanLamTron == "" ? "0" : _PhanLamTron);
                    int iPhanNguyen = int.Parse(_PhanNguyen == "" ? "0" : _PhanNguyen);
                    if (iPhanLamTron < 3)
                    {
                        result = decimal.Parse(_PhanNguyen) * 10;
                    }
                    else if (iPhanLamTron >= 3 && iPhanLamTron < 7)
                    {
                        result = (decimal.Parse(_PhanNguyen) * 10) + 5;

                    }
                    else if (iPhanLamTron >= 7 && iPhanLamTron <= 9)
                    {
                        result = (decimal.Parse(_PhanNguyen) * 10) + 10;
                    }
                }
                else
                {

                    string amoney = ((Int32)_Money).ToString();
                    if (amoney.Length <= sRound)
                    {
                        result = _Money;
                        return result;
                    }
                    string _PhanNguyen = amoney.Substring(0, amoney.Length - sRound);
                    string _PhanLamTron = amoney.Substring(amoney.Length - sRound);
                    int iPhanLamTron = int.Parse(_PhanLamTron == "" ? "0" : _PhanLamTron);
                    int iPhanNguyen = int.Parse(_PhanNguyen == "" ? "0" : _PhanNguyen);
                    if (iPhanLamTron == 3 || iPhanLamTron == 5 || iPhanLamTron == 7 || iPhanLamTron == 9)
                    {
                        _PhanNguyen = (decimal.Parse(amoney) + 1).ToString();
                        result = decimal.Parse(_PhanNguyen);
                    }

                }
                return result;
            }
            catch (Exception ex)
            {
                _Error = FuncException.GetDetailsException(ex);
                return _Money;
            }
        }
    }
}
