using SloveWare.Entities;
using SloveWare.Entities.DTOModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DairySolution.Helper
{
    public static class LoginHelper
    {

        public static tblContributor loginData { get; set; } = null;



        public static DataFilerModel GetFilterModel()
        {
            if (loginData == null) return new DataFilerModel();
            else
            {
                return (new DataFilerModel { UserId = (int)loginData.UserId, ProductId = (int)loginData.SubscribedProductId });
            }
        }


    }
}
