using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XML_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlElement root = xmlDoc.CreateElement("Personas");
            xmlDoc.AppendChild(root);

            XmlElement persona1 = xmlDoc.CreateElement("Persona");
            persona1.SetAttribute("id", "1");
            persona1.InnerText = "Alejandro";
            root.AppendChild(persona1);

            XmlElement persona2 = xmlDoc.CreateElement("Persona");
            persona2.SetAttribute("id", "2");
            persona2.InnerText = "Daylin";
            root.AppendChild(persona2);

            XmlElement persona3 = xmlDoc.CreateElement("Persona");
            persona3.SetAttribute("id", "3");
            persona3.InnerText = "Jesus";
            root.AppendChild(persona3);

            xmlDoc.Save("personas.xml");

            MessageBox.Show("Archivo XML guardado correctamente.");
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load("personas.xml");

                XmlNodeList personas = xmlDoc.GetElementsByTagName("Persona");

                foreach (XmlNode persona in personas)
                {
                    MessageBox.Show($"ID: {persona.Attributes["id"].Value}, Nombre: {persona.InnerText}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el archivo XML: " + ex.Message);
            }
        }
    }
}
