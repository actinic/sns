using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BLLCategory
/// </summary>
public class BLLCategory
{
	public BLLCategory()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetAllCategory()
    {
        return DAO.GetDataTable("select *from tblCategory", CommandType.Text, null);
    }
}