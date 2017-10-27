using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeyiShow.Libraries;
using Com.Alipay;
using Newtonsoft.Json;
using WeyiShow.MODELS;
using System.Xml;

namespace WeyiShow
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public XmlDocument Provincedoc;
        public XmlDocument Citydoc;
        public XmlDocument Districtdoc;

        public XmlElement ProvincerootElem;
        public XmlElement CityrootElem;
        public XmlElement DistrictrootElem;

        public XmlNodeList ProvinceNodes;
        public XmlNodeList CityNodes;
        public XmlNodeList DistrictNodes;

        public string ProvinceName;
        public string ProvinceID;
        public string CityName;
        public string CityID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.Items.Insert(0, new ListItem("选择省", "0"));
            }
            Provincedoc = new XmlDocument();
            Provincedoc.Load(HttpRuntime.AppDomainAppPath.ToString() + "RegionFile/Provinces.xml");    //加载Xml文件    
            ProvincerootElem = Provincedoc.DocumentElement;   //获取根节点    
            ProvinceNodes = ProvincerootElem.GetElementsByTagName("Province"); //获取Provinces子节点集合  

            Citydoc = new XmlDocument();
            Citydoc.Load(HttpRuntime.AppDomainAppPath.ToString() + "RegionFile/Cities.xml");    //加载Xml文件    
            CityrootElem = Citydoc.DocumentElement;   //获取根节点    
            CityNodes = CityrootElem.GetElementsByTagName("City"); //获取Cities子节点集合   

            Districtdoc = new XmlDocument();
            Districtdoc.Load(HttpRuntime.AppDomainAppPath.ToString() + "RegionFile/Districts.xml");    //加载Xml文件    
            DistrictrootElem = Districtdoc.DocumentElement;   //获取根节点    
            DistrictNodes = DistrictrootElem.GetElementsByTagName("District"); //获取Cities子节点集合   
            //DropDownList1.Items.Insert(0, new ListItem("选择省", "0"));
            DropDownList2.Items.Insert(0, new ListItem("选择市", "0"));
            DropDownList3.Items.Insert(0, new ListItem("选择县", "0"));
            foreach (XmlNode Provincenode in ProvinceNodes)
            {
                string strProvinceName = ((XmlElement)Provincenode).GetAttribute("ProvinceName");   //获取name属性值    
                string strProvinceID = ((XmlElement)Provincenode).GetAttribute("ID");
                DropDownList1.Items.Add(strProvinceName);
            }
        }



        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProvinceName = DropDownList1.SelectedItem.ToString();
            DropDownList2.Items.Clear();
            DropDownList3.Items.Clear();
            foreach (XmlNode Provincenode in ProvinceNodes)
            {
                if (((XmlElement)Provincenode).GetAttribute("ProvinceName").Equals(DropDownList1.SelectedItem.ToString()))
                {
                    ProvinceID = ((XmlElement)Provincenode).GetAttribute("ID");
                    break;
                }
            }
            DropDownList2.Items.Insert(0, new ListItem("选择市", "0"));
            foreach (XmlNode Citynode in CityNodes)
            {
                if (((XmlElement)Citynode).GetAttribute("PID").Equals(ProvinceID))
                {
                    string strCityName = ((XmlElement)Citynode).GetAttribute("CityName");
                    DropDownList2.Items.Add(strCityName);
                }
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CityName = DropDownList2.SelectedItem.ToString();
            DropDownList3.Items.Clear();
            foreach (XmlNode Citynode in CityNodes)
            {
                if (((XmlElement)Citynode).GetAttribute("CityName").Equals(CityName) )
                {
                    CityID = ((XmlElement)Citynode).GetAttribute("ID");
                    break;
                }
            }
            foreach (XmlNode Districtnode in DistrictNodes)
            {
                if (((XmlElement)Districtnode).GetAttribute("CID").Equals(CityID))
                {
                    string strDistrictName = ((XmlElement)Districtnode).GetAttribute("DistrictName");   //获取name属性值    
                    DropDownList3.Items.Add(strDistrictName);
                }
            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }




}