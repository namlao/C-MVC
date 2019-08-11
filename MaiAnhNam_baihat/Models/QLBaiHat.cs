using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MaiAnhNam_baihat.Models
{
    public class QLBaiHat
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Nhap ma bai hat")]
        [Display(Name ="MaBH")]
        public string MaBH { get; set; }
        [Required(ErrorMessage = "Nhap ten bai hat")]
        [Display(Name = "TenBH")]
        public string TenBH { get; set; }
        [Required(ErrorMessage = "Nhap tac gia")]
        [Display(Name = "TacGia")]
        public string TacGia { get; set; }
    }
    class BaiHatList
    {
        DBConnection db;
        public BaiHatList()
        {
            db = new DBConnection();
        }

        //phuowng thuc lay du lieu tu csdl
        public List<QLBaiHat> getBaiHat(string ID)
        {
            string sql;
            if (string.IsNullOrEmpty(ID))
            {
                sql = "SELECT * FROM BaiHat";
            }
            else
            {
                sql = "SELECT * FROM BaiHat WHERE ID = " + ID;
            }
            List<QLBaiHat> strList = new List<QLBaiHat>();
            SqlConnection con = db.getConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);

            DataTable dt = new DataTable();

            //Mo ket noi;

            con.Open(); // mo ket noi
            cmd.Fill(dt); // do toan bo du lieu truy van duoc vao DataTable

            //dong ket noi
            cmd.Dispose(); //ngat cau lenh do du lieu vao cmd.fill(dt);
            con.Close();

            QLBaiHat strBH;

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                strBH = new QLBaiHat();
                strBH.ID =Convert.ToInt32(dt.Rows[i]["Id"].ToString());
                strBH.MaBH = dt.Rows[i]["MaBH"].ToString();
                strBH.TenBH = dt.Rows[i]["TenBH"].ToString();
                strBH.TacGia = dt.Rows[i]["TacGia"].ToString();

                strList.Add(strBH);
            }
            return strList;
        }
        public void AddBaiHat(QLBaiHat strBH)
        {
            string sql = "INSERT INTO BaiHat(MaBH,TenBH,TacGia) VALUES(N'"+strBH.MaBH+"',N'"+strBH.TenBH+"',N'"+strBH.TacGia+"')";
            //Tao ket noi csdl
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql,con);

            con.Open();
            cmd.ExecuteNonQuery(); //chay cau lenh truy van cmd
            cmd.Dispose();
            con.Close();
        }
        public void EditBaiHat(QLBaiHat strBH)
        {
            string sql = "UPDATE BaiHat SET MaBH = N'"+strBH.MaBH+"',TenBH =N'"+strBH.TenBH+"',TacGia = N'"+strBH.TacGia+"'WHERE Id="+strBH.ID;
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql,con);

            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void Delete(QLBaiHat strBH)
        {
            string sql = "DELETE FROM BaiHat WHERE Id ="+strBH.ID;
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql,con);

            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
    }
}