using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LinqToXmlConvert
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            DataClassesDataContext dc = new DataClassesDataContext();//Create LINQ to SQL datacontext object
            string xmlFilePath = Application.StartupPath + "\\new.xml";//Retrieve the path of xml file
            //Create the xml file
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("People",
                    from p in dc.tb_Employee//Generate xml file with info get from database
                    select new XElement[]{
                new XElement("Person",
                new XAttribute("ID",p.ID),
                new XElement("Name",p.Name),
                new XElement("Sex",p.Sex),
                new XElement("Age", p.Age),
                new XElement("Tel",p.Tel),
                new XElement("QQ",p.QQ),
                new XElement("Email", p.Email),
                new XElement("Address", p.Address)
                )}
                    )
                );
            doc.Save(xmlFilePath);//Save xml file
            webBrowser1.Url = new Uri(xmlFilePath);//Display content in Browser
        }
    }
}
