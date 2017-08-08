using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BLLProduct
/// </summary>
public class BLLProduct
{
	public BLLProduct()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetALlProduct()
    {
        return DAO.GetDataTable("select *from tblProduct", CommandType.Text, null);
    }
    public DataTable ProductByCategoryId(int categoryid)
    {
        SqlParameter[] param = new SqlParameter[]
        {
new SqlParameter("@categoryid",categoryid)
        };
        return DAO.GetDataTable("select *from tblProduct where CategoryId=@categoryid", CommandType.Text, param);
    }
    public int DeleteProduct(int productid)
    {
        SqlParameter[] param = new SqlParameter[]
        {
new SqlParameter("@productid",productid)
        };
        return DAO.IDU("delete from tblProduct where ProductId=@productid", CommandType.Text, param);
    }
}