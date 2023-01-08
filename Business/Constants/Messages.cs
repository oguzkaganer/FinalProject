﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi.";
		public static string ProductUpdated = "Ürün güncellendi.";
		public static string ProductNameInvalid = "Ürün İsmi Geçersiz.";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ProductsListed = "Ürünler Listelendi.";
		public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir!";
		public static string ProductNameAlreadyExists = "Bu isimden daha önce kayıt yapılmış.";
		internal static string CategoryLimitExceded = "Kategori limiti aşıldı";
	}
}
