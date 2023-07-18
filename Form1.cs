using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using System.Xml;
using System.Xml.Linq;
namespace XmlWithForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void yukle()
        {
            XmlDocument xmlDocument = new XmlDocument();
            DataSet db = new DataSet();
            XmlReader xmlReader;
            xmlReader = XmlReader.Create(@"IsimListesi.xml", new XmlReaderSettings());
            db.ReadXml(xmlReader);
            dataGridView1.DataSource = db.Tables[0];
            xmlReader.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            yukle();
        }

        private void ekle_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"IsimListesi.xml");
            x.Element("Personeller").Add(
                new XElement("Personel",
                new XElement("ad", textBox1.Text),
                new XElement("soyad", textBox2.Text)
                ));
            x.Save(@"IsimListesi.xml");
            yukle();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"IsimListesi.xml");
            x.Root.Elements().Where(a => a.Element("ad").Value == textBox1.Text).Remove();
            x.Root.Elements().Where(a => a.Element("soyad").Value == textBox2.Text).Remove();
            x.Save(@"IsimListesi.xml");
            yukle();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"IsimListesi.xml");

        }
    }
}