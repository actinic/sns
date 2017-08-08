using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BLLUser
/// </summary>
public class BLLUser
{
	public BLLUser()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int CreateUser(string username, string password, string usertype)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@username",username),
            new SqlParameter("@password",password),
            new SqlParameter("@usertype",usertype)
        };
        return DAO.IDU("insert into tblUser (Username,Password,Usertype) values(@username,@password,@usertype)", CommandType.Text, param);
    }
    public int UPdateUser(string displayname, string type, int userid)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@displayname",displayname),
            new SqlParameter("@type",type),
             new SqlParameter("@userid",userid)
        };
        return DAO.IDU("update picsAdmin set displayname=@displayname,type=@type where UserId=@userid", CommandType.Text, param);
    }
    public int DeleteUser(int userid)
    {
        SqlParameter[] param = new SqlParameter[]
        {
          
             new SqlParameter("@userid",userid)
        };
        return DAO.IDU("delete from tblUser where UserId=@userid", CommandType.Text, param);
    }
    public DataTable GetAllUser()
    {
        return DAO.GetDataTable("select *from tblUser", CommandType.Text, null);
    }
    public DataTable GetUserbyUserid(int userid)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@userid",userid)
        };
        return DAO.GetDataTable("select *from tblUser where Userid=@userid", CommandType.Text, param);
        
    }
}